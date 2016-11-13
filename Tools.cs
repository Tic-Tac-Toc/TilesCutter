using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TilesCutter
{
    public static class Tools
    {
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static void SaveCropped(Window window, int x, int y, int sizeX, int sizeY, int dpi, string filename)
        {

            var rtb = new RenderTargetBitmap(
                (int)window.Width, //width 
                (int)window.Height, //height 
                dpi, //dpi x 
                dpi, //dpi y 
                PixelFormats.Pbgra32 // pixelformat 
                );
            rtb.Render(window);
            var crop = new CroppedBitmap(rtb, new Int32Rect(x, y, sizeX, sizeY));
            BitmapEncoder encoder;

            switch(AppConfig.ImgEncoder)
            {
                case Encoder.PNG:
                    encoder = new PngBitmapEncoder();
                    break;
                case Encoder.GIF:
                    encoder = new GifBitmapEncoder();
                    break;
                case Encoder.BMP:
                    encoder = new BmpBitmapEncoder();
                    break;
                case Encoder.JPG:
                    encoder = new JpegBitmapEncoder();
                    break;
                default:
                    encoder = new PngBitmapEncoder();
                    break;
            }
            encoder.Frames.Add(BitmapFrame.Create(crop));

            using (var fs = System.IO.File.OpenWrite(Path.Combine(path, "tiles", filename +"."+ AppConfig.ImgEncoder)))
            {
                encoder.Save(fs);
            }
        }
    }
}
