﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bunny.src.presentacion;
using System.Collections;
using System.Windows.Threading;

using bunny.src.dominio;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using bunny.src.presentacion.animations;
using bunny.src.presentacion.objects_img;
using System.Windows.Media;

namespace bunny.src.dominio

{
    class ProgressBarControler : Observador
    {
        private ProgressBar ProgressBar_hambre;
        private ProgressBar ProgressBar_baño;
        private ProgressBar ProgressBar_sueño;
        private Label label_hambre;
        private Label label_baño;
        private Label label_sueño;
        private Cansancio ani_cansancio;
        private Hambre ani_hambre;
        private Canvas cvBunny;
        private Label label_puntuacion;

        public ProgressBarControler(ProgressBar ProgressBar_hambre, ProgressBar ProgressBar_baño, ProgressBar ProgressBar_sueño,
            Label label_hambre, Label label_baño, Label label_sueño,Label label_puntuacion,
            Cansancio ani_cansancio, Hambre ani_hambre,
            Canvas cvBunny)
        {
            this.ProgressBar_baño = ProgressBar_baño;
            this.ProgressBar_hambre = ProgressBar_hambre;
            this.ProgressBar_sueño = ProgressBar_sueño;

            this.label_baño = label_baño;
            this.label_hambre = label_hambre;
            this.label_sueño = label_sueño;
            this.label_puntuacion = label_puntuacion;

            this.ani_cansancio = ani_cansancio;
            this.ani_hambre = ani_hambre;

            this.cvBunny = cvBunny;
        }
        
        public void update()
        {
            if (Globals.state == 0) { 
                if(ProgressBar_hambre.Value >= 20) setBarBaño(-9); //Si tiene comida entonces puede hacer caca
                setBarHambre(-3);
                setBarSueño(-1);

                if (ProgressBar_baño.Value == 0)
                {
                    new Caca(cvBunny,label_puntuacion);
                    setBarBaño(100);
                }
                if (ProgressBar_sueño.Value <= 20) ani_cansancio.cansancioStart();
                else if (ProgressBar_sueño.Value >= 20 && ani_cansancio.isStarted() == true) ani_cansancio.cansancioStop(); //Si la animaciones esta empezada y no tiene sueño, que se pare
                if (ProgressBar_hambre.Value <= 20) ani_hambre.hambreStart();
                else if (ProgressBar_hambre.Value >= 20 && ani_hambre.isStarted() == true) ani_hambre.hambreStop();//Si la animaciones esta empezada y no tiene habmre, que se pare
            }
            if (Globals.state == 1){
                setBarSueño(10);
                if (ProgressBar_sueño.Value == 100) Globals.state = 0;
            }
        }
        private void updateLabels()
        {
            label_baño.Content = ProgressBar_baño.Value.ToString() + "%";
            label_hambre.Content = ProgressBar_hambre.Value.ToString() + "%";
            label_sueño.Content = ProgressBar_sueño.Value.ToString() + "%";
        }
        public void setBarBaño(int value)
        {
               ProgressBar_baño.Value = ProgressBar_baño.Value + value;
            changeColor(ProgressBar_baño);
            updateLabels();
        }
        public void setBarHambre(int value)
        {
            ProgressBar_hambre.Value = ProgressBar_hambre.Value + value;
            changeColor(ProgressBar_hambre);
            updateLabels();
        }
        public void setBarSueño(int value)
        {
            ProgressBar_sueño.Value = ProgressBar_sueño.Value + value;
            changeColor(ProgressBar_sueño);
            updateLabels();
        }
        private bool comprobarInput(int value,int valueBar)
        {
            if (value + valueBar > 100 || value + valueBar < 0) return false;
            return true;
        }
        private void changeColor(ProgressBar a)
        {
            if (a.Value >= 70) a.Foreground = Brushes.Green;
            else if (a.Value >= 60) a.Foreground = Brushes.YellowGreen;
            else if (a.Value >= 30) a.Foreground = Brushes.GreenYellow;
            else if (a.Value >= 25) a.Foreground = Brushes.Orange;
            else if (a.Value >= 15) a.Foreground = Brushes.DarkOrange;
            else if (a.Value >= 10) a.Foreground = Brushes.OrangeRed;
            else a.Foreground = Brushes.Red;
        }
    }
}
