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
    class RascarBarrigaCanvas
    {
        private DoubleAnimation rascarIzqAnimation;
        private DoubleAnimation rascarDerAnimationY;
        private DoubleAnimation rascarDerAnimationX;
        private Storyboard storyboard;
        private Canvas brazoIzq;
        private Canvas brazoDer;

        public RascarBarrigaCanvas(Canvas brazoIzq,Canvas brazoDer)
        {
            this.brazoIzq = brazoIzq;
            this.brazoDer = brazoDer;
            storyboard = new Storyboard();

            rascarIzqAnimation = createAnimationIzq();
            rascarDerAnimationX = createAnimationDerX();
            rascarDerAnimationY= createAnimationDerY();

            storyboard.Children.Add(rascarIzqAnimation);
            storyboard.Children.Add(rascarDerAnimationX);
            storyboard.Children.Add(rascarDerAnimationY);

            Storyboard.SetTargetName(rascarIzqAnimation, brazoIzq.Name);
            Storyboard.SetTargetName(rascarDerAnimationX, brazoDer.Name);
            Storyboard.SetTargetName(rascarDerAnimationY, brazoDer.Name);

            Storyboard.SetTargetProperty(rascarIzqAnimation, new PropertyPath("RenderTransform.Children[2].Angle"));
            Storyboard.SetTargetProperty(rascarDerAnimationX, new PropertyPath("RenderTransform.Children[1].AngleX"));
            Storyboard.SetTargetProperty(rascarDerAnimationY, new PropertyPath("RenderTransform.Children[1].AngleY"));

        }
        public void parpadearStart()
        {
            storyboard.Begin(brazoIzq);
        }
        private DoubleAnimation createAnimationIzq()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 20,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                AutoReverse = true
            };
            return animation;
        }
        private DoubleAnimation createAnimationDerX()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 25,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                AutoReverse = true
            };
            return animation;
        }
        private DoubleAnimation createAnimationDerY()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = -15,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                AutoReverse = true
            };
            return animation;
        }

    }
}
