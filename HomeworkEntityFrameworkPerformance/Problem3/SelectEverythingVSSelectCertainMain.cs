using System.Linq;
using Problem1;

namespace Problem3
{
    public class SelectEverythingVSSelectCertainMain
    {
        static void Main(string[] args)
        {
            using (var context = new AdsEntities())
            {
                /* The slow version */

                var ads = from ad in context.Ads
                    select ad;

                /* The fast version */

                var adsTitles = from ad in context.Ads
                    select ad.Title;
            }
        }
    }
}
