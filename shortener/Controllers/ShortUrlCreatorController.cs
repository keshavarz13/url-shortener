using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shortener.Service;
using shortener.Models;
using shortener.Service.Utilities;

namespace shortener.Controllers
{
    [ApiController]
    [Route("/urls")]
    public class ShortUrlCreatorController : ControllerBase
    {
        private UrlMapper urlMapper;
        public ShortUrlCreatorController(UrlMapper urlMapper)
        {
            this.urlMapper = urlMapper;
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] UrlRequest urlRequest)
        {
            string longUrl;
            if (!(urlRequest.LongUrl.StartsWith("http://") || urlRequest.LongUrl.StartsWith("https://") || urlRequest.LongUrl.StartsWith("ftp://") || urlRequest.LongUrl.StartsWith("file://")))
            {
                longUrl = "http://" + urlRequest.LongUrl;
            }
            else
            {
                longUrl = urlRequest.LongUrl;
            }
            Console.WriteLine("im here!");
            if (UrlValidator.validator(longUrl))
            {
                UrlRequest request = new UrlRequest()
                {
                    LongUrl = longUrl
                };
                UrlResorce shortUrl = urlMapper.setShortUrl(request);
                return Ok(shortUrl);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}