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
using Microsoft.Kinect;
using AuxiliarKinect.FuncoesBasicas;
using System.Windows.Threading;

namespace kinect_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool MaoDireitaAcimaCabeca;
        KinectSensor kinect;

        public MainWindow()
        {
            InitializeComponent();
            kinect = InicializadorKinect.InicializarPrimeiroSensor(0);
            InicializarTimer();
        }

        private void AtualizarValoresAcelerometro()
        {
            Vector4 resultado = kinect.AccelerometerGetCurrentReading();
            labelX.Content = Math.Round(resultado.X, 3);
            labelY.Content = Math.Round(resultado.Y, 3);
            labelZ.Content = Math.Round(resultado.Z, 3);
        }

        private void InicializarTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            AtualizarValoresAcelerometro();
        }
        
    }
}
