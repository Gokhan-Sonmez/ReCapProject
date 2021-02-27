using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {

        public static string Add(IFormFile file)
        {
            var result = NewPath(file);
            if (file.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            
            return result;
        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string Update(string path, IFormFile file)
        {
            var result = NewPath(file);
            if (path.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(path);
            return result;
        }


        public static string NewPath(IFormFile file)
        {

            string imageExtension = Path.GetExtension(file.FileName);

            string imageName = Guid.NewGuid() + imageExtension;

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");

            return path;

        }
    }
}
