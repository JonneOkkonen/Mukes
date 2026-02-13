using Android.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace Mukes.Core
{
    public class RSSFeed
    {
        public static List<MenuStructure> List = new List<MenuStructure>();
        private const string TAG = "RSSFetch";

        public static string Fetch(string rss_url, string language)
        {
            Log.Info(TAG, $"Fetch: url={rss_url}, language={language}");
            try
            {
                // Check If there is URL
                if (rss_url == "noValue")
                {
                    return "noURL";
                }

                // Set Correct Language on URL
                string URL = rss_url;
                switch (language)
                {
                    case "en":
                        URL = URL.Substring(0, 44) + "EN" + URL.Substring(46);
                        break;
                    case "sv":
                        URL = URL.Substring(0, 44) + "SV" + URL.Substring(46);
                        break;
                }

                // Create XMLDocument
                XmlDocument rssXmlDoc = new XmlDocument();

                // Get RSS with HttpWebRequest
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);

                // Set Timeout to 10 seconds
                req.Timeout = 10000; // Timeout in milliseconds

                // Get Response
                WebResponse res = req.GetResponse();
                Stream responseStream = res.GetResponseStream();

                // Load the RSS file from the RSS URL
                rssXmlDoc.Load(responseStream);

                // Parse the Items in the RSS file
                XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

                // Iterate through the items in the RSS file
                foreach (XmlNode rssNode in rssNodes)
                {
                    // Title
                    XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                    string title = TitleParse(rssSubNode != null ? rssSubNode.InnerText : "", language);

                    // Check if item needs to be skipped
                    if (title != "skip")
                    {

                        // Description
                        rssSubNode = rssNode.SelectSingleNode("description");
                        string description = rssSubNode != null ? rssSubNode.InnerText : "";

                        // Parse Meals and add data to list
                        var list = Lists.MealsFI;
                        switch (language)
                        {
                            case "fi":
                                list = Lists.MealsFI;
                                break;
                            case "en":
                                list = Lists.MealsEN;
                                break;
                            case "sv":
                                list = Lists.MealsSV;
                                break;
                        }
                        List.Add(new MenuStructure(
                                 title,
                                 MealParse(description, list[(int)Lists.Meals.Breakfast]),
                                 MealParse(description, list[(int)Lists.Meals.Lunch]),
                                 MealParse(description, list[(int)Lists.Meals.Dinner]),
                                 MealParse(description, list[(int)Lists.Meals.EveningSnack])
                                ));
                    }
                }
                return "FetchSuccessfull";
            }
            catch (WebException ex)
            {
                Log.Error(TAG, $"RSSFetch: Network error=({ex})");
                return "NetworkError";
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"RSSFetch: error=({ex})");
                return "Error";
            }
        }

        /// <summary>
        /// Parse day of the week and date from the original title
        /// </summary>
        /// <param name="title">Title from RSSFeed</param>
        /// <returns></returns>
        private static string TitleParse(string title, string language)
        {
            // Remove Meals contains word from Exception List
            // Check if Title includes word "henkilö" or Title is empty
            foreach(string item in Lists.MenuException)
            {
                if (title.ToLower().Contains(item) || title == "")
                {
                    return "skip";
                }
            }

            string result = "";

            // Find day of the week from title
            var list = Lists.Viikonpaiva;
            switch (language)
            {
                case "fi":
                    list = Lists.Viikonpaiva;
                    break;
                case "en":
                    list = Lists.DayOfTheWeek;
                    break;
                case "sv":
                    list = Lists.Veckodag;
                    break;
            }
            foreach (string item in list)
            {
                if(title.ToLower().Contains(item.ToLower())){
                    result = item;
                }
            }

            // Find date from title
            foreach(string format in Lists.DateFormats)
            {
                Regex rx = new Regex(format);
                Match match = rx.Match(title);
                if (match.Success){

                    if (result.Length == 0)
                    {
                        result = title;
                    } else
                    {
                        result = result + $" {match}";
                    }

                    if (result == ""){
                        return "skip";
                    }else{
                        return result;
                    }
                }
            }
            Log.Info(TAG, $"No DateFound on Title ({title})");
            return "skip";
        }

        /// <summary>
        /// Parse Breakfast, Lunch, Dinner Or EveningSnack to own string
        /// </summary>
        /// <param name="description">Description from RSSFeed</param>
        /// <param name="meal">Parse given meal</param>
        /// <returns></returns>
        private static string MealParse(string description, string meal)
        {
            string result = "";

            // Parse given Meal
            try{
                result = description
                    .Split(new string[] { $"{meal}:" }, StringSplitOptions.None)[1]
                    .Split("<br><br>")[0]
                    .Trim()
                    .Replace("<br>", "\n")
                    .Replace("), ", ")\n");
            } catch(Exception){
                Log.Info(TAG, $"NoMealFound ({meal}:{description})");
                return "No data";
            }

            // Check If result is empty
            if(result == "") {
                return "No data";
            }
            return result;
        }
    }
}
