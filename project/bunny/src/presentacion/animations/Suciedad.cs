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
    class Suciedad
    {
        private Storyboard ani_suciedad;

        public Suciedad(Storyboard ani_suciedad)
        {
            this.ani_suciedad = ani_suciedad;


        }

        public void suciedadStart()
        {
            ani_suciedad.Begin();

        }

    }
}
