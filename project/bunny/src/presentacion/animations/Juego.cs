using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace bunny.src.presentacion.animations
{
    public class Juego
    {
        private Storyboard ani_juego;
        private bool playing;
        private bool canplay;

        public Juego(Storyboard ani_juego)
        {
            this.ani_juego = ani_juego;
            this.playing = false;
            this.canplay = false;
            Globals.cvLago.MouseDown += cvLago_MouseDown;
        }

        public void juegoStart()
        {
            ani_juego.Begin();
            this.playing = true;
            enableEventsPez();
            Globals.state = 2;
            disableEventLago();

        }

        public void juegoStop()
        {
            ani_juego.Stop();
            this.playing = false;
            this.canplay = false;
            disableEventsPez();
            Globals.state = 0;
        }
        private void pezVerde_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezVerde.Opacity = 0;
            checkWin();
        }

        private void pezLila_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezLila.Opacity = 0;
            checkWin();
        }

        private void pezAzul_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezAzul.Opacity = 0;
            checkWin();
        }

        private void pezAmarillo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezAmarillo.Opacity = 0;
            checkWin();
        }

        private void pezRojo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezRojo.Opacity = 0;
            checkWin();
        }

        private void cvLago_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (playing == false)
            {
                if(canplay==true) juegoStart();

            }

        }
        private void enableEventsPez()
        {
            Globals.pezAmarillo.MouseDown += pezAmarillo_MouseDown;
            Globals.pezAzul.MouseDown += pezAzul_MouseDown;
            Globals.pezLila.MouseDown += pezLila_MouseDown;
            Globals.pezRojo.MouseDown += pezRojo_MouseDown;
            Globals.pezVerde.MouseDown += pezVerde_MouseDown;
        }
        private void disableEventsPez()
        {

            Globals.pezAmarillo.MouseDown -= pezAmarillo_MouseDown;
            Globals.pezAzul.MouseDown -= pezAzul_MouseDown;
            Globals.pezLila.MouseDown -= pezLila_MouseDown;
            Globals.pezRojo.MouseDown -= pezRojo_MouseDown;
            Globals.pezVerde.MouseDown -= pezVerde_MouseDown;
        }
        public void enableEventLago()
        {
            canplay = true;
        }
        public void disableEventLago()
        {
            canplay = false;
        }
        public bool isPlaying()
        {
            return playing;
        }

        public void checkWin()
        {
            if (Globals.pezVerde.Opacity == 0 && Globals.pezLila.Opacity == 0 && Globals.pezAzul.Opacity == 0 &&
    Globals.pezAmarillo.Opacity == 0 && Globals.pezRojo.Opacity == 0 && playing == true)
            {
                Globals.ProgressBar_diversion.Value += 80;
                Globals.pezVerde.Opacity = 100;
                Globals.pezLila.Opacity = 100;
                Globals.pezAzul.Opacity = 100;
                Globals.pezAmarillo.Opacity = 100;
                Globals.pezRojo.Opacity = 100;
                juegoStop();

            }
        }
    }

}
