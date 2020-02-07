using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shortener.Service; 
using shortener.Models;

namespace shortener.Controllers
{
    [ApiController]
    [Route("/urls")]
    public class ShortUrlCreatorController: ControllerBase
    {
        private UrlMapper urlMapper ; 
        public ShortUrlCreatorController(UrlMapper urlMapper){ 
            this.urlMapper = urlMapper;
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] UrlRequest urlRequest)
        {
            Console.WriteLine("im here!");
            UrlResorce shortUrl = urlMapper.setShortUrl(urlRequest); 
            return Ok(shortUrl); 
        }
    }
}