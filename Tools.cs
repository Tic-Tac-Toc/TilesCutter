using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TilesCutter
{
    public static class Tools
    {
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static void SaveWindow(Window window, int dpi, string filename)
        {

            var rtb = new RenderTargetBitmap(
                (int)window.Width, //width 
                (int)window.Height, //height 
                dpi, //dpi x 
                dpi, //dpi y 
                PixelFormats.Pbgra32 // pixelformat 
                );
            rtb.Render(window);

            SaveRTBAsPNG(rtb, filename);

        }

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
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(crop));

            using (var fs = System.IO.File.OpenWrite(Path.Combine(path, "tiles", filename)))
            {
                pngEncoder.Save(fs);
            }
        }

        private static void SaveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));

            using (var stm = System.IO.File.Create(Path.Combine(path, "tiles", filename)))
            {
                enc.Save(stm);
            }
        }
    }
}
