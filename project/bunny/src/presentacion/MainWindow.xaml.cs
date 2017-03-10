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

namespace bunny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Observador
    {
        private Temporizador temporizador;
        private Counter counter;
        public MainWindow()
        {
            InitializeComponent();
            counter = new Counter();
            temporizador = new Temporizador(this);
            Timer_counter.Content = 0;
        }

        public void update()
        {
            counter.increase();
            Timer_counter.Content = counter.getCounter();
        }
        private void Parpadear()
        {
            
        }
    }
}
