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
        private Storyboard ani_hambre;

        public Hambre(Storyboard ani_hambre)
        {
            this.ani_hambre = ani_hambre;


        }

        public void hambreStart()
        {
            ani_hambre.Begin();

        }

    }
}
