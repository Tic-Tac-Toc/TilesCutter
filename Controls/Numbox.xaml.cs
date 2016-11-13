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

namespace TilesCutter.Controls
{
    /// <summary>
    /// Logique d'interaction pour Numbox.xaml
    /// </summary>
    public partial class Numbox : UserControl
    {
        private int _numValue = 0;
        private int _min = 0;
        private int _max = 99999999;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = value.ToString();
            }
        }

        private void AddOne()
        {
            if (NumValue + 1 <= _max)
                NumValue++;
        }
        private void RemoveOne()
        {
            if (NumValue - 1 >= _min)
                NumValue--;
        }

        public Numbox()
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            AddOne();
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            RemoveOne();
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
                return;

            int i;
            if (!int.TryParse(txtNum.Text, out i))
                txtNum.Text = _numValue.ToString();
            NumValue = i;
        }

        private void txtNum_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNum.SelectAll();
        }

        private void txtNum_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta == 120)
                AddOne();
            else if (e.Delta == -120)
                RemoveOne();
        }
    }
}
