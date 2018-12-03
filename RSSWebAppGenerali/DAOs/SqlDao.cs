using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSSWebAppGenerali.DAOs
{
    public abstract class SqlDao
    {
        public string GetConnectionString(string conName = "DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[conName].ConnectionString;
        }
    }
}