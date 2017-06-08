using bunny.src.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace bunny.src.presentacion.animations
{
    class Triste
    {
        private Storyboard ani_triste;
        private SoundsPlayer s;
        Boolean state = false;

        public Triste(Storyboard ani_triste)
        {
            this.ani_triste = ani_triste;
            s = new SoundsPlayer();
        }

        public void tristeStart()
        {
            if (state == false)
            {
                s.aburridoSound();
            }
            state = true;
            ani_triste.Begin();
        }
        public void tristeStop()
        {
            ani_triste.Stop();
            state = false;
            s.stopSound();
        }
        public Storyboard getAni()
        {
            return ani_triste;
        }

        public Boolean isStarted()
        {
            return state;
        }

    }
}
