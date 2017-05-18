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

        private String pathDirectory = Environment.CurrentDirectory.Replace("\\bin\\Debug", "");
        private Storyboard ani_comiendo;

        public Comiendo(Storyboard ani_comiendo)
        {
            this.ani_comiendo = ani_comiendo;
            ani_comiendo.Completed += comiendoStop;
        }

        public void comiendoStart()
        {
            ani_comiendo.Begin();

            String pathComiendo = pathDirectory + "\\comiendo.wav";
            MediaPlayer s = new MediaPlayer();
            s.Open(new Uri(pathComiendo));
            s.Play();

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
