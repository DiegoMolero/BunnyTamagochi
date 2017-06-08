using bunny.src.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace bunny.src.presentacion.animations
{
    public class Juego
    {
        private Storyboard ani_juego;
        private bool playing;
        private bool canplay;
        private int timegame;
        private Label labelMessage;
        private SoundsPlayer s;

        public Juego(Storyboard ani_juego, Label label_puntuacion)
        {
            this.ani_juego = ani_juego;
            this.playing = false;
            this.canplay = false;
            Globals.cvLago.MouseDown += cvLago_MouseDown;
            Globals.cvLago.MouseEnter += mouseEnter;
            s = new SoundsPlayer();
        }

        public void juegoStart()
        {
            if(Globals.state == 0) {
            Globals.cvBunny.Opacity = 0;
            Globals.cvPescando.Opacity = 100;
            ani_juego.Begin();
            if (playing == false)
            {
                s.fishingSound();
            }
            this.playing = true;
            enableEventsPez();
            Globals.state = 2;
            disableEventLago();
            timegame = 10;
            showContador();
            }

        }

        public void juegoStop()
        {
            Globals.cvBunny.Opacity = 100;
            Globals.cvPescando.Opacity = 0;
            ani_juego.Stop();
            this.playing = false;
            this.canplay = false;
            disableEventsPez();
            Globals.state = 0;
            Globals.cvFondo.Children.Remove(labelMessage);
            s.stopSound();

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
        private void mouseEnter(object sender, EventArgs e)
        {
            Globals.cvLago.Cursor = Cursors.Hand;
        }
        private void showContador()
        {
            labelMessage = new Label();
            labelMessage.Content = "Tiempo:"+timegame;
            labelMessage.Width = 300;
            labelMessage.FontFamily = new FontFamily("Showcard Gothic");
            labelMessage.FontSize = 20;
            Canvas.SetTop(labelMessage, 250);
            Canvas.SetLeft(labelMessage, 800);
            Globals.cvFondo.Children.Add(labelMessage);
        }
        public void setTimerGame()
        {
            if (timegame > 0)
            {
                timegame--;
                labelMessage.Content = "Tiempo:" + timegame;
            }
            else
            {
                juegoStop();
            }
           
        }
    }

}
