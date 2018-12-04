using RSSWebAppGenerali.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace RSSWebAppGenerali.DAOs
{
    public class FeedLinkDao : SqlDao
    {
        public List<FeedLinkModel> LoadUserLinks(string UserId)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"select Id, Link, UserId
                            from dbo.AspNetFeedLinks
                            where UserId = @userId";
                return connection.Query<FeedLinkModel>(sql, new { userId = UserId }).ToList();
            }
        }

        public int SaveUserLinks(FeedLinkModel data)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"If not EXISTS(Select 1 from dbo.AspNetFeedLinks where Link = @Link )
                                Begin
                                    insert into dbo.AspNetFeedLinks (Link, UserId)
                                    values (@Link, @UserId)
                                End";
               
                return connection.Execute(sql, data);
            }
        }

        public int DeleteUserLink(int feedId)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"delete from dbo.AspNetFeedLinks
                               where Id = " + feedId;

                return connection.Execute(sql);
            }
        }
    }
}