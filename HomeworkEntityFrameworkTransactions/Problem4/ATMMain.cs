using System.Linq;

namespace Problem4
{
    public class ATMMain
    {
        static void Main(string[] args)
        {
            using (var atmContext = new ATMContext())
            {
                atmContext.CardAccounts.Count();
            }
        }
    }
}
