using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace bunny.src.dominio
{
    public class Pause
    {
        private int previousState;
        private bool muted;
        private Label labelMessage;
        private Image imgInstruction;
        private Label labelMessageInstruction;
        private Label butoInstruction;

        public Pause()
        {
            Globals.img_pause.MouseUp += changeState;
            Globals.img_music.MouseUp += changeMusic;
            Globals.img_pause.MouseEnter += mouseEnter;
            Globals.img_music.MouseEnter += mouseEnter;
            createButonInstruction();
            muted = false;
            previousState = 0;
        }

        private void changeState(object sender, MouseButtonEventArgs e)
        {
            //Si no estaba en modo pause antes
            if(Globals.state != 3) 
            {
                previousState = Globals.state;
                Globals.state = 3;
                Globals.img_pause.Source = new BitmapImage(new Uri(@"/img/icons/play.png", UriKind.Relative));
                Globals.cvPause.Background = new SolidColorBrush(Colors.Black);
                Globals.cvPause.Background.Opacity = 0.5;
                showPause();
                
            }
            //Si SI estaba en modo pause antes
            else if(Globals.state== 3)
            {
                Globals.img_pause.Source = new BitmapImage(new Uri(@"/img/icons/pause.png", UriKind.Relative));
                Globals.cvPause.Background = null;
                Globals.state = previousState;
                deletePauseConetent();

            }
           
        }
        private void changeMusic(object sender, MouseButtonEventArgs e)
        {
            if(muted == false)
            {
                Globals.img_music.Source = new BitmapImage(new Uri(@"/img/icons/muted.png", UriKind.Relative));
                muted = true;
            }
            else
            {
                Globals.img_music.Source = new BitmapImage(new Uri(@"/img/icons/sound.png", UriKind.Relative));
                muted = false;
            }
        }
        private void mouseEnter(object sender, EventArgs e)
        {
            Globals.img_music.Cursor = Cursors.Hand;
            Globals.img_pause.Cursor = Cursors.Hand;
        }

        private void mouseEnterImgIns(object sender, EventArgs e)
        {
            butoInstruction.Cursor = Cursors.Hand;
        }
        
        private void showPause()
        {
            labelMessage = new Label();
            labelMessage.Content = "PAUSA";
            labelMessage.Width = 300;
            labelMessage.FontFamily = new FontFamily("Showcard Gothic");
            labelMessage.FontSize = 75;
            Canvas.SetTop(labelMessage, 150 );
            Canvas.SetLeft(labelMessage, 550);
            Globals.cvPause.Children.Add(labelMessage);

            Storyboard storyboard = new Storyboard();
            DoubleAnimation animacionMoverAparecer = createAnimationAppear();
            storyboard.Children.Add(animacionMoverAparecer);
            Storyboard.SetTarget(animacionMoverAparecer, labelMessage);
            Storyboard.SetTargetProperty(animacionMoverAparecer, new PropertyPath(Label.OpacityProperty));
            storyboard.Begin(labelMessage);
            storyboard.Completed += new EventHandler(showCompleted);
        }

        private DoubleAnimation createAnimationAppear()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            return animation;
        }
        private void deletePauseConetent()
        {
            Globals.cvPause.Children.Remove(labelMessage);
        }
        private void showCompleted(object sender, EventArgs e)
        {
            labelMessage.Opacity = 100;
            labelMessage.Visibility = Visibility.Visible;
        }
        private void createButonInstruction()
        {
            butoInstruction = new Label();
            butoInstruction.Content = "INSTRUCCIONES";
            butoInstruction.Width = 200;
            butoInstruction.FontFamily = new FontFamily("Showcard Gothic");
            butoInstruction.FontSize = 25;
            butoInstruction.MouseUp += showInstruction;
            butoInstruction.MouseEnter += mouseEnterImgIns;
            Canvas.SetTop(butoInstruction, 700);
            Canvas.SetLeft(butoInstruction, 10);
            Globals.cvPause.Children.Add(butoInstruction);
        }
        private void showInstruction(object sender, MouseButtonEventArgs e) {
            showInstruction();

        }
        public void showInstruction()
        {
            imgInstruction = new Image();
            imgInstruction.Width = 1265;
            imgInstruction.Source = new BitmapImage(new Uri(@"/img/icons/demo.png", UriKind.Relative));
            Canvas.SetTop(imgInstruction, 0);
            Canvas.SetLeft(imgInstruction, 0);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation animacionMoverAparecer = createAnimationAppear();
            storyboard.Children.Add(animacionMoverAparecer);
            Storyboard.SetTarget(animacionMoverAparecer, imgInstruction);
            Storyboard.SetTargetProperty(animacionMoverAparecer, new PropertyPath(Label.OpacityProperty));
            storyboard.Begin(imgInstruction);

            Globals.cvPause.Children.Add(imgInstruction);
            createexitInstruction();
        }

        private void createexitInstruction()
        {
            labelMessageInstruction = new Label();
            labelMessageInstruction.Content = "VOLVER";
            labelMessageInstruction.Width = 300;
            labelMessageInstruction.FontFamily = new FontFamily("Showcard Gothic");
            labelMessageInstruction.FontSize = 75;
            labelMessageInstruction.MouseEnter += mouseEnterExit;
            labelMessageInstruction.MouseUp += removeInstruction;
            Canvas.SetTop(labelMessageInstruction, 1);
            Canvas.SetLeft(labelMessageInstruction, 5);
            Globals.cvPause.Children.Add(labelMessageInstruction);
        }

        private void mouseEnterExit(object sender, EventArgs e)
        {
            labelMessageInstruction.Cursor = Cursors.Hand;
        }

        private void removeInstruction(object sender, MouseButtonEventArgs e)
        {
            Globals.cvPause.Children.Remove(labelMessageInstruction);
            Globals.cvPause.Children.Remove(imgInstruction);
            if(Globals.state == 3)
            {
                Globals.img_pause.Source = new BitmapImage(new Uri(@"/img/icons/play.png", UriKind.Relative));
                Globals.cvPause.Background = new SolidColorBrush(Colors.Black);
                Globals.cvPause.Background.Opacity = 0.5;
            }
            else
            {
                Globals.cvPause.Background = null;
            }
        }


    }
}
