using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSWebAppGenerali.Models
{
    public class RSSItem
    {

        public string  Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
        public string Category { get; set; }
        public string PubDate { get; set; }
    }
}