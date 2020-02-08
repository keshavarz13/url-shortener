using shortener.Models;
using System.Linq;
using shortener.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using shortener.Service.Utilities;

namespace shortener.Service
{
    public class UrlMapper
    {
        public AppDbContext dbContext { get; set; }

        public UrlMapper(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public UrlResorce setShortUrl(UrlRequest requestModel)
        {

            string url;
            Task<bool> search;

            do
            {
                url = ShortUrlCreator.GenerateShortUrl();
                search = dbContext.Urls.AnyAsync(p => p.ShortUrl == url);
                search.Wait();

            } while (search.Result);


            UrlResorce shortUrl = new UrlResorce
            {
                LongUrl = requestModel.LongUrl,
                ShortUrl = url
            };

            dbContext.Urls.Add(shortUrl);
            dbContext.SaveChanges();
            return shortUrl;
        }
    }
}