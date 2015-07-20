using System.Linq;
using Problem1;

namespace Problem2
{
    public class PlayWithToListMain
    {
        static void Main(string[] args)
        {
            using (var context = new AdsEntities())
            {
                /* The slow version */
                var adsSlow = context.Ads
                    .ToList()
                    .Where(a => a.AdStatus != null && a.AdStatus.Status == "Published")
                    .Select(a => new
                    {
                        Title = a.Title,
                        PublishDate = a.Date,
                        Category = a.Category,
                        Town = a.Town
                    }).ToList()
                    .OrderBy(a => a.PublishDate);

                /* The fast version */
                var adsFast = from ad in context.Ads
                    where ad.AdStatus.Status == "Published"
                    orderby ad.Date
                    select new
                    {
                        Title = ad.Title,
                        Category = ad.Category,
                        Town = ad.Town
                    };
            }
        }
    }
}
