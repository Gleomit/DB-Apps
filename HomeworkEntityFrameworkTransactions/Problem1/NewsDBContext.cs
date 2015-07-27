using Problem1.Migrations;

namespace Problem1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewsDBContext : DbContext
    {
        public NewsDBContext()
            : base("name=NewsDBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDBContext, Configuration>());
        }

        public virtual DbSet<News> News { get; set; }
    }
}