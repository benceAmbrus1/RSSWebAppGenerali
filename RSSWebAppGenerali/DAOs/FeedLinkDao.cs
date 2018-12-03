using RSSWebAppGenerali.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.AspNet.Identity;

namespace RSSWebAppGenerali.DAOs
{
    public class FeedLinkDao : SqlDao
    {
        public List<FeedLinkModel> LoadUserLinks(string UserId)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"select Link, UserId
                            from dbo.AspNetFeedLinks
                            where UserId = @Id";
                return connection.Query<FeedLinkModel>(sql, new { Id = UserId }).ToList();
            }
        }

        public int SaveUserLinks(FeedLinkModel data)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"insert into dbo.AspNetFeedLinks (Link, UserId)
                                values (@Link, @UserId)";

                return connection.Execute(sql, data);
            }
        }
    }
}