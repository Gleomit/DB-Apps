using System;
using System.Collections.Generic;
using System.Xml;

namespace Problem2
{
    public class ExtractAlbumNamesMain
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            List<string> albumNames = new List<string>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                albumNames.Add(node.ChildNodes[0].InnerText);
            }

            foreach (var albumName in albumNames)
            {
                Console.WriteLine(albumName);
            }
        }
    }
}
