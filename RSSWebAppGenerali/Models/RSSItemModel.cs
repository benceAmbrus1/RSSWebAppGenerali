using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSWebAppGenerali.Models
{
    public class RSSItemModel
    {
        public string  Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
        public string Category { get; set; }
        public string PubDate { get; set; }
        public bool IsItRead { get; set; } = false;
        public bool IsItFavourite { get; set; } = false;
        public string UserId { get; set; }
    }
}