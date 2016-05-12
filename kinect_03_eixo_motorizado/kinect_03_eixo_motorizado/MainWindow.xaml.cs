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

namespace kinect_03_eixo_motorizado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor kinect;

        public MainWindow()
        {
            InitializeComponent();
            kinect = InicializadorKinect.InicializarPrimeiroSensor(0);
        }

        private void AtualizarValores()
        {
            kinect.ElevationAngle = Convert.ToInt32(slider.Value);
            label.Content = kinect.ElevationAngle;
        }

        private void slider_DragCompleted(object sender, EventArgs e)
        {
            AtualizarValores();
        }
    }
}
