using System;
using System.Collections.Generic;
using System.Text;

namespace Mukes.Core
{
    public class RestaurantsStructure
    {
        public string Name { get; set; }
        public string RSSFeedURL { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="rssFeedURL">RSSFeedURL</param>
        public RestaurantsStructure(string name, string rssFeedURL)
        {
            Name = name;
            RSSFeedURL = rssFeedURL;
        }
    }
}
