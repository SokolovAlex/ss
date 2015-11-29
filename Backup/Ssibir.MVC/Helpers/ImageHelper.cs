using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Ssibir.MVC.Helpers
{
    static class ImageHelper
    {
        static string _path = "Images\\Thumbs";

        static string _rootPath = AppDomain.CurrentDomain.BaseDirectory;

        static public void CreateThumbnail(Stream stream, string id) {
            using (Image source = Image.FromStream(stream, true, true))
            {
                bool isVertical = source.Height > source.Width;
                int width = isVertical ? 50: 80,
                    height = isVertical ? 80: 50;
              
                using (Bitmap resized = (Bitmap)source.GetThumbnailImage(width, height, null, IntPtr.Zero))
                {
                    var name = String.Concat(id, ".jpg");
                    resized.Save(Path.Combine(_rootPath, _path, name), ImageFormat.Jpeg);
                }
            }
      
        }

        static public bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }

            if (file.ContentLength > 1 * 1024 * 1024)
            {
                return false;
            }

            try
            {
                var allowedFormats = new[] 
            { 
                ImageFormat.Jpeg, 
                ImageFormat.Png, 
                ImageFormat.Gif, 
                ImageFormat.Bmp 
            };

                using (var img = Image.FromStream(file.InputStream))
                {
                    return allowedFormats.Contains(img.RawFormat);
                }
            }
            catch { }
            return false;
        }

    }
}