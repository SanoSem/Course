using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System;

namespace Сursova.Services
{
    public static class ImageHelper
    {
        private static readonly string ImagesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

        static ImageHelper()
        {
            if (!Directory.Exists(ImagesDirectory))
            {
                Directory.CreateDirectory(ImagesDirectory);
            }
        }

        public static string SaveImage(Image image, string fileName)
        {
            if (image == null)
                return string.Empty;

            string filePath = Path.Combine(ImagesDirectory, fileName);
            image.Save(filePath, ImageFormat.Jpeg);
            return filePath;
        }

        public static Image LoadImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                return null;
            }

            using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(fs);
            }
        }

        public static Image ResizeImage(Image image, int width, int height)
        {
            if (image == null)
                return null;

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static string GetUniqueFileName(string originalFileName)
        {
            string extension = Path.GetExtension(originalFileName);
            return Guid.NewGuid().ToString() + extension;
        }

        public static void DeleteImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    File.Delete(imagePath);
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Помилка видалення файлу {imagePath}: {ex.Message}");
                }
            }
        }
    }
}