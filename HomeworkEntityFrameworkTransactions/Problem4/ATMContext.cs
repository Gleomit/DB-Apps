using Problem4.Migrations;
using Problem4.Models;

namespace Problem4
{
    using System.Data.Entity;

    public class ATMContext : DbContext
    {
        public ATMContext()
            : base("name=ATMContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());
        }

        public virtual DbSet<CardAccount> CardAccounts { get; set; }

        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}