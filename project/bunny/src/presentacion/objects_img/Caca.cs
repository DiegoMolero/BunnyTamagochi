using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace bunny.src.presentacion.objects_img
{
    class Caca
    {
        private Canvas cvCaca;
        private Canvas cvBunny;
        private Storyboard sbSuciedad;
        private Label label_puntuacion;

        public Caca(Canvas cvBunny,Storyboard sbSuciedad,Label label_puntuacion)
        {
            Random rnd = new Random();
            int top = rnd.Next(-40, 40);
            int left = rnd.Next(-40, 40);
            Color color = Color.FromRgb(0,0,0);

            this.sbSuciedad = sbSuciedad;
            this.cvBunny = cvBunny;
            this.label_puntuacion = label_puntuacion;

            this.cvCaca = new Canvas();
            cvCaca.Height = 45.3;
            cvCaca.Width = 74;
            cvCaca.Opacity = 100;
            Canvas.SetLeft(cvCaca, 362 + left);
            Canvas.SetTop(cvCaca, 390+top);

            Ellipse EllipseA = new Ellipse();
            EllipseA.Stroke = Brushes.Black;
            EllipseA.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF825919"));
            EllipseA.Width = 74;
            EllipseA.Height = 23.05;
            Canvas.SetTop(EllipseA,22.25);
            cvCaca.Children.Add(EllipseA);

            Ellipse EllipseB = new Ellipse();
            EllipseB.Stroke = Brushes.Black;
            EllipseB.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF825919"));
            EllipseB.Width = 56.4;
            EllipseB.Height = 22.25;
            EllipseB.Stroke = new SolidColorBrush(Colors.Black);
            Canvas.SetTop(EllipseB, 13.8);
            Canvas.SetLeft(EllipseB, 9.6);
            cvCaca.Children.Add(EllipseB);

            Ellipse EllipseC = new Ellipse();
            EllipseC.Stroke = Brushes.Black;
            EllipseC.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF825919"));
            EllipseC.Width = 38.8;
            EllipseC.Height = 16.25;
            EllipseC.Stroke = new SolidColorBrush(Colors.Black);
            Canvas.SetTop(EllipseC, 7.2 );
            Canvas.SetLeft(EllipseC, 18.8);
            cvCaca.Children.Add(EllipseC);

            Ellipse EllipseD = new Ellipse();
            EllipseD.Stroke = Brushes.Black;
            EllipseD.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF825919"));
            EllipseD.Width = 18.8;
            EllipseD.Height = 13.8;
            EllipseD.Stroke = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(EllipseD, 28);
            cvCaca.Children.Add(EllipseD);
            cvCaca.Visibility = Visibility.Visible;

            cvCaca.MouseUp += clickOnCaca;
            cvBunny.Children.Add(cvCaca);
 


        }
        private void clickOnCaca(object sender, MouseButtonEventArgs e)
        {
            cvBunny.Children.Remove(cvCaca);
           // label_puntuacion = label_puntuacion.GetValue + 5;
        }


        
    }
}
