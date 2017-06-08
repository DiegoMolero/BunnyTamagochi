using bunny.src.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace bunny.src.presentacion.animations
{
    class Dormir
    {
        private Storyboard ani_dormir;
        Boolean state=false;
        private SoundsPlayer s;

        public Dormir(Storyboard ani_dormir)
        {
            this.ani_dormir = ani_dormir;
            s = new SoundsPlayer();
        }

        public void cansancioStart()
        {
            ani_dormir.Begin();
            s.sleepingSound();
            state = true;
        }
        public void cansancioStop()
        {
            ani_dormir.Stop();
            state = false;
        }
        public Boolean isStarted()
        {
            return state;
        }
    }
}
