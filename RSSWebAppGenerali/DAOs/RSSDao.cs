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
                string sql = @"insert into dbo.AspNetRSSItems (Title, Description, Link, Guid, Category, PubDate, IsItRead, IsItFavourite, UserId)
                                values (@Title, @Description, @Link, @Guid, @Category, @PubDate, @IsItRead, @IsItFavourite, @UserId)";

                return connection.Execute(sql, data);
            }
        }
    }
}