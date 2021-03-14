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
            var newPath = GuilPath(file);
            var result = NewPath(newPath);
            if (file.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            var sqlpath = SqlPath(newPath);
            return sqlpath;
        }
        public static void Delete(string path)
        {
            string deletePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{path}");
            File.Delete(deletePath);
        }

        public static string Update(string path, IFormFile file)
        {
            var newPath = GuilPath(file);
            var result = NewPath(newPath);
            string deletePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{path}");
            if (deletePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            
            File.Delete(deletePath);

            var sqlpath = SqlPath(newPath);
            return sqlpath;
        }


        public static string NewPath(string imageName)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");

            return path;

        }

        public static string GuilPath(IFormFile file)
        {

            string imageExtension = Path.GetExtension(file.FileName);

            string imageName = Guid.NewGuid() + imageExtension;

            return imageName;

        }

        public static string SqlPath(string imageName)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"/images/{imageName}");

            return path;
        }

    }
}
