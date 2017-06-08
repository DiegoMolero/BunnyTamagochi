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
using bunny.src.dominio;

namespace bunny.src.presentacion.objects_img
{
    class Caca
    {
        private Canvas cvCaca;
        private Canvas cvBunny;
        private int top;
        private int left;
        private Label labelMessage;
        private SoundsPlayer s;

        public Caca(Canvas cvBunny,Label label_puntuacion)
        {
            Random rnd = new Random();
            top = rnd.Next(-40, 40);
            left = rnd.Next(-40, 40);
            Color color = Color.FromRgb(0,0,0);
            Globals.cacas++;
            this.cvBunny = cvBunny;
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
            cvCaca.MouseEnter += mouseEnter;
            cvBunny.Children.Add(cvCaca);
            s = new SoundsPlayer();
            s.toiletSound();




        }
        private void clickOnCaca(object sender, MouseButtonEventArgs e)
        {
            cvBunny.Children.Remove(cvCaca);
            if(Globals.ProgressBar_diversion.Value >= 30)
            {
                Globals.score += 5;
                Globals.label_puntuacion.Content = "Puntuación: "+Globals.score;
                Globals.cacas--;
                showPuntuation();
            }

        }
        private void showPuntuation()
        {
            labelMessage = new Label();
            labelMessage.Content = "+5";
            labelMessage.Width = 111;
            labelMessage.FontFamily = new FontFamily("Showcard Gothic") ;
            labelMessage.FontSize = 36;
            Canvas.SetTop(labelMessage, 362 + top-20);
            Canvas.SetLeft(labelMessage, 390 + left -20);
            cvBunny.Children.Add(labelMessage);

            Storyboard storyboard = new Storyboard();
            DoubleAnimation animacionMoverArriva = createAnimationUp();
            DoubleAnimation animacionMoverAparecer = createAnimationAppear();
            storyboard.Children.Add(animacionMoverArriva);
            storyboard.Children.Add(animacionMoverAparecer);
            Storyboard.SetTarget(animacionMoverArriva, labelMessage);
            Storyboard.SetTarget(animacionMoverAparecer, labelMessage);
            Storyboard.SetTargetProperty(animacionMoverArriva, new PropertyPath(Canvas.TopProperty));
            Storyboard.SetTargetProperty(animacionMoverAparecer, new PropertyPath(Label.OpacityProperty));
            storyboard.Begin(labelMessage);
            storyboard.Completed += new EventHandler(showCompleted);
    }
        private DoubleAnimation createAnimationUp()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 362 + top - 20,
                To = 362 + top - 50,
                Duration = new Duration(TimeSpan.FromSeconds(1.5))
            };
            return animation;
        }
        private DoubleAnimation createAnimationAppear()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(1.5))
            };
            return animation;
        }
        private void showCompleted(object sender, EventArgs e)
        {
                cvBunny.Children.Remove(labelMessage);
        }
        private void mouseEnter(object sender, EventArgs e)
        {
            cvCaca.Cursor = Cursors.Hand;
        }
    }
}
