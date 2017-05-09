using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace bunny.src.presentacion.animations
{
    class Juego
    {
        private Storyboard ani_juego;


        public Juego(Storyboard ani_juego)
        {
            this.ani_juego = ani_juego;


        }

        public void juegoStart()
        {
            ani_juego.Begin();

        }

        public void juegoStop()
        {
            ani_juego.Stop();
        }

    }
}
