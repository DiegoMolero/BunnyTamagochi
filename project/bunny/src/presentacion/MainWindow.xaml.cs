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
using bunny.src.presentacion.objects_img;

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
        private ProgressBarControler progressbar_controler;
        private Cansancio ani_cansancio;
        private Suciedad ani_suciedad;
        private Hambre ani_hambre;
        private Dormir ani_dormir;
        private Juego ani_juego;

        public MainWindow()
        {
            InitializeComponent();
            counter = new Counter();
            Timer_counter.Content = 0;
            Globals.cvDormido = cvDormido;
            Globals.cvCama = cvCama;
            Globals.cvBunny = cvBunny;
            Globals.label_puntuacion = Label_Puntuacion;
            Globals.state = 0;
            Globals.cvLago = cvLago;
            ani_respirar = new Respirar(cuerpo);
            ani_parpadear = new Parpadear(parpadoIzq, parpadoDer);
            ani_rascarbarriga = new RascarBarrigaCanvas(cvBrazoIzquierdo, cvBrazoDerecho);
            ani_cansancio = new Cansancio(this.FindResource("sbCansancio") as Storyboard);
            ani_suciedad = new Suciedad(this.FindResource("sbSuciedad") as Storyboard);
            ani_hambre = new Hambre(this.FindResource("sbHambre") as Storyboard);
            progressbar_controler = new ProgressBarControler(ProgressBar_hambre, ProgressBar_baño, ProgressBar_sueño, //ProgressBars
    Label_hambre, Label_baño, Label_sueño, Label_Puntuacion, //Labels
     ani_suciedad, ani_cansancio, ani_hambre, //Animations
     cvBunny, //Canvas
      this.FindResource("sbSuciedad") as Storyboard); //Storyboard
            temporizador = new Temporizador(this);
            temporizador.registrarObservador(progressbar_controler);

        }

        public void update()
        {
            counter.increase();
            int counter_aux = counter.getCounter();
            Timer_counter.Content = counter.getCounter();
            if (Globals.state == 0)
            {
                if (counter_aux % 3 == 0) ani_parpadear.parpadearStart();
                if (counter_aux % 4 == 0) ani_respirar.respirarStart();
                if (counter_aux % 10 == 0) ani_rascarbarriga.parpadearStart();
                if (counter_aux % 5 == 0) ani_cansancio.cansancioStart();
                Globals.cvDormido.Opacity = 0;
                Globals.cvBunny.Opacity = 100;
            }
            if (Globals.state == 1)
            {
                Globals.cvBunny.Opacity = 0;
                Globals.cvDormido.Opacity = 100;
            }
        }

        private void dameUnSusto(object sender, MouseEventArgs e)
        {
            Storyboard sbSusto = (Storyboard)this.Resources["sbSusto"];
            sbSusto.Begin();
        }

        private void goToSleep(object sender, MouseButtonEventArgs e)
        {
            Globals.state = 1;
        }

        private void inicioArrastrarZanahoria(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Canvas)sender));
            DragDrop.DoDragDrop((Canvas)sender, dataO, DragDropEffects.Move);
        }
        private void soltarZanahoria(object sender, DragEventArgs e)
        {
            Canvas aux = (Canvas)e.Data.GetData(typeof(Canvas));
            switch (aux.Name)
            {
                case "cvZanahoriaCampo_Comer":
                    progressbar_controler.setBarHambre(40);
                    break
                ;
            }

        }

        private void moverZanahoria(object sender, DragEventArgs e)
        {
            e.GetPosition(this);
        }

        private void pezVerde_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pezVerde.Opacity = 0;
        }

        private void pezLila_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pezLila.Opacity = 0;
        }

        private void pezAzul_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pezAzul.Opacity = 0;
        }

        private void pezAmarillo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pezAmarillo.Opacity = 0;
        }

        private void pezRojo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pezRojo.Opacity = 0;
        }

        private void cvLago_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(pezVerde.Opacity == 0 & pezLila.Opacity == 0 & pezAzul.Opacity == 0 & 
                pezAmarillo.Opacity == 0 & pezRojo.Opacity == 0)
            {
                pezVerde.Opacity = 100;
                pezLila.Opacity = 100;
                pezAzul.Opacity = 100;
                pezAmarillo.Opacity = 100;
                pezRojo.Opacity = 100;
                ani_juego = new Juego(this.FindResource("movimientoPeces") as Storyboard);
                ani_juego.juegoStop();
            }
        }
    }
    public static class Globals
    {
        public static Label label_puntuacion { get; set; }
        public static Canvas cvDormido { get; set; }
        public static Canvas cvCama { get; set; }
        public static Canvas cvBunny { get; set; }
        public static int state { get; set; }
        public static Canvas cvLago { get; set; }
    }

  
}
