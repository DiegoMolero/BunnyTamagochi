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
    class Respirar
    {
        private DoubleAnimation widthAnimation;
        private DoubleAnimation canvasLeftAnimation;
        private Storyboard storyboard;
        private Ellipse cuerpo;
        private double actualWidthCuerpo;
        private double actualCanvasLeft;

        public Respirar(Ellipse cuerpo)
        {
            this.cuerpo = cuerpo;
            storyboard = new Storyboard();
            actualCanvasLeft = 313;
            actualWidthCuerpo = cuerpo.Width;

            widthAnimation = new DoubleAnimation
            {
                From = actualWidthCuerpo,
                To = actualWidthCuerpo + 10,
                Duration = TimeSpan.FromSeconds(2),
                AutoReverse = true
            };
            canvasLeftAnimation = new DoubleAnimation
            {
                From = actualCanvasLeft,
                To = actualCanvasLeft - 5,
                Duration = TimeSpan.FromSeconds(2),
                AutoReverse = true
            };
           storyboard.Children.Add(widthAnimation);
           storyboard.Children.Add(canvasLeftAnimation);

           Storyboard.SetTarget(widthAnimation, cuerpo);
           Storyboard.SetTarget(canvasLeftAnimation, cuerpo);

           Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Ellipse.WidthProperty));
           Storyboard.SetTargetProperty(canvasLeftAnimation, new PropertyPath(Canvas.LeftProperty));
        }
        public void respirarStart()
        {
            storyboard.Begin();
        }

    }
}
