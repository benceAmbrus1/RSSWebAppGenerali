using RSSWebAppGenerali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSWebAppGenerali.DTOs
{
    public class RSSItemDTO
    {
        public string Category { get; set; }
        public List<RSSItemModel> RssList { get; set; }

        public RSSItemDTO(string category, List<RSSItemModel> rssList)
        {
            RssList = rssList;
            Category = category;
        }
    }
}