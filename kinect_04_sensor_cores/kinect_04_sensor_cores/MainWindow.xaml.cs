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

namespace kinect_04_sensor_cores
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
            kinect = InicializadorKinect.InicializarPrimeiroSensor(10);
            kinect.ColorStream.Enable();
        }

        private BitmapSource ObterImagemSensorRGB(ColorImageFrame quadro)
        {
            using(quadro)
            {
                byte[] bytesImagem = new byte[quadro.PixelDataLength];
                quadro.CopyPixelDataTo(bytesImagem);

                return BitmapSource.Create(quadro.Width, quadro.Height, 96, 96, PixelFormats.Bgr32, null, bytesImagem, quadro.Width * quadro.BytesPerPixel);
            }
        }

        private void Button_BaterFoto(object sender, EventArgs e)
        {
            imagemCamera.Source = ObterImagemSensorRGB(kinect.ColorStream.OpenNextFrame(0));
        }
    }
}
