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

        public void welcomeSound()
        {
            String pathWelcome = pathDirectory + "\\bienvenido.wav";
            s.Open(new Uri(pathWelcome));
            s.Play();
        }

        public void tiredSound()
        {
            String pathTired = pathDirectory + "\\cansado.wav";
            s.Open(new Uri(pathTired));
            s.Play();
        }

        public void hungrySound()
        {
            String pathHungry = pathDirectory + "\\hambriento.wav";
            s.Open(new Uri(pathHungry));
            s.Play();
        }

        public void cleaningSound()
        {
            String pathCleaning = pathDirectory + "\\limpiando.wav";
            s.Open(new Uri(pathCleaning));
            s.Play();
        }

        public void fishedSound()
        {
            String pathFished = pathDirectory + "\\pescado.wav";
            s.Open(new Uri(pathFished));
            s.Play();
        }

        public void ambientalSound()
        {
            String pathAmbiental = pathDirectory + "\\ambiental.wav";
            s.Open(new Uri(pathAmbiental));
            s.Play();
        }

        public void stopSound()
        {
            s.Stop();
        }

    }
}

