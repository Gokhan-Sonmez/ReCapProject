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
            var path = GuidPath(file);
            var result = FilePath(path);
            if (file.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            var sqlpath = SqlPath(path);
            return sqlpath;
        }
        public static void Delete(string path)
        {
            string deletePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{path}");
            File.Delete(deletePath);
        }

        public static string Update(string oldPath, IFormFile file)
        {
            var path = GuidPath(file);
            var result = FilePath(path);
            string deletePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{oldPath}");
            if (deletePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            
            File.Delete(deletePath);

            var sqlpath = SqlPath(path);
            return sqlpath;
        }

        public static string GuidPath(IFormFile file)
        {

            string imageExtension = Path.GetExtension(file.FileName);

            string imageName = Guid.NewGuid() + imageExtension;

            return imageName;

        }

        public static string FilePath(string imageName)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");

            return path;

        }

        public static string SqlPath(string imageName)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"/images/{imageName}");

            return path;
        }


    }
}
