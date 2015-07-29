using System;
using System.Linq;
using System.Xml.Linq;

namespace Problem8
{
    class LinqToXmlOldAlbums
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("../../../catalog.xml");

            var albums =
                from album in xmlDoc.Descendants("album")
                where (DateTime.Now - DateTime.Parse(album.Element("year").Value)).TotalDays > 1826.21099 
                select new
                {
                    Title = album.Element("name"),
                    Price = album.Element("price")
                };

            Console.WriteLine("Found {0} albums:", albums.Count());

            foreach (var album in albums)
            {
                Console.WriteLine("Title - {0}, Price - {1}", album.Title, album.Price);
            }
        }
    }
}
