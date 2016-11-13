using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using TilesCutter.Properties;

namespace TilesCutter
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage img;
        Preview preview;

        public MainWindow()
        {
            InitializeComponent();
            AppConfig.ImgEncoder = (Encoder)Settings.Default.Encoder;
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            
            Nullable<bool> result = dlg.ShowDialog();


            if (result == true)
            {
                img = new BitmapImage(new Uri(dlg.FileName));
                imgTextbox.Text = "Selected image : " + dlg.SafeFileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (img == null)
                return;
            if (preview != null)
                preview.Close();

            preview = new Preview(img, (bool)fixedSizeRB.IsChecked, xScale.NumValue, yScale.NumValue);
            preview.Show();
        }

        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
            if (preview != null)
                preview.Save();
        }

        private void btnTools_Click(object sender, RoutedEventArgs e)
        {
            Options opt = new Options();
            opt.Show();
        }
    }
}
