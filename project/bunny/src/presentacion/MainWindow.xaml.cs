
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
using System;

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
        private Comiendo ani_comiendo;
        private Cursor customCursor;
        private SoundsPlayer s;
        private SoundsPlayer d;
        private Triste ani_triste;

        public object DragSource { get; private set; }
        public bool IsDragging { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "resources\\cursor.cur");
            customCursor = new Cursor(path);
            counter = new Counter();
            Timer_counter.Content = 0;
            Globals.firstGame = true;
            Globals.cvDormido = cvDormido;
            Globals.cvTriste = cvTriste;
            Globals.cvCama = cvCama;
            Globals.cvBunny = cvBunny;
            Globals.cvPescando = cvPescando;
            Globals.label_puntuacion = Label_Puntuacion;
            Globals.img_pause = img_pause;
            Globals.img_music = img_music;
            Globals.state = 0;
            Globals.cvLago = cvLago;
            Globals.cvFondo = cvFondo;
            //nivel
            Globals.progressbar_nivel = ProgressBar_nivel;
            Globals.label_nivel = Label_Nivel;
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
            Globals.ProgressBar_diversion = ProgressBar_diversion;
            Globals.cacas = 0;
            Globals.score = 0;
            Globals.state_label = Label_State;
            Globals.cvPause = cvPause;
            //Inicializar animaciones
            ani_respirar = new Respirar(cuerpo);
            ani_parpadear = new Parpadear(parpadoIzq, parpadoDer);
            ani_rascarbarriga = new RascarBarrigaCanvas(cvBrazoIzquierdo, cvBrazoDerecho);
            ani_cansancio = new Cansancio(this.FindResource("sbCansancio") as Storyboard);
            ani_hambre = new Hambre(this.FindResource("sbHambre") as Storyboard);
            ani_dormir = new Dormir(this.FindResource("sbDurmiendo") as Storyboard);
            ani_comiendo = new Comiendo(this.FindResource("sbComiendo") as Storyboard);
            ani_triste = new Triste(this.FindResource("sbTristeza") as Storyboard);
            Globals.juego_pescar = new Juego(this.FindResource("movimientoPeces") as Storyboard, Label_Puntuacion);
            //Barra de progreso
            progressbar_controler = new ProgressBarControler( //ProgressBars
    Label_hambre, Label_baño, Label_sueño, Label_Puntuacion, Label_diversion, //Labels
    ani_cansancio, ani_hambre, ani_dormir,ani_triste,  //Animations
     cvBunny) //Canvas
      ;
            Nivel nivel_controller = new Nivel();
            temporizador = new Temporizador(this);
            temporizador.registrarObservador(progressbar_controler);
            temporizador.registrarObservador(nivel_controller);
            Globals.pause = new Pause();
            new ReadXml(progressbar_controler);
            s = new SoundsPlayer();
            d = new SoundsPlayer();
            s.ambientalSound();
            d.welcomeSound();
            //Leer XML
        }

        public void update()
        {
            counter.increase();
            Globals.counter = counter.getCounter();
            Timer_counter.Content = counter.getCounter();
            if (Globals.state == 0)
            {
                if (Globals.counter % 3 == 0) ani_parpadear.parpadearStart();
                if (Globals.counter % 4 == 0) ani_respirar.respirarStart();
                if (Globals.counter % 10 == 0) ani_rascarbarriga.parpadearStart();
                if (Globals.counter % 5 == 0) ani_cansancio.cansancioStart();
                Globals.cvDormido.Opacity = 0;
                Globals.cvBunny.Opacity = 100;
            }
            if (Globals.state == 1)
            {
                Globals.cvBunny.Opacity = 0;
                Globals.cvDormido.Opacity = 100;
            }
            if (Globals.state == 3)
            {
                progressbar_controler.updateLabels();
            }
        }

        private void goToSleep(object sender, MouseButtonEventArgs e)
        {
            if (Globals.state == 0) Globals.state = 1;
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            GenerateXml file = new GenerateXml(Globals.ProgressBar_sueño.Value,
                Globals.ProgressBar_hambre.Value, Globals.ProgressBar_baño.Value,Globals.ProgressBar_diversion.Value,
                Globals.score, Globals.cacas,Globals.nivel);
        }

        //CURSOR-ZANAHORIA

        private void soltarZanahoria(object sender, DragEventArgs e)
        {
            Canvas aux = (Canvas)e.Data.GetData(typeof(Canvas));
            switch (aux.Name)
            {
                case "cvZanahoriaCampo_Comer":
                    progressbar_controler.setBarHambre(80);
                    ani_comiendo.comiendoStart();
                    cvComer.Opacity = 0;
                    break
                ;

            }
        }

        private void inicioArrastrarZanahoria(object sender, MouseButtonEventArgs e)
        {
            if (Globals.state == 0)
            {
                DataObject dataO = new DataObject(((Canvas)sender));
                DragDrop.DoDragDrop((Canvas)sender, dataO, DragDropEffects.Copy);
                cvZanahoriaCampo_Comer.Opacity = 100;
            }

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
        private void mouseEnter(object sender, EventArgs e)
        {
            cvZanahoriaCampo_Comer.Cursor = Cursors.Hand;
            cvCama.Cursor = Cursors.Hand;
            cvBarriDormido.Cursor = Cursors.Hand;
            Mouse.SetCursor(Cursors.Hand);
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            Mouse.SetCursor(Cursors.Arrow);
        }
        private void movimientoNube()
        {
         //   Canvas.SetLeft(nube1,nube1_pos);
        }

    }

    public static class Globals
    {
        public static Label label_puntuacion { get; set; }
        public static Canvas cvDormido { get; set; }
        public static Canvas cvCama { get; set; }
        public static Canvas cvBunny { get; set; }
        public static Canvas cvFondo { get; set; }
        public static int state { get; set; }
        public static int counter { get; set; }
        public static Canvas cvLago { get; set; }
        public static System.Windows.Shapes.Path pezVerde { get; set; }
        public static System.Windows.Shapes.Path pezLila { get; set; }
        public static System.Windows.Shapes.Path pezAmarillo { get; set; }
        public static System.Windows.Shapes.Path pezRojo { get; set; }
        public static System.Windows.Shapes.Path pezAzul { get; set; }
        public static ProgressBar ProgressBar_hambre { get; set; }
        public static ProgressBar ProgressBar_baño { get; set; }
        public static ProgressBar ProgressBar_sueño { get; set; }
        public static ProgressBar ProgressBar_diversion { get; set; }
        public static Label state_label { get; set; }
        public static Juego juego_pescar { get; set; }
        public static Image img_pause { get; set; }
        public static Image img_music { get; set; }
        public static int cacas { get; set; }
        public static int score { get; set; }
        public static Canvas cvPescando { get; set; }
        public static Pause pause { get; set; }
        public static Canvas cvPause { get; set; }
        public static Canvas cvTriste { get; set; }
        public static bool firstGame { get; set; }
        public static bool muted { get; set; }
        //NIVEL
        public static ProgressBar progressbar_nivel;
        public static Label progressbarnivel_label;
        public static Label label_nivel;
        public static int nivel;
    }
}
