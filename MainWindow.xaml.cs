using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            preview = new Preview(img, (bool)fixedSizeRB.IsChecked, xScale.NumValue, yScale.NumValue);
            preview.Show();
        }

        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
            if (preview != null)
                preview.Save();
        }
    }
}
