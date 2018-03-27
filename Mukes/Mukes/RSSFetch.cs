using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Mukes.Core
{
    public class RSSFeed
    {
        public static List<MenuStructure> List = new List<MenuStructure>();

        public static void Fetch()
        {
            string rss_url = "http://ruokalistat.leijonacatering.fi/rss/2/1/549339f9-e510-e511-892b-78e3b50298fc";

            // Create XMLDocument
            XmlDocument rssXmlDoc = new XmlDocument();

            // Get RSS with HttpWebRequest
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(rss_url);

            // Set Timeout to 10 seconds
            req.Timeout = 10000; // Timeout in milliseconds

            // Get Response
            System.Net.WebResponse res = req.GetResponse();
            Stream responseStream = res.GetResponseStream();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load(responseStream);

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = TitleParse(rssSubNode != null ? rssSubNode.InnerText : "");
                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                if (title != "skip"){
                    List.Add(new MenuStructure(title, description));
                }
            }
        }

        /// <summary>
        /// Parse day of the week and date from the original title
        /// </summary>
        /// <param name="title">Original title from RSSFeed</param>
        /// <returns></returns>
        private static string TitleParse(string title)
        {
            // Remove Henkilöstölounaat
            // Check if Title includes word "henkilö" or Title is empty
            if (title.ToLower().Contains("henkilö") || title == "")
            {
                return "skip";
            }

            string result = "";

            // Find day of the week from title
            foreach (string item in Keywords.Viikonpaiva)
            {
                if(title.Contains(item)){
                    result = item;
                }
            }

            // Find date from title
            foreach(string format in Keywords.DateFormats)
            {
                Regex rx = new Regex(format);
                Match match = rx.Match(title);
                if (match.Success){

                    result = result + $" {match}";

                    if (result == ""){
                        return "skip";
                    }else{
                        return result;
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine($"No DateFound on Title ({title})");
            return "skip";
        }
    }
}
