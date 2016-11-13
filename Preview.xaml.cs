using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TilesCutter
{
    /// <summary>
    /// Logique d'interaction pour Preview.xaml
    /// </summary>
    public partial class Preview : Window
    {
        int lines;
        int columns;

        int sizeX;
        int sizeY;

        public Preview(BitmapImage img, bool fixedSize, int scaleX, int scaleY)
        {
            InitializeComponent();
            Width = img.PixelWidth;
            Height = img.PixelHeight;
            image.Source = img;

            sizeX = scaleX;
            sizeY = scaleY;

            if (fixedSize)
                PreviewCutFixedSize(scaleX, scaleY);
            else
                PreviewCutCellCount(scaleX, scaleY);
        }

        private void PreviewCutFixedSize(int sizeX, int sizeY)
        {
            columns = (int)Math.Floor(Width / sizeX);
            for (int i = 1; i <= columns; i++)
            {
                Line line = new Line();
                line.X1 = i * sizeX;
                line.Y1 = 0;
                line.X2 = i * sizeX;
                line.Y2 = Height;
                line.StrokeThickness = 1;
                line.Stroke = new SolidColorBrush(Colors.Black);
                grid.Children.Add(line);
            }
            lines = (int)Math.Floor(Height / sizeY);
            for (int i = 1; i <= lines; i++)
            {
                Line line = new Line();
                line.X1 = 0;
                line.Y1 = i * sizeY;
                line.X2 = Width;
                line.Y2 = i * sizeY;
                line.StrokeThickness = 1;                
                line.Stroke = new SolidColorBrush(Colors.Black);
                grid.Children.Add(line);
            }
        }
        private void PreviewCutCellCount(int cellX, int cellY)
        {
            sizeX = (int)Math.Floor(Width / cellX);
            sizeY = (int)Math.Floor(Height / cellY);
            PreviewCutFixedSize(sizeX, sizeY);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Q)
                Close();
        }

        public void Save()
        {
            foreach (UIElement element in grid.Children)
                if (element is Line)
                    element.Opacity = 0;
            for (int i = 0; i < columns; i++)
                for (int j = 0; j < lines; j++)
                    Tools.SaveCropped(this, sizeX * i, sizeY * j, sizeX, sizeY, 96, string.Format("{0}{1}", j, i));
            MessageBox.Show("Tiles saved.");
            foreach (UIElement element in grid.Children)
                if (element is Line)
                    element.Opacity = 1.0;
        }
    }
}
