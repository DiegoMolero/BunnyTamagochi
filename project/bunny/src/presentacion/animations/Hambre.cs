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
    class Hambre
    {
        Boolean state = false;
        private Storyboard ani_hambre;
        private SoundsPlayer s;

        public Hambre(Storyboard ani_hambre)
        {
            this.ani_hambre = ani_hambre;
            s = new SoundsPlayer();


        }

        public void hambreStart()
        {
            ani_hambre.Begin();
            if (state == false)
            {
                s.hungrySound();
            }
            state = true;
        }
        public void hambreStop()
        {
            ani_hambre.Stop();
            state = false;
            s.stopSound();
        }
        public Boolean isStarted()
        {
            return state;
        }

    }
}
