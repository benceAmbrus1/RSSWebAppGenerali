using Microsoft.AspNet.Identity;
using RSSWebAppGenerali.DAOs;
using RSSWebAppGenerali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.XPath;

namespace RSSWebAppGenerali.Services
{
    public class RSSService
    {
        public static string ReadTitle(string url)
        {
            string title = "";
            XPathDocument document = new XPathDocument(url);
            XPathNavigator navigator = document.CreateNavigator();
            XPathNodeIterator nodes = navigator.Select("//channel");
            while (nodes.MoveNext())
            {
                XPathNavigator node = nodes.Current;

                title = node.SelectSingleNode("title").Value;
            }
            return title;
        }

        public static List<RSSItemModel> Read(string url, int counter = 0, string userId = "")
        {
            List<RSSItemModel> listRssItems = new List<RSSItemModel>();
            try
            {
                XPathDocument document = new XPathDocument(url);
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator nodes = navigator.Select("//item");

                if (counter != 0)
                {
                    int n = 0;
                    while (n<counter && nodes.MoveNext())
                    {
                        XPathNavigator node = nodes.Current;
                        listRssItems.Add(new RSSItemModel
                        {
                            Category = node.SelectSingleNode("category").Value,
                            Description = node.SelectSingleNode("description").Value,
                            Guid = node.SelectSingleNode("guid").Value,
                            Link = node.SelectSingleNode("link").Value,
                            PubDate = node.SelectSingleNode("pubDate").Value,
                            Title = node.SelectSingleNode("title").Value
                        });
                        n++;
                    }
                }
                else
                {
                    while (nodes.MoveNext())
                    {
                        XPathNavigator node = nodes.Current;
                        RSSItemModel rssItem = new RSSItemModel
                        {
                            Category = node.SelectSingleNode("category").Value,
                            Description = node.SelectSingleNode("description").Value,
                            Guid = node.SelectSingleNode("guid").Value,
                            Link = node.SelectSingleNode("link").Value,
                            PubDate = node.SelectSingleNode("pubDate").Value,
                            Title = node.SelectSingleNode("title").Value,
                            UserId = userId,
                            IdUrl = url
                        };

                        SaveLoadedRSSes(rssItem);
                        listRssItems.Add(rssItem);
                    }
                }
            }
            catch
            {
                listRssItems = null;
            }
            return listRssItems;
        }

        private static void SaveLoadedRSSes(RSSItemModel rssItem)
        {
            RSSDao db = new RSSDao();
            db.SaveRSSItem(rssItem);
        }

    }
}