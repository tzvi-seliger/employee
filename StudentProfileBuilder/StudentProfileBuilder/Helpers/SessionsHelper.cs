using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProfileBuilder.Helpers
{
    public static class SessionsHelper
    {
        public static string GenerateCookie()
        {
            Random r = new Random();
            string options = "abcdefghijklmnopqrstuvwxyz" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "0123456789";
            string cookie = "";

            for (int i = 0; i < 32; i++)
            {
                cookie += options[r.Next(0, options.Length - 1)];
            }
            return cookie;
        }
    }
}
