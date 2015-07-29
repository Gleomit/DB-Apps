using System;
using System.Xml;

namespace Problem6
{
    class DeleteAlbums
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes[0].ChildNodes)
            {
                if (Decimal.Parse(node.ChildNodes[4].InnerText) > 20)
                {
                    rootNode.ChildNodes[0].RemoveChild(node);
                }
            }

            doc.Save("cheap-albums-catalog.xml");
        }
    }
}
