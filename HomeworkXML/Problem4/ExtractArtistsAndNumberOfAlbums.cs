using System;
using System.Collections.Generic;
using System.Xml;

namespace Problem4
{
    class ExtractArtistsAndNumberOfAlbums
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            Dictionary<string, int> artistAlbumsNumber = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (!artistAlbumsNumber.ContainsKey(node.ChildNodes[1].InnerText))
                {
                    artistAlbumsNumber.Add(node.ChildNodes[1].InnerText, 0);
                }

                artistAlbumsNumber[node.ChildNodes[1].InnerText] += 1;
            }

            foreach (var artist in artistAlbumsNumber)
            {
                Console.WriteLine("{0} - album count {1}", artist.Key, artist.Value);
            }
        }
    }
}
