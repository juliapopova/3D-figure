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

        Random rnd;
        Color color;
        BoxVisual3D box;
        TruncatedConeVisual3D tr1;
        TruncatedConeVisual3D tr2;

        public void Graphics ()
        {

            box = new BoxVisual3D()
            {
                Height = 3,
                Width = 3,
                Length = 4,
                Center = new Point3D(1,0,0),
                Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)),
            };

            tr1 = new TruncatedConeVisual3D()
            {
                Height = 5,
                Normal = new Vector3D(3, 3, 3),
                BaseRadius = 2,
                Origin = new Point3D(-5, -5, -5),
                Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0)),
            };

            tr2 = new TruncatedConeVisual3D()
            {
                Height = 5,
                Normal = new Vector3D(3, 3, 3),
                BaseRadius = 2,
                Origin = new Point3D(-5, 1, -5),
                Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0)),
            };

            pole.Children.Add(tr1);
            pole.Children.Add(tr2);
            pole.Children.Add(box);
            rnd = new Random();

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void TimerTick (object sender, EventArgs e)
        {
            color = Color.FromRgb(0, (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255));
            box.Fill = new SolidColorBrush(color);
            tr1.Fill = new SolidColorBrush(color);
            tr2.Fill = new SolidColorBrush(color);
        }
    }
}

// установить Nlog
