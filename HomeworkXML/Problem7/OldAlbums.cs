using System;
using System.Collections.Generic;
using System.Xml;

namespace Problem7
{
    class OldAlbums
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            string xPathQuery = "/albums/album";

            Dictionary<string, decimal> albumsPrices = new Dictionary<string, decimal>();

            XmlNodeList albumsList = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in albumsList)
            {
                if ((DateTime.Now - DateTime.Parse(node.ChildNodes[2].InnerText)).TotalDays > 1826.21099)
                {
                    albumsPrices.Add(node.ChildNodes[0].InnerText, Decimal.Parse(node.ChildNodes[4].InnerText));
                }
            }

            Console.WriteLine("Found {0} albums:", albumsPrices.Keys.Count);

            foreach (var album in albumsPrices)
            {
                Console.WriteLine("Title - {0}, Price - {1}", album.Key, album.Value);
            }
        }
    }
}
