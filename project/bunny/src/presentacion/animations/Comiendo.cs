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
    class Comiendo
    {
        private Storyboard ani_comiendo;
        private SoundsPlayer s;

        public Comiendo(Storyboard ani_comiendo)
        {
            this.ani_comiendo = ani_comiendo;
            s = new SoundsPlayer();
            ani_comiendo.Completed += comiendoStop;
        }

        public void comiendoStart()
        {
            ani_comiendo.Begin();
            s.eatingSound();
        }
        public void comiendoStop()
        {
            ani_comiendo.Stop();
        }
        public Storyboard getAni()
        {
            return ani_comiendo;
        }

        public void comiendoStop(object sender, EventArgs e)
        {
            ani_comiendo.Stop();
            ani_comiendo.Remove();
        }

    }
}
