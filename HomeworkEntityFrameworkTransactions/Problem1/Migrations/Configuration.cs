namespace Problem1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Problem1.NewsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsDBContext context)
        {
            string sampleNewsContent = "EF 7 Beta To Be Released in May 2016.";

            if (!context.News.Any(n => n.NewsContent == sampleNewsContent))
            {
                context.News.Add(new News()
                {
                    NewsContent = "EF 7 Beta To Be Released in May 2016."
                });

                context.SaveChanges();
            }       
        }
    }
}
