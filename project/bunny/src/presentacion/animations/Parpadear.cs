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

namespace bunny.src.presentacion.animations
{
    class Parpadear
    {
        private DoubleAnimation parpadearAnimation;
        private Storyboard storyboard;
        private Ellipse parpadoIzq;
        private Ellipse parpadoDer;


        public Parpadear(Ellipse parpadoIzq, Ellipse parpadoDer){
            this.parpadoIzq = parpadoIzq;
            this.parpadoDer = parpadoDer;
            storyboard = new Storyboard();

            parpadearAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                AutoReverse = true
            };
            storyboard.Children.Add(parpadearAnimation);

            Storyboard.SetTargetName(parpadearAnimation, parpadoIzq.Name);

            Storyboard.SetTargetProperty(parpadoIzq, new PropertyPath(Ellipse.OpacityProperty));

        }

        public void parpadearStart()
        {
            storyboard.Begin(parpadoIzq);
        }

    }
}
