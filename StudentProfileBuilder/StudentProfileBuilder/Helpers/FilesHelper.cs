using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace StudentProfileBuilder.Helpers
{
    public static class FilesHelper
    {
        public static string CreateUserDirectory(string username)
        {
            string folderName = $@"wwwroot\users\{username}";
            Directory.CreateDirectory(folderName);
            return folderName;
        }

        /// <summary>
        /// Places a user's uploaded file into their directory
        /// </summary>
        /// <param name="file"></param>
        /// <param name="username"></param>
        public static string PlaceFileInDirectory(IFormFile file, string username)
        {
            string filePath = $@"wwwroot\users\{username}";

            if (file.Length > 0)
            {
                int extensionIndex = file.ContentType.IndexOf('/');
                string extension = "." + file.ContentType.Substring(extensionIndex+1);
                string fileName = "";

                //Adjusts the file name based on file type
                if(file.ContentType.Contains("image"))
                {
                    fileName = $"{username}_profileimg" + extension;
                }
                else if (file.ContentType.Contains("application"))
                {
                    fileName = $"{username}_resume" + extension;
                }

                //Combines our file path with our file name and inserts it into a user's directory
                string fullFilePath = Path.Combine(filePath, fileName);
                using (FileStream fileStream = new FileStream(fullFilePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return $"../users/{username}/{fileName}";
            }
            return "";
        }
    }
}
