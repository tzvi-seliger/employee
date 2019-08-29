using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentProfileBuilder.Models;
using System.Net.Mail;
using System.Net;

namespace StudentProfileBuilder.Helpers
{
    public static class InvitationsHelper
    {
        /// <summary>
        /// Generates an invitation code
        /// </summary>
        /// <returns></returns>
        public static string CodeGenerator()
        {
            Random r = new Random();
            string options = "abcdefghijklmnopqrstuvwxyz" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "0123456789";
            string code = "";

            for(int i = 0; i < 16; i++)
            {
                code += options[r.Next(0, options.Length - 1)];
            }
            return code;
        }

        /// <summary>
        /// Sends a code to users to let them sign up
        /// </summary>
        /// <param name="inv"></param>
        public static void SendEmail(Invitation inv)
        {
            MailMessage mail = new MailMessage("TestEmail1994005@gmail.com", inv.Email);
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                mail.Subject = "Your invite code for TechdIn!";
                mail.Body = $"Click on the following link and sign-up to begin using our site! https://exampleURL?invKey={inv.InvKey}";
                client.Credentials = new NetworkCredential("TestEmail1994005@gmail.com", "TEchyb0is12$");
                client.EnableSsl = true;
                client.Send(mail);
            }

        }
    }
}
