﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace bunny.src.presentacion.animations
{
    class Juego
    {
        private Storyboard ani_juego;


        public Juego(Storyboard ani_juego)
        {
            this.ani_juego = ani_juego;
            Globals.cvLago.MouseDown += cvLago_MouseDown;
            Globals.pezAmarillo.MouseDown += pezAmarillo_MouseDown;
            Globals.pezAzul.MouseDown += pezAzul_MouseDown;
            Globals.pezLila.MouseDown += pezLila_MouseDown;
            Globals.pezRojo.MouseDown += pezRojo_MouseDown;
            Globals.pezVerde.MouseDown += pezVerde_MouseDown;

        }

        public void juegoStart()
        {
            ani_juego.Begin();
            Globals.state = 2;

        }

        public void juegoStop()
        {
            ani_juego.Stop();
        }
        private void pezVerde_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezVerde.Opacity = 0;
        }

        private void pezLila_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezLila.Opacity = 0;
        }

        private void pezAzul_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezAzul.Opacity = 0;
        }

        private void pezAmarillo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezAmarillo.Opacity = 0;
        }

        private void pezRojo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Globals.pezRojo.Opacity = 0;
        }

        private void cvLago_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Globals.state != 2)
            {
                juegoStart();
            }
            if (Globals.pezVerde.Opacity == 0 & Globals.pezLila.Opacity == 0 & Globals.pezAzul.Opacity == 0 &
                Globals.pezAmarillo.Opacity == 0 & Globals.pezRojo.Opacity == 0)
            {
                Globals.pezVerde.Opacity = 100;
                Globals.pezLila.Opacity = 100;
                Globals.pezAzul.Opacity = 100;
                Globals.pezAmarillo.Opacity = 100;
                Globals.pezRojo.Opacity = 100;
                juegoStop();
                Globals.state = 0;
            }
           
        }
    }

}
