using System.Collections.Generic;
using Problem4.Models;

namespace Problem4.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Problem4.ATMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ATMContext context)
        {
            var cardAccounts = new List<CardAccount>
            {
                new CardAccount
                {
                    CardNumber = "1234567890",
                    CardPIN = "0000",
                    CardCash = 1500
                },
                new CardAccount
                {
                    CardNumber = "a123456789",
                    CardPIN = "1111",
                    CardCash = 1500
                },
                new CardAccount
                {
                    CardNumber = "ab12345678",
                    CardPIN = "0101",
                    CardCash = 1500
                }
            };

            cardAccounts.ForEach(delegate(CardAccount cardAccountA)
            {
                if (!context.CardAccounts.Any(cardAccountB => cardAccountA.CardNumber == cardAccountB.CardNumber))
                {
                    context.CardAccounts.AddOrUpdate(cardAccountA);
                }
            });

            context.SaveChanges();
        }
    }
}
