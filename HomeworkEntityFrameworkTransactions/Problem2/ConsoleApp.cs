using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Problem1;

namespace Problem2
{
    public class ConsoleApp
    {
        public static void Main()
        {
            using (var newsDBContext = new NewsDBContext())
            {
                var theNews = newsDBContext.News.First();
                bool canProceed = false;

                Console.WriteLine("Application Started");
                Console.WriteLine("Text From DB: {0}", theNews.NewsContent);
                
                while (canProceed == false)
                {
                    canProceed = true;

                    Console.WriteLine("Enter the corrected text: ");
                    string correctedText = Console.ReadLine();

                    theNews.NewsContent = correctedText;

                    try
                    {
                        newsDBContext.Entry(theNews).State = EntityState.Modified;
                        newsDBContext.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException exception)
                    {
                        exception.Entries.Single().Reload();
                        theNews = newsDBContext.News.First();
                        Console.Write("Conflict! Text from DB: " + theNews.NewsContent);
                        canProceed = false;
                    }
                }

                Console.WriteLine("Changes successfully saved in the DB.");
            }
        }
    }
}
