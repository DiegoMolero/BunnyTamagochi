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
    class RascarBarriga
    {
        private DoubleAnimation rascarIzqAnimation;
        private DoubleAnimation rascarDerAnimation;
        private Storyboard storyboard;
        private Ellipse brazoIzq;
        private Ellipse brazoDer;

        public RascarBarriga(Ellipse brazoIzq, Ellipse brazoDer)
        {
            this.brazoIzq = brazoIzq;
            this.brazoDer = brazoDer;
            storyboard = new Storyboard();

            rascarIzqAnimation = createAnimationIzq();
            rascarDerAnimation = createAnimationDer();

            storyboard.Children.Add(rascarIzqAnimation);
            //storyboard.Children.Add(rascarDerAnimation);

            Storyboard.SetTargetName(rascarIzqAnimation, brazoIzq.Name);
            Storyboard.SetTargetName(rascarDerAnimation, brazoDer.Name);

            Storyboard.SetTargetProperty(rascarIzqAnimation, new PropertyPath("RenderTransform.Children[2].Angle"));
            Storyboard.SetTargetProperty(rascarDerAnimation, new PropertyPath("RenderTransform.Children[2].Angle"));

        }
        public void parpadearStart()
        {
            storyboard.Begin(brazoIzq);
        }
        private DoubleAnimation createAnimationIzq()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 27,
                To = 45,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                AutoReverse = true
            };
            return animation;
        }
        private DoubleAnimation createAnimationDer()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 360,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                AutoReverse = true
            };
            return animation;
        }

    }
}
