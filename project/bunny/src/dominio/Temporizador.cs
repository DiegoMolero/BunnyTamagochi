using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bunny.src.presentacion;
using System.Collections;
using System.Windows.Threading;

namespace bunny.src.dominio

{
    class Temporizador
    {
        private DispatcherTimer timer;
        private List<Observador> observadores = new List<Observador>();

        public Temporizador()
        {
            iniTemporizador();
        }
        public Temporizador(Observador o)
        {
            this.registrarObservador(o);
            iniTemporizador();
        }
        private void iniTemporizador()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(actualizarObservadores);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }


        public void registrarObservador(Observador o)
        {
            observadores.Add(o);
            o.update();
        }
        public void eliminarObservador(Observador o)
        {
            observadores.Remove(o);
        }
        public void actualizarObservadores(object sender, EventArgs e)
        {
            for(int index=0; index< observadores.Count;index++)
            {
                Observador o = observadores[index];
                o.update();
            }
        }

    }
}
