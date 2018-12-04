using Dapper;
using RSSWebAppGenerali.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RSSWebAppGenerali.DAOs
{
    public class RSSDao :SqlDao
    {
        public int SaveRSSItem(RSSItemModel data)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"If not EXISTS(Select 1 from dbo.AspNetRSSItems where Link = @Link )
                                Begin
                                    insert into dbo.AspNetRSSItems (Title, Description, Link, Guid, Category, PubDate, IsItRead, IsItFavourite, UserId, IdUrl)
                                    values (@Title, @Description, @Link, @Guid, @Category, @PubDate, @IsItRead, @IsItFavourite, @UserId, @IdUrl)
                                End";

                return connection.Execute(sql, data);
            }
        }

        public List<RSSItemModel> LoadRSSItems(string UserId, string IdUrl)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"select * from dbo.AspNetRSSItems
                                where UserId = @userId
                                and IdUrl = @idUrl";

                return connection.Query<RSSItemModel>(sql, new { userId = UserId, idUrl = IdUrl }).ToList();
            }
        }

        public int SetFavourite(int Id)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"IF (Select IsItFavourite from dbo.AspNetRSSItems as t
                                where Id = @id) = '0'
	                                Begin
		                                Update dbo.AspNetRSSItems
		                                Set IsItFavourite = '1'
		                                Where Id = @id
	                                End
                                    ELSE
	                                    Begin
		                                    Update dbo.AspNetRSSItems
		                                    Set IsItFavourite = '0'
		                                    Where Id = @id
	                                    End";

                return connection.Execute(sql, new { id = Id });
            }
        }

        public List<RSSItemModel> LoadFavouriteRSSItems(string UserId)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                string sql = @"select * from dbo.AspNetRSSItems
                                where UserId = @userId
                                and IsItFavourite = '1'";

                return connection.Query<RSSItemModel>(sql, new { userId = UserId}).ToList();
            }
        }
    }
}