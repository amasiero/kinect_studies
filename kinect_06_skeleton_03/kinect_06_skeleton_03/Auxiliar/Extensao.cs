﻿using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;


namespace Auxiliar
{
    public static class Extensao
    {
        public static void DesenharEsqueletoUsuario(this SkeletonFrame quadro, KinectSensor kinectSensor, Canvas canvasParaDesenhar)
        {
            if (kinectSensor == null) throw new ArgumentNullException("kinectSensor");
            if (canvasParaDesenhar == null) throw new ArgumentNullException("canvasParaDesenhar");

            Skeleton esqueleto = ObterEsqueletoUsuario(quadro);

            if (esqueleto != null)
            {
                EsqueletoUsuarioAuxiliar esqueletoUsuarioAuxiliar = new EsqueletoUsuarioAuxiliar(kinectSensor);

                foreach (BoneOrientation bone in esqueleto.BoneOrientations)
                {
                    esqueletoUsuarioAuxiliar.DesenharOsso(esqueleto.Joints[bone.StartJoint], esqueleto.Joints[bone.EndJoint], canvasParaDesenhar);
                    esqueletoUsuarioAuxiliar.DesenharArticulacao(esqueleto.Joints[bone.EndJoint], canvasParaDesenhar);
                }
                    
            }
        }

        public static Skeleton ObterEsqueletoUsuario (this SkeletonFrame quadro)
        {
            Skeleton esqueletoUsuario = null;
            Skeleton[] esqueletos = new Skeleton[quadro.SkeletonArrayLength];

            quadro.CopySkeletonDataTo(esqueletos);

            IEnumerable<Skeleton> esqueletosRastreados = esqueletos.Where(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (esqueletosRastreados.Count() > 0) esqueletoUsuario = esqueletosRastreados.First();

            return esqueletoUsuario;
        }
    }
}