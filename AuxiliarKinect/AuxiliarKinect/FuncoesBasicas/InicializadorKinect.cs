using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;


namespace AuxiliarKinect.FuncoesBasicas
{
    public class InicializadorKinect
    {
        public Action<KinectSensor> MetodoInicializadorKinect { get; set; }
        public KinectSensorChooser SeletorKinect { get; private set; }

        public InicializadorKinect()
        {
            SeletorKinect = new KinectSensorChooser();
            SeletorKinect.KinectChanged += SeletorKinect_KinectChanged;
            SeletorKinect.Start();
        }

        private void SeletorKinect_KinectChanged(object sender, KinectChangedEventArgs kinectArgs)
        {
            if(kinectArgs.OldSensor != null)
            {
                try
                {
                    if (kinectArgs.OldSensor.DepthStream.IsEnabled)
                        kinectArgs.OldSensor.DepthStream.Disable();

                    if (kinectArgs.OldSensor.SkeletonStream.IsEnabled)
                        kinectArgs.OldSensor.SkeletonStream.Disable();

                    if (kinectArgs.OldSensor.ColorStream.IsEnabled)
                        kinectArgs.OldSensor.ColorStream.Disable();
                }
                catch(InvalidOperationException)
                {

                }
            }

            if(kinectArgs.NewSensor != null)
            {
                if (MetodoInicializadorKinect != null)
                    MetodoInicializadorKinect(SeletorKinect.Kinect);
            }
        }
    }
}
