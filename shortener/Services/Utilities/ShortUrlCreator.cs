using System;
using System.Text;

namespace shortener.Service.Utilities
{
    public static class ShortUrlCreator
    {
        public static string GenerateShortUrl()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 8; i++)
            {
                int choose = Convert.ToInt32(Math.Floor(2 * random.NextDouble()));
                if (choose == 1)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                }
                else
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 97)));
                }
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}