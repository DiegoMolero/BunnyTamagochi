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

        public Dormir(Storyboard ani_dormir)
        {
            this.ani_dormir = ani_dormir;


        }

        public void cansancioStart()
        {
            ani_dormir.Begin();

        }

    }
}
