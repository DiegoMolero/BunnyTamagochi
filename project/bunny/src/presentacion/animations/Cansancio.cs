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

        public Cansancio(Storyboard ani_cansancio)
        {
            this.ani_cansancio = ani_cansancio;


        }

        public void cansancioStart()
        {
            ani_cansancio.Begin();
            state = true;

        }
        public void cansancioStop()
        {
            ani_cansancio.Stop();
            state = false;
        }
        public Boolean isStarted()
        {
            return state;
        }

    }
}
