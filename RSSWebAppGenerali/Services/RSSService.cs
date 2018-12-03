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
        public static List<RSSItemModel> Read(string url, int counter = 0)
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
                        listRssItems.Add(new RSSItemModel
                        {
                            Category = node.SelectSingleNode("category").Value,
                            Description = node.SelectSingleNode("description").Value,
                            Guid = node.SelectSingleNode("guid").Value,
                            Link = node.SelectSingleNode("link").Value,
                            PubDate = node.SelectSingleNode("pubDate").Value,
                            Title = node.SelectSingleNode("title").Value
                        });
                    }
                }
            }
            catch
            {
                listRssItems = null;
            }
            return listRssItems;
        }
    }
}