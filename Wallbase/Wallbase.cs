using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsQuery;
using System.Threading.Tasks;

namespace Wallbase
{
    class Wallbase
    {
        public class Collection
        {
            public int ID { get; set; }
            public string Title { get; set; }

            public Collection(int id, string title)
            {
                ID = id;
                Title = title;
            }

            public override string ToString()
            {
                return Title;
            }
        }

        public static List<Collection> GetTopCollections()
        {
            var collections = new List<Collection>();
            string url = "http://wallbase.cc/toplist?section=collections";

            /*
            foreach (var link in CQ.CreateFromUrl(url)["div.info a.link"])
            {
                string href = string.Empty;

                if (link.TryGetAttribute("href", out href))
                {
                    string[] parts = href.Split('/');
                    int id = 0;

                    if (int.TryParse(parts.Last(), out id))
                    {
                        string title = link.FirstChild.TextContent;
                        collections.Add(new Collection(id, title.Trim()));
                    }
                }
            }
            */

            Parallel.ForEach(CQ.CreateFromUrl(url)["div.info a.link"], link =>
            {
                string href = string.Empty;

                if (link.TryGetAttribute("href", out href))
                {
                    string[] parts = href.Split('/');
                    int id = 0;

                    if (int.TryParse(parts.Last(), out id))
                    {
                        string title = link.FirstChild.TextContent;

                        lock (collections)
                        {
                            collections.Add(new Collection(id, title.Trim()));
                        }
                    }
                }
            });

            return collections;
        }

        public static string[] GetImagesFromCollection(int id)
        {
            var links = new List<String>();
            string url = string.Format("http://wallbase.cc/collection/{0}", id);

            /*
            // Get image from href in collection.
            foreach (var elem in CQ.CreateFromUrl(url)["div.thumbnail div.wrapper a[target]"])
            {
                string href = string.Empty;

                if (elem.TryGetAttribute("href", out href))
                {
                    try
                    {
                        foreach (var img in CQ.CreateFromUrl(href)["div.content img"])
                        {
                            string src = string.Empty;

                            if (img.TryGetAttribute("src", out src))
                            {
                                links.Add(src);
                            }
                        }
                    }
                    catch { }
                }
            }
            */

            Parallel.ForEach(CQ.CreateFromUrl(url)["div.thumbnail div.wrapper a[target]"], elem =>
            {
                string href = string.Empty;

                if (elem.TryGetAttribute("href", out href))
                {
                    try
                    {
                        foreach (var img in CQ.CreateFromUrl(href)["div.content img"])
                        {
                            string src = string.Empty;

                            if (img.TryGetAttribute("src", out src))
                            {
                                lock (links)
                                {
                                    links.Add(src);
                                }
                            }
                        }
                    }
                    catch { }
                }
            });

            return links.ToArray();
        }
    }
}
