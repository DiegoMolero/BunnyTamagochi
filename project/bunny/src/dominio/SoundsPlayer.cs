using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace bunny.src.dominio
{
    class SoundsPlayer
    {
        MediaPlayer s;
        public SoundsPlayer()
        {
            this.s = new MediaPlayer();
        }

        private String pathDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "sound");

        public void eatingSound()
        {
            String pathComiendo = pathDirectory + "\\comiendo.wav";
            s.Open(new Uri(pathComiendo));
            s.Play();
        }

        public void sleepingSound()
        {
            String pathDurmiendo = pathDirectory + "\\durmiendo.wav";
            s.Open(new Uri(pathDurmiendo));
            s.Play();
        }

        public void fishingSound()
        {
            String pathPescando = pathDirectory + "\\pescando.wav";
            s.Open(new Uri(pathPescando));
            s.Play();
        }

        public void toiletSound()
        {
            String pathCaca = pathDirectory + "\\caca.wav";
            s.Open(new Uri(pathCaca));
            s.Play();
        }
    }
}

