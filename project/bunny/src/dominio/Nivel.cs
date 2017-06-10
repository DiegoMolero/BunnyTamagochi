using bunny.src.presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bunny.src.dominio
{
    class Nivel : Observador
    {
        public Nivel()
        {
            Globals.nivel = 1;
            Globals.progressbar_nivel.Maximum = Globals.nivel * 10;
            Globals.label_nivel.Content = "NIVEL: "+Globals.nivel;
            Globals.progressbar_nivel.Value = Globals.score;
        }

        public void update()
        {

            Globals.progressbar_nivel.Value = Globals.score;
            Globals.label_nivel.Content = "NIVEL: " + Globals.nivel;
            if (Globals.progressbar_nivel.Maximum <= Globals.score)
            {
                Globals.nivel++;
                Globals.score = 0;
                Globals.progressbar_nivel.Maximum = Globals.nivel * 10;
                Globals.ProgressBar_diversion.Value = 0;
            }
        }
    }
}
