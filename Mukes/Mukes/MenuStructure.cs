using System;
using System.Collections.Generic;
using System.Text;

namespace Mukes.Core
{
    public class MenuStructure
    {
        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="description">Description</param>
        public MenuStructure(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
