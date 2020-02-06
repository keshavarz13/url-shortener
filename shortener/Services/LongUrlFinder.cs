using shortener.Models;
using System.Linq; 
using shortener.Contexts;
using System;

namespace shortener.Service
{
    public class LongUrlFinder
    {
        public AppDbContext dbContext { get; set; }

        public LongUrlFinder (AppDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        public string findLongUrl(string shortUrl)
        {
            var result = dbContext.Urls.Any(a => a.ShortUrl == shortUrl);
            
            if(result == false ){
                return "";
            }else { 
                return dbContext.Urls.Where(a => a.ShortUrl == shortUrl).Single().LongUrl;
            }
        }
    }
}