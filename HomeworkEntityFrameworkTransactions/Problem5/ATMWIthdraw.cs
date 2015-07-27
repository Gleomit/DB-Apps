using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Problem4;
using Problem4.Models;

namespace Problem5
{
    public class ATMWIthdraw
    {
        static void Main(string[] args)
        {
            Console.Write("Enter card number: ");
            var cardNumber = Console.ReadLine();

            Console.Write("Enter PIN: ");
            var pin = Console.ReadLine();

            Withdraw(cardNumber, pin, 1500);
        }

        private static void Withdraw(string cardNumber, string cardPIN, decimal moneyAmount)
        {
            using (var atmContext = new ATMContext())
            {
                using (var transaction = atmContext.Database.BeginTransaction())
                {
                    if (atmContext.CardAccounts.Any(cardAccount => cardAccount.CardNumber == cardNumber
                                                                   && cardAccount.CardPIN == cardPIN))
                    {
                        var theAccount =
                            atmContext.CardAccounts.First(cardAccount => cardAccount.CardNumber == cardNumber
                                                                         && cardAccount.CardPIN == cardPIN);

                        if (theAccount.CardCash < moneyAmount)
                        {
                            throw new Exception("nsufficient amount of money.");
                            transaction.Rollback();
                        }
                        else
                        {
                            theAccount.CardCash -= moneyAmount;
                            atmContext.SaveChanges();

                            atmContext.TransactionHistories.Add(new TransactionHistory()
                            {
                                CardNumber = theAccount.CardNumber,
                                Amount = moneyAmount,
                                TransactionDate = DateTime.Now
                            });

                            atmContext.SaveChanges();

                            transaction.Commit();
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong combination of card number and pin code.");
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
