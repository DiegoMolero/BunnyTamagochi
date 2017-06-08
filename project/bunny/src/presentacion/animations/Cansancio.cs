using bunny.src.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace bunny.src.presentacion.animations
{
    class Cansancio
    {
        private Storyboard ani_cansancio;
        Boolean state = false;
        private SoundsPlayer s;

        public Cansancio(Storyboard ani_cansancio)
        {
            this.ani_cansancio = ani_cansancio;
            s = new SoundsPlayer();


        }

        public void cansancioStart()
        {
            ani_cansancio.Begin();
            if (state == false)
            {
                s.tiredSound();
            }
            state = true;
        }

        public void cansancioStop()
        {
            ani_cansancio.Stop();
            state = false;
            s.stopSound();
        }
        public Boolean isStarted()
        {
            return state;
        }

    }
}
