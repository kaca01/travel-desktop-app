using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TravelApp.Core
{
    public class ImageConverter{

        private static Bitmap ConvertImageSourceToBitmap(ImageSource imageSource)
        {
            Bitmap bitmap;
            var encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource as BitmapSource));
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                bitmap = new Bitmap(stream);
            }
            return bitmap;
        }

        private static byte[] ConvertBitmapToArray(Bitmap bitmap)
        {
            Console.WriteLine("lalal");
            byte[] imageBytes;
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                imageBytes = stream.ToArray();
            }
            return imageBytes;
        }

        public static byte[] ConvertImageSourceToByteArray(ImageSource imageSource) 
        {
            byte[] imageBytes;
            var encoder = new PngBitmapEncoder();  // Choose an appropriate encoder based on the image format
            encoder.Frames.Add(BitmapFrame.Create(imageSource as BitmapSource));
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                imageBytes = stream.ToArray();
            }
            return imageBytes;
        }

        public static BitmapImage LoadPicture(byte[] imageData)
        {
            if (IsByteArrayAllZeros(imageData))
                imageData = ConvertImageToByteArray();
            using (MemoryStream memoryStream = new MemoryStream(imageData))
            {
                // Create a new BitmapImage
                BitmapImage bitmapImage = new BitmapImage();

                // Set the MemoryStream as the source of the BitmapImage
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                // Set the BitmapImage as the source of the Image control
                return bitmapImage;
            }
        }

        public static byte[] ConvertImageToByteArray()
        {
            Image image = Image.FromFile("../../../Style/Images/trip.png");
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Change the format if needed
                return ms.ToArray();
            }
        }
        private static bool IsByteArrayAllZeros(byte[] byteArray)
        {
            for (int i = 0; i < byteArray.Length; i++)
            {
                if (byteArray[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
