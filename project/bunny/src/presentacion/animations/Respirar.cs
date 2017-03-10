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
        private DoubleAnimation heightAnimation;
        private Storyboard storyboard;
        private Ellipse cuerpo;
        private double acutalWidthCuerpo;
        private double actualHeigthCuerpo;

        public Respirar(Ellipse cuerpo)
        {
            this.cuerpo = cuerpo;
            storyboard = new Storyboard();
            actualHeigthCuerpo = cuerpo.Height;
            acutalWidthCuerpo = cuerpo.Width;

            widthAnimation = new DoubleAnimation
            {
                From = acutalWidthCuerpo,
                To = acutalWidthCuerpo,
                Duration = TimeSpan.FromSeconds(2)
            };
            heightAnimation = new DoubleAnimation
            {
                From = actualHeigthCuerpo,
                To = acutalWidthCuerpo,
                Duration = TimeSpan.FromSeconds(2)
            };
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Ellipse.WidthProperty));
            Storyboard.SetTarget(widthAnimation, cuerpo);

            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Ellipse.HeightProperty));
            Storyboard.SetTarget(heightAnimation,cuerpo);

            storyboard.Children.Add(widthAnimation);
            storyboard.Children.Add(heightAnimation);

        }
        public void respirar()
        {
            storyboard.Begin();
        }

    }
}
