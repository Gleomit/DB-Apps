using System;
using System.Collections.Generic;
using System.Xml;
namespace Problem3
{
    public class ExtractAllArtistsAlphabetically
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            SortedSet<string> artistNames = new SortedSet<string>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                artistNames.Add(node.ChildNodes[1].InnerText);
            }

            foreach (var artistName in artistNames)
            {
                Console.WriteLine(artistName);
            }
        }
    }
}
