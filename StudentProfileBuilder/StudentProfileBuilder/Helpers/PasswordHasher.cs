using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace StudentProfileBuilder.Helpers
{
    public static class PasswordHasher
    {
        /// <summary>
        /// Hashes the users password and adds salt to the beginning of it
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string Hasher(string password, string salt)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return salt + builder.ToString();
            }
        }

        /// <summary>
        /// Generates salt for the user
        /// </summary>
        /// <returns></returns>
        public static string Salter()
        {
            Random r = new Random();
            string salt = "";
            string options = "abcdefghijklmnopqrstuvwxyz" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "0123456789";
            for (int i = 0; i < 6; i++)
            {
                salt += options[r.Next(0, options.Length - 1)];
            }
            return salt;
        }
    }
}
