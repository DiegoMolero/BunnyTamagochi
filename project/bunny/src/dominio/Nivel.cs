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

            if (Globals.progressbar_nivel.Maximum <= Globals.score)
            {
                Globals.nivel++;
                Globals.score = 0;
                Globals.progressbar_nivel.Maximum = Globals.nivel * 10;
                Globals.ProgressBar_diversion.Value = 0;
            }

            if(Globals.nivel == 1)
            {
                Globals.cvEstructuraCasa.Opacity = 0;
                Globals.cvPuerta.Opacity = 0;
                Globals.cvVentana.Opacity = 0;
                Globals.cvChimenea.Opacity = 0;
                Globals.cvCarretera.Opacity = 0;
                Globals.cvPajarillos.Opacity = 0;
                Globals.cvGafasSol.Opacity = 0;
                Globals.cvCampoFlores.Opacity = 0;
                Globals.cvCampoFlores2.Opacity = 0;
            }
            else if (Globals.nivel == 2)
            {
                Globals.cvEstructuraCasa.Opacity = 100;
                Globals.cvPuerta.Opacity = 100;
                Globals.cvVentana.Opacity = 0;
                Globals.cvChimenea.Opacity = 0;
                Globals.cvCarretera.Opacity = 0;
                Globals.cvPajarillos.Opacity = 0;
                Globals.cvGafasSol.Opacity = 0;
                Globals.cvCampoFlores.Opacity = 0;
                Globals.cvCampoFlores2.Opacity = 0;

            }
            else if (Globals.nivel == 3)
            {
                Globals.cvEstructuraCasa.Opacity = 100;
                Globals.cvPuerta.Opacity = 100;
                Globals.cvVentana.Opacity = 100;
                Globals.cvChimenea.Opacity = 0;
                Globals.cvCarretera.Opacity = 0;
                Globals.cvPajarillos.Opacity = 0;
                Globals.cvGafasSol.Opacity = 0;
                Globals.cvCampoFlores.Opacity = 0;
                Globals.cvCampoFlores2.Opacity = 0;

            }
            else if(Globals.nivel == 4)
            {
                Globals.cvEstructuraCasa.Opacity = 100;
                Globals.cvPuerta.Opacity = 100;
                Globals.cvVentana.Opacity = 100;
                Globals.cvChimenea.Opacity = 100;
                Globals.cvCarretera.Opacity = 100;
                Globals.cvPajarillos.Opacity = 0;
                Globals.cvGafasSol.Opacity = 0;
                Globals.cvCampoFlores.Opacity = 0;
                Globals.cvCampoFlores2.Opacity = 0;
            }
            else if (Globals.nivel == 5)
            {
                Globals.cvEstructuraCasa.Opacity = 100;
                Globals.cvPuerta.Opacity = 100;
                Globals.cvVentana.Opacity = 100;
                Globals.cvChimenea.Opacity = 100;
                Globals.cvCarretera.Opacity = 100;
                Globals.cvPajarillos.Opacity = 100;
                Globals.cvGafasSol.Opacity = 100;
                Globals.cvCampoFlores.Opacity = 0;
                Globals.cvCampoFlores2.Opacity = 0;
            }
            else
            {
                Globals.cvEstructuraCasa.Opacity = 100;
                Globals.cvPuerta.Opacity = 100;
                Globals.cvVentana.Opacity = 100;
                Globals.cvChimenea.Opacity = 100;
                Globals.cvCarretera.Opacity = 100;
                Globals.cvPajarillos.Opacity = 100;
                Globals.cvGafasSol.Opacity = 100;
                Globals.cvCampoFlores.Opacity = 100;
                Globals.cvCampoFlores2.Opacity = 100;
            }
            Globals.progressbar_nivel.Value = Globals.score;
            Globals.label_nivel.Content = "NIVEL: " + Globals.nivel;


        }
    }
}
