using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shortener.Service;
using shortener.Models;
using System.Web;

namespace shortener.Controllers
{
    [ApiController]
    [Route("redirect")]
    public class RedirectController : ControllerBase
    {
        private LongUrlFinder longUrlFinder;
        public RedirectController(LongUrlFinder longUrlFinder)
        {
            this.longUrlFinder = longUrlFinder;
        }

        [HttpGet]
        [Route("{term}")]
        public ActionResult Get(string term)
        {
            string longUrl = longUrlFinder.findLongUrl(term);
            if (longUrl == "")
            {
                return BadRequest();
            }
            else
            {
                return Redirect(HttpUtility.UrlPathEncode(longUrl));
            }
        }
    }
}