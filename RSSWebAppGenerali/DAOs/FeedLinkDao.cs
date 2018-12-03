using RSSWebAppGenerali.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RSSWebAppGenerali.DAOs
{
    public class FeedLinkDao : SqlDao
    {
        public List<FeedLinkModel> loadUserLinks(string UserId)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Query(sql).ToList();
            }
        }

    }
}