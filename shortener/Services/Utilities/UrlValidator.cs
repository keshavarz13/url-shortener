using System;
using System.Text.RegularExpressions;
using System.Text;

namespace shortener.Service.Utilities
{
    public static class UrlValidator
    {
        public static bool validator(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri validatedUri))
            {
                string reg = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[_.a-z0-9-]+\.[a-z0-9\/_:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
                return Regex.Match(url, reg).Success;
            }
            return false;
        }
    }
}