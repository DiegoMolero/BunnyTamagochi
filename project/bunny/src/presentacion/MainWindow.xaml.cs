using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using bunny.src.presentacion;
using bunny.src.dominio;
using System.Windows.Media.Animation;
using bunny.src.presentacion.animations;

namespace bunny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Observador
    {
        private Temporizador temporizador;
        private Counter counter;
        private Respirar ani_respirar;
        private Parpadear ani_parpadear;
        private RascarBarrigaCanvas ani_rascarbarriga;

        public MainWindow()
        {
            InitializeComponent();
            counter = new Counter();
            temporizador = new Temporizador(this);
            Timer_counter.Content = 0;
            ani_respirar = new Respirar(cuerpo);
            ani_parpadear = new Parpadear(parpadoIzq,parpadoDer);
            ani_rascarbarriga = new RascarBarrigaCanvas(cvBrazoIzquierdo,cvBrazoDerecho);
        }

        public void update()
        {
            counter.increase();
            int counter_aux = counter.getCounter();
            Timer_counter.Content = counter_aux;
            if (counter_aux % 3 == 0) ani_parpadear.parpadearStart();
            if (counter_aux % 4 == 0) ani_respirar.respirarStart();
            if (counter_aux % 10 == 0) ani_rascarbarriga.parpadearStart();


        }
    }
}
