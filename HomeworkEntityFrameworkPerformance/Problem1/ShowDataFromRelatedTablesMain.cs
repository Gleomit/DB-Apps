using System;
using System.Data.Entity;
using System.Linq;

namespace Problem1
{
    public class ShowDataFromRelatedTablesMain
    {
        static void Main(string[] args)
        {
            using (var context = new AdsEntities())
            {
                /* The slow version */
                var adsWithoutInclude = context.Ads;

                foreach (var ad in adsWithoutInclude)
                {
                    Console.WriteLine("{0}; {1}; {2}; {3}; {4}",
                        ad.Title,
                        (ad.AdStatus != null ? ad.AdStatus.Status : "null"),
                        (ad.Category != null ? ad.Category.Name : "null"),
                        (ad.Town != null ? ad.Town.Name : "null"),
                        (ad.AspNetUser != null ? ad.AspNetUser.UserName : "null"));
                }

                /* The fast version */
                var adsWithInclude = from ad in context.Ads.Include(a => a.AdStatus)
                                                .Include(a => a.Category)
                                                .Include(a => a.Town)
                                                .Include(a => a.AspNetUser)
                                     select ad;

                foreach (var ad in adsWithInclude)
                {
                    Console.WriteLine("{0}; {1}; {2}; {3}; {4}",
                        ad.Title,
                        (ad.AdStatus != null ? ad.AdStatus.Status : "null"),
                        (ad.Category != null ? ad.Category.Name : "null"),
                        (ad.Town != null ? ad.Town.Name : "null"),
                        (ad.AspNetUser != null ? ad.AspNetUser.UserName : "null"));
                }
            }
        }
    }
}
