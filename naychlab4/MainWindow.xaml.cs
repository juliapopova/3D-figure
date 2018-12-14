using HelixToolkit.Wpf;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace naychlab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Graphics();
        }

        Random rnd1, rnd2, rnd3;
        Color color1, color2, color3;
        BoxVisual3D box;

        TruncatedConeVisual3D tr1;
        TruncatedConeVisual3D tr2;

        public void Graphics ()
        {
            
            //параллолепипед
            box = new BoxVisual3D()
            {
                Height = 3,
                Width = 3,
                Length = 4,
                Center = new Point3D(4, 0, 1.5),
                Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)),
            };

            // конус
            tr1 = new TruncatedConeVisual3D()
            {
                Height = 5,
                Normal = new Vector3D(0, 0, 1),
                BaseRadius = 2,
                Origin = new Point3D(-1, 0, 0),
                Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0)),
            };

            //конус
            tr2 = new TruncatedConeVisual3D()
            {
                Height = 5,
                Normal = new Vector3D(0, 0, -1),
                BaseRadius = 2,
                Origin = new Point3D(-6, 0, 5),
                Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0)),
            };

            pole.Children.Add(tr1);
            pole.Children.Add(tr2);
            pole.Children.Add(box);
            rnd1 = new Random();
            rnd2 = new Random();
            rnd3 = new Random();

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void TimerTick (object sender, EventArgs e)
        {
            color1 = Color.FromRgb(0, (byte)rnd1.Next(0, 100), (byte)rnd1.Next(37, 153));
            color2 = Color.FromRgb(0, (byte)rnd2.Next(100, 200), (byte)rnd2.Next(0, 255));
            color3 = Color.FromRgb(0, (byte)rnd3.Next(0, 255), (byte)rnd3.Next(0, 100));
            box.Fill = new SolidColorBrush(color1);
            tr1.Fill = new SolidColorBrush(color2);
            tr2.Fill = new SolidColorBrush(color3);
        }
    }
}

// установить Nlog
