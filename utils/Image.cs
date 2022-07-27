using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SD_Scope.utils
{
    public class Image
    {
        //This static method is for converting bitmap to BitmapImage
        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        public static Bitmap applyFilter(Prefs prefs, Bitmap bmp)
        {
            Bitmap filteredImage = null;
            //Check which filter selected by user
            if (prefs.Find("filter") == "Gamma")
            {


                //Convert bitmap to image class
                Image<Bgr, byte> image = bmp.ToImage<Bgr, byte>();

                //Apply gamma filter param to image
                image._GammaCorrect(double.Parse(prefs.Find("gamma")));

                //Reverse to bitmap
                filteredImage = image.ToBitmap<Bgr, byte>();


            }
            else if (prefs.Find("filter") == "Contrast")
            {
                //Convert bitmap to image class
                Image<Bgr, byte> image = bmp.ToImage<Bgr, byte>();


                //Apply Contrast filter with alpha and beta params;
                image = image.ConvertScale<byte>(double.Parse(prefs.Find("contrast_alpha")), double.Parse(prefs.Find("contrast_beta")));

                //Reverse to bitmap
                filteredImage = image.ToBitmap<Bgr, byte>();


            }
            else if (prefs.Find("filter") == "Histogram")
            {
                //Convert bitmap to image class
                Image<Bgr, byte> image = bmp.ToImage<Bgr, byte>();

                Mat output = new Mat();
                //Apply Histogram filter with related params;
                CvInvoke.CLAHE(bmp.ToImage<Gray, byte>(), double.Parse(prefs.Find("histogram_ClipLimit")), new System.Drawing.Size(
                    int.Parse(prefs.Find("histogram_GridSize")), int.Parse(prefs.Find("histogram_GridSize"))), output);

                //Reverse to bitmap
                filteredImage = output.ToBitmap();


            }
            else if (prefs.Find("filter") == "Sobel")
            {
                //Convert bitmap to image class
                Image<Gray, byte> image = bmp.ToImage<Gray, byte>();


                //Apply Sobel filter with related params;



                //Convert bitmap to image class
                image = bmp.ToImage<Gray, byte>();

                //Convert image to gray based on sobel_diff first apply to x param and second apply to y param
                Image<Gray, float> gray_x = image.Sobel(int.Parse(prefs.Find("sobel_diff")), 0, int.Parse(prefs.Find("sobel_GridSize")));
                Image<Gray, float> gray_y = image.Sobel(0, int.Parse(prefs.Find("sobel_diff")), int.Parse(prefs.Find("sobel_GridSize")));

                //Power 2 each pixel
                CvInvoke.Pow(gray_x, 2, gray_x);
                CvInvoke.Pow(gray_y, 2, gray_y);


                //Add two images
                CvInvoke.Add(gray_x, gray_y, gray_x);

                //Apply Sqrt
                CvInvoke.Sqrt(gray_x, gray_x);

                //Apply BitwiseNot on result
                CvInvoke.BitwiseNot(gray_x, gray_x);

                //Reverse to bitmap
                filteredImage = gray_x.ToBitmap();


            }
            return filteredImage;
        }
    }
}
