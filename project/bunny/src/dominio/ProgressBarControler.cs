using System;
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
        private Label label_hambre;
        private Label label_baño;
        private Label label_sueño;
        private Cansancio ani_cansancio;
        private Hambre ani_hambre;
        private Dormir ani_dormir;
        private Canvas cvBunny;
        private Label label_puntuacion;
        private Label label_diversion;

        public ProgressBarControler(
            Label label_hambre, Label label_baño, Label label_sueño,Label label_puntuacion, Label label_diversion,
            Cansancio ani_cansancio, Hambre ani_hambre, Dormir ani_dormir,
            Canvas cvBunny)
        {
            this.label_baño = label_baño;
            this.label_hambre = label_hambre;
            this.label_sueño = label_sueño;
            this.label_puntuacion = label_puntuacion;
            this.label_diversion = label_diversion;

            this.ani_cansancio = ani_cansancio;
            this.ani_hambre = ani_hambre;
            this.ani_dormir = ani_dormir;


            this.cvBunny = cvBunny;
        }
        
        public void update()
        {

            if (Globals.state == 0) { //Cuando esta normal
                if (Globals.ProgressBar_hambre.Value >= 20)
                {
                    setBarBaño(-7); //Si tiene comida entonces puede hacer caca
                }
                if (Globals.ProgressBar_sueño.Value <= 20) Globals.juego_pescar.disableEventLago();
                else Globals.juego_pescar.enableEventLago();
                    setBarHambre(-3);
                        setBarSueño(-1);
                        setBarDiversion(-2);
                        if (Globals.ProgressBar_baño.Value == 0)
                        {
                            new Caca(cvBunny, label_puntuacion);
                            setBarBaño(100);
                        }
                if (Globals.ProgressBar_sueño.Value <= 20)
                {
                    ani_cansancio.cansancioStart();
                    
                }
                else if (Globals.ProgressBar_sueño.Value >= 20 && ani_cansancio.isStarted() == true) ani_cansancio.cansancioStop(); //Si la animaciones esta empezada y no tiene sueño, que se pare
                if (Globals.ProgressBar_hambre.Value <= 20) ani_hambre.hambreStart();
                else if (Globals.ProgressBar_hambre.Value >= 20 && ani_hambre.isStarted() == true) ani_hambre.hambreStop();//Si la animaciones esta empezada y no tiene habmre, que se pare
        

                    }
            
            if (Globals.state == 1 && Globals.juego_pescar.isPlaying() == false){ //Cuando duerme
                setBarSueño(10);
                ani_dormir.cansancioStart();
                if (Globals.ProgressBar_sueño.Value == 100)
                {
                    Globals.state = 0;
                    ani_dormir.cansancioStop();
                }

            }

            if(Globals.state == 2) //Cuando esta pescando
            {
                if (Globals.ProgressBar_hambre.Value >= 20)  setBarBaño(-10);
                setBarHambre(-5);
                setBarSueño(-6);
                setBarDiversion(-2);
            }
        }
        private void updateLabels()
        {
            label_baño.Content = Globals.ProgressBar_baño.Value.ToString() + "%";
            label_hambre.Content = Globals.ProgressBar_hambre.Value.ToString() + "%";
            label_sueño.Content = Globals.ProgressBar_sueño.Value.ToString() + "%";
            label_diversion.Content = Globals.ProgressBar_diversion.Value.ToString() + "%";
            Globals.state_label.Content = "State: "+Globals.state.ToString();
            Globals.label_puntuacion.Content = Globals.score;
        }
        public void setBarBaño(int value)
        {
            Globals.ProgressBar_baño.Value = Globals.ProgressBar_baño.Value + value;
            changeColor(Globals.ProgressBar_baño);
            updateLabels();
        }
        public void setBarHambre(int value)
        {
            Globals.ProgressBar_hambre.Value = Globals.ProgressBar_hambre.Value + value;
            changeColor(Globals.ProgressBar_hambre);
            updateLabels();
        }
        public void setBarSueño(int value)
        {
            Globals.ProgressBar_sueño.Value = Globals.ProgressBar_sueño.Value + value;
            changeColor(Globals.ProgressBar_sueño);
            updateLabels();
        }
        public void setBarDiversion(int value)
        {
            Globals.ProgressBar_diversion.Value = Globals.ProgressBar_diversion.Value + value;
            changeColor(Globals.ProgressBar_diversion);
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
        public void crearCaca()
        {
            new Caca(cvBunny, label_puntuacion);
        }
    }
}
