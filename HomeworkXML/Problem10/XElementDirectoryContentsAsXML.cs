using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Problem10
{
    class XElementDirectoryContentsAsXML
    {
        static void Main(string[] args)
        {
            var path = @"d:\1";

            var document = new XDocument(
                new XDeclaration("1.0", "UTF-8", null),
                new XElement("root-dir",
                    new XAttribute("path", path)));

            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fileDirectories = file.Replace(path, "")
                    .Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                var len = fileDirectories.Length;
                var root = document.Element("root-dir");
                XElement dir = root;

                for (int i = 0; i < len - 1; i++)
                {
                    dir = document.XPathSelectElement(String.Format("//dir[@name = '{0}']", fileDirectories[i]));
                    if (dir == null)
                    {
                        if (i < 1)
                        {
                            dir = root;
                        }
                        else
                        {
                            dir = document.XPathSelectElement(String.Format("//dir[@name = '{0}']", fileDirectories[i - 1]));
                        }

                        var newDir = new XElement("dir",
                            new XAttribute("name", fileDirectories[i]));
                        dir.Add(newDir);
                        dir = newDir;
                    }
                }

                dir.Add(new XElement("file",
                    new XAttribute("name", fileDirectories[len - 1])));
            }

            Console.WriteLine(document.Declaration);
            Console.WriteLine(document);
        }
    }
}
