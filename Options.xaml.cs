using System.Windows;
using TilesCutter.Properties;

namespace TilesCutter
{
    /// <summary>
    /// Logique d'interaction pour Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (jpg.IsChecked == true)
            {
                AppConfig.ImgEncoder = Encoder.JPG;
                Settings.Default.Encoder = (int)Encoder.JPG;
            }
            else if (png.IsChecked == true)
            {
                AppConfig.ImgEncoder = Encoder.PNG;
                Settings.Default.Encoder = (int)Encoder.PNG;
            }
            else if (gif.IsChecked == true)
            {
                AppConfig.ImgEncoder = Encoder.GIF;
                Settings.Default.Encoder = (int)Encoder.GIF;
            }
            else if (bmp.IsChecked == true)
            {
                AppConfig.ImgEncoder = Encoder.BMP;
                Settings.Default.Encoder = (int)Encoder.BMP;
            }
            Settings.Default.Save();

            MessageBox.Show("Configuration updated.");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (AppConfig.ImgEncoder)
            {
                case Encoder.PNG:
                    png.IsChecked = true;
                    break;
                case Encoder.GIF:
                    gif.IsChecked = true;
                    break;
                case Encoder.BMP:
                    bmp.IsChecked = true;
                    break;
                case Encoder.JPG:
                    jpg.IsChecked = true;
                    break;
                default:
                    jpg.IsChecked = true;
                    break;
            }
        }
    }
}
