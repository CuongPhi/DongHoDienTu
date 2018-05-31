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
    /// Interaction logic for UCDongHo.xaml
    /// </summary>
    public partial class UCDongHo : UserControl
    {
        private Status sst = Status.Stop;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private int seconds = 0;
        private int minutes = 0;
        private int sec_close = 99;
        private int min_close = 99;
        public delegate void SetTimeClose(bool b);
        public SetTimeClose setTimeClose;
        public UCDongHo()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            SetDefault();

        }

        public void Close(int m, int s)
        {
            sec_close = s;
            min_close =m;           
        }
        void SetDefault()
        {
            SetImage(_0, "0");
            SetImage(_1, "0");
            SetImage(_2, "-");
            SetImage(_3, "0");
            SetImage(_4, "0");
        }
        public void Pause()
        {
            if (sst == Status.Start)
            {
                dispatcherTimer.Stop();
                sst = Status.Pause;
            }
        }
        public void Resume()
        {
            if (sst == Status.Pause)
            {
                dispatcherTimer.Start();
                sst = Status.Start;
            }
        }
        public void Stop()
        {
            sst = Status.Stop;
            SetDefault();
            seconds = minutes = 0;
            dispatcherTimer.Stop();
        }
        public void Start()
        {
            sst = Status.Start;
            seconds = minutes = 0;
            dispatcherTimer.Start();
        }
        void SetImage(Image im, string path)
        {
            im.Source = new BitmapImage(new Uri("pack://application:,,,/DongHoDienTu;component/" + path+".png"));
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (minutes == min_close && sec_close == seconds)
            {
                setTimeClose(true);
            }
            if (minutes == 59 && seconds == 60)
            {
                dispatcherTimer.Stop();
                return;
            }
            if (seconds % 60 == 0)
            {
                minutes++;
            }
            if (minutes % 10==0)
            {
                SetImage(_0, (minutes / 10).ToString());

            }
            SetImage(_1, (minutes % 10).ToString());
            if (seconds == 60)
            {
                seconds = 0;
            }
            if (seconds % 10==0)
            {
                SetImage(_3, (seconds / 10).ToString());              

            }
            SetImage(_4, (seconds % 10).ToString());
            

        }
    }
    public enum Status
    {
        Start, Stop, Pause
    }
}
