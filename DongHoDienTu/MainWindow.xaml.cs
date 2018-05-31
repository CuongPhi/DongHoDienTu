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

namespace DongHoDienTu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UCDongHo uc = new UCDongHo();

        Button btnCurrent = null;
        public MainWindow()
        {
            InitializeComponent();

            GridUC.Children.Add(uc);
            uc.setTimeClose += new UCDongHo.SetTimeClose(CloseWindow);

        }
        void CloseWindow(bool b)
        {
            if (b)
                Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btnCurrent != null)
            {
                btnCurrent.Background = (Brush)(new BrushConverter()).ConvertFrom("#dddddd");
            }
            btnCurrent = btnStart;
            btnCurrent.Background = Brushes.OrangeRed;
            uc.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (btnCurrent != null)
            {
                btnCurrent.Background = (Brush)(new BrushConverter()).ConvertFrom("#dddddd");
            }
            btnCurrent = btnStop;
            btnCurrent.Background = Brushes.OrangeRed;
            uc.Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (btnCurrent != null)
            {
                btnCurrent.Background = (Brush)(new BrushConverter()).ConvertFrom("#dddddd");
            }
            btnCurrent = btnResu;
            btnCurrent.Background = Brushes.OrangeRed;
            uc.Resume();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (btnCurrent != null)
            {
                btnCurrent.Background = (Brush)(new BrushConverter()).ConvertFrom("#dddddd");
            }
            btnCurrent = btnPause;
            btnCurrent.Background = Brushes.OrangeRed;
            uc.Pause();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //bool flag = false;
            //if( btnCurrent != null )
            //{
            //    if(btnCurrent.Name == "btnStop")
            //         flag = true;            
            //}
            //else
            //{
            //    flag = true;
              
            //}
            //if (flag)
            //{
                int seconds = int.Parse(((ComboBoxItem)(cbbMinu2.SelectedItem)).Content.ToString()) +
                            int.Parse(((ComboBoxItem)(cbbMinu1.SelectedItem)).Content.ToString()) * 10;
                int minutes = int.Parse(((ComboBoxItem)(cbbSec2.SelectedItem)).Content.ToString()) +
                    int.Parse(((ComboBoxItem)(cbbSec1.SelectedItem)).Content.ToString()) * 10;
                uc.Close(minutes, seconds);
            lbSetTimeClose.Content = string.Format("Thoát {0}:{1}",minutes,seconds);
            lbSetTimeClose.Foreground = Brushes.Red;
            //}
            //else
            //{
            //    MessageBox.Show("Cài giờ tắt khi đồng hồ không chạy !");
            //}
        }


    }
}
