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
        private ProgressBar ProgressBar_hambre;
        private ProgressBar ProgressBar_baño;
        private ProgressBar ProgressBar_sueño;
        private Label label_hambre;
        private Label label_baño;
        private Label label_sueño;
        private Suciedad ani_suciedad;
        private Cansancio ani_cansancio;
        private Hambre ani_hambre;
        private Canvas cvBunny;
        private Storyboard sbSuciedad;
        private Label label_puntuacion;

        public ProgressBarControler(ProgressBar ProgressBar_hambre, ProgressBar ProgressBar_baño, ProgressBar ProgressBar_sueño,
            Label label_hambre, Label label_baño, Label label_sueño,Label label_puntuacion,
            Suciedad ani_suciedad,Cansancio ani_cansancio, Hambre ani_hambre,
            Canvas cvBunny,
            Storyboard sbSuciedad)
        {
            this.ProgressBar_baño = ProgressBar_baño;
            this.ProgressBar_hambre = ProgressBar_hambre;
            this.ProgressBar_sueño = ProgressBar_sueño;

            this.label_baño = label_baño;
            this.label_hambre = label_hambre;
            this.label_sueño = label_sueño;
            this.label_puntuacion = label_puntuacion;

            this.ani_suciedad = ani_suciedad;
            this.ani_cansancio = ani_cansancio;
            this.ani_hambre = ani_hambre;

            this.cvBunny = cvBunny;

            this.sbSuciedad = sbSuciedad;
        }
        
        public void update()
        {
            if (Globals.state == 0) { 
                setBarBaño(-30);
                setBarHambre(-2);
                setBarSueño(-10);

                if (ProgressBar_baño.Value == 10)
                {
                    new Caca(cvBunny,sbSuciedad,label_puntuacion);
                    ani_suciedad.suciedadStart();
                    setBarBaño(100);
                }
                if (ProgressBar_sueño.Value == 10) ani_cansancio.cansancioStart();
                if (ProgressBar_hambre.Value == 10) ani_hambre.hambreStart();
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
            if (ProgressBar_baño.Value >= 50) ProgressBar_baño.Foreground = Brushes.Green;
            else if (ProgressBar_baño.Value >= 30) ProgressBar_baño.Foreground = Brushes.YellowGreen;
            else ProgressBar_baño.Foreground= Brushes.Red;
            updateLabels();
        }
        public void setBarHambre(int value)
        {
            ProgressBar_hambre.Value = ProgressBar_hambre.Value + value;
            updateLabels();
        }
        public void setBarSueño(int value)
        {
            ProgressBar_sueño.Value = ProgressBar_sueño.Value + value;
            updateLabels();
        }
        private bool comprobarInput(int value,int valueBar)
        {
            if (value + valueBar > 100 || value + valueBar < 0) return false;
            return true;
        }
    }
}
