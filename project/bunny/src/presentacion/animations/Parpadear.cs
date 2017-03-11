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
        private DoubleAnimation parpadearIzqAnimation;
        private DoubleAnimation parpadearDerAnimation;
        private Storyboard storyboard;
        private Ellipse parpadoIzq;
        private Ellipse parpadoDer;


        public Parpadear(Ellipse parpadoIzq, Ellipse parpadoDer){
            this.parpadoIzq = parpadoIzq;
            this.parpadoDer = parpadoDer;
            storyboard = new Storyboard();

            parpadearIzqAnimation = createAnimation();
            parpadearDerAnimation = createAnimation();

            storyboard.Children.Add(parpadearIzqAnimation);
            storyboard.Children.Add(parpadearDerAnimation);

            Storyboard.SetTargetName(parpadearIzqAnimation, parpadoIzq.Name);
            Storyboard.SetTargetName(parpadearDerAnimation, parpadoDer.Name);

            Storyboard.SetTargetProperty(parpadearIzqAnimation, new PropertyPath(Ellipse.OpacityProperty));
            Storyboard.SetTargetProperty(parpadearDerAnimation, new PropertyPath(Ellipse.OpacityProperty));

        }

        public void parpadearStart()
        {
            storyboard.Begin(parpadoIzq);
        }

        private DoubleAnimation createAnimation() {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.05)),
                AutoReverse = true
            };
            return animation;
        }


    }
}
