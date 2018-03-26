using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
                string title = rssSubNode != null ? rssSubNode.InnerText : "";
                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                List.Add(new MenuStructure(title, description));
            }
        }
    }
}
