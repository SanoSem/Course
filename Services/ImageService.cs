using System.Drawing;
using System.IO;
using System;

namespace Сursova.Services
{
    public class ImageService
    {
        private readonly string _artistsImagesPath;
        private readonly string _paintingsImagesPath;

        public ImageService()
        {
            _artistsImagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Artists");
            _paintingsImagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Paintings");

            if (!Directory.Exists(_artistsImagesPath))
            {
                Directory.CreateDirectory(_artistsImagesPath);
            }
            if (!Directory.Exists(_paintingsImagesPath))
            {
                Directory.CreateDirectory(_paintingsImagesPath);
            }
        }

        public string SaveArtistPhoto(Image photo, string originalFileName)
        {
            if (photo == null) return string.Empty;

            string uniqueFileName = ImageHelper.GetUniqueFileName(originalFileName);
            string filePath = Path.Combine(_artistsImagesPath, uniqueFileName);

            // Зберігає зображення за допомогою ImageHelper
            photo.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            return filePath;
        }

        public Image LoadArtistPhoto(string imagePath)
        {
            return ImageHelper.LoadImage(imagePath);
        }

        public void DeleteArtistPhoto(string imagePath)
        {
            ImageHelper.DeleteImage(imagePath);
        }

        public string SavePaintingImage(Image image, string originalFileName)
        {
            if (image == null) return string.Empty;

            string uniqueFileName = ImageHelper.GetUniqueFileName(originalFileName);
            string filePath = Path.Combine(_paintingsImagesPath, uniqueFileName);

            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            return filePath;
        }

        public Image LoadPaintingImage(string imagePath)
        {
            return ImageHelper.LoadImage(imagePath);
        }

        public void DeletePaintingImage(string imagePath)
        {
            ImageHelper.DeleteImage(imagePath);
        }
    }
}