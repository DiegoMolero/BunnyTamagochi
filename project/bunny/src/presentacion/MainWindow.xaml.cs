
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using bunny.src.presentacion;
using bunny.src.dominio;
using System.Windows.Media.Animation;
using bunny.src.presentacion.animations;
using System.ComponentModel;
using System.Drawing;
using System.IO;

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
        private Hambre ani_hambre;
        private Dormir ani_dormir;
        private Juego ani_juego;
        private Cursor customCursor;

        public object DragSource { get; private set; }
        public bool IsDragging { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "resources\\cursor.cur");
            customCursor = new Cursor( path);
            counter = new Counter();
            Timer_counter.Content = 0;
            Globals.cvDormido = cvDormido;
            Globals.cvCama = cvCama;
            Globals.cvBunny = cvBunny;
            Globals.label_puntuacion = Label_Puntuacion;
            Globals.state = 0;
            Globals.cvLago = cvLago;
            //peces
            Globals.pezVerde = pezVerde;
            Globals.pezAmarillo = pezAmarillo;
            Globals.pezLila = pezLila;
            Globals.pezRojo = pezRojo;
            Globals.pezAzul = pezAzul;
            //progress bar
            Globals.ProgressBar_hambre = ProgressBar_hambre;
            Globals.ProgressBar_baño = ProgressBar_baño;
            Globals.ProgressBar_sueño = ProgressBar_sueño;
            Globals.cacas = 0;
            Globals.score = 0;
            //Inicializar animaciones
            ani_respirar = new Respirar(cuerpo);
            ani_parpadear = new Parpadear(parpadoIzq, parpadoDer);
            ani_rascarbarriga = new RascarBarrigaCanvas(cvBrazoIzquierdo, cvBrazoDerecho);
            ani_cansancio = new Cansancio(this.FindResource("sbCansancio") as Storyboard);
            ani_hambre = new Hambre(this.FindResource("sbHambre") as Storyboard);
            //Barra de progreso
            progressbar_controler = new ProgressBarControler( //ProgressBars
    Label_hambre, Label_baño, Label_sueño, Label_Puntuacion, //Labels
    ani_cansancio, ani_hambre, //Animations
     cvBunny) //Canvas
      ;
            temporizador = new Temporizador(this);
            temporizador.registrarObservador(progressbar_controler);
            //Leer XML
            new ReadXml(progressbar_controler);
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

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            GenerateXml file = new GenerateXml(Globals.ProgressBar_sueño.Value,
                Globals.ProgressBar_hambre.Value, Globals.ProgressBar_baño.Value,
                Globals.score,Globals.cacas);
        }

        //CURSOR-ZANAHORIA

        private void soltarZanahoria(object sender, DragEventArgs e)
        {
            Canvas aux = (Canvas)e.Data.GetData(typeof(Canvas));
            switch (aux.Name)
            {
                case "cvZanahoriaCampo_Comer":
                    progressbar_controler.setBarHambre(80);
                    cvComer.Opacity = 0;
                    break
                ;

            }
        }

        private void inicioArrastrarZanahoria(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Canvas)sender));
            DragDrop.DoDragDrop((Canvas)sender, dataO, DragDropEffects.Copy);
            cvZanahoriaCampo_Comer.Opacity = 100;
        }

        private void Label_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effects == DragDropEffects.Copy)
            {
                cvComer.Opacity = 100;
                
            }
            else
            {
                cvComer.Opacity = 0;
            }
            cvZanahoriaCampo_Comer.Opacity = 0;
            e.UseDefaultCursors = false;
                Mouse.SetCursor(customCursor);
            e.Handled = true;
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
        public static System.Windows.Shapes.Path pezVerde { get; set; }
        public static System.Windows.Shapes.Path pezLila { get; set; }
        public static System.Windows.Shapes.Path pezAmarillo { get; set; }
        public static System.Windows.Shapes.Path pezRojo { get; set; }
        public static System.Windows.Shapes.Path pezAzul { get; set; }
        public static ProgressBar ProgressBar_hambre { get;  set; }
        public static ProgressBar ProgressBar_baño { get;  set; }
        public static ProgressBar ProgressBar_sueño { get;  set; }
        public static int cacas { get; internal set; }
        public static int score { get; internal set; }
    }
}
