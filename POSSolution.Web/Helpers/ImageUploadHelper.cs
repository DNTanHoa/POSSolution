using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace POSSolution.Web.Helpers
{
    public class ImageUploadHelper
    {
        public static async Task<string> ImageUpload(IFormFile file, IWebHostEnvironment _env)
        {
            var imagePath = @"\Upload\Images\";
            var uploadPath = _env.WebRootPath + imagePath;

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var uniqFileName = Guid.NewGuid().ToString();
            var fileName = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
            string fullPath = uploadPath + fileName;
            imagePath = imagePath + @"\";
            var filePath = @".." + Path.Combine(imagePath, fileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
