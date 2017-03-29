using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace bunny.src.presentacion.objects_img
{
    class Caca
    {
        public Caca(Canvas cvCaca)
        {
            int Horizontal = 10;
            int Vertical = 20;


            Ellipse EllipseA = new Ellipse();
            EllipseA.Stroke = System.Windows.Media.Brushes.Black;
            EllipseA.Fill = System.Windows.Media.Brushes.DarkBlue;
            EllipseA.HorizontalAlignment = HorizontalAlignment.Left;
            EllipseA.VerticalAlignment = VerticalAlignment.Center;
            EllipseA.Width = 50;
            EllipseA.Height = 75;


            myGrid.Children.Add(myEllipse);
        }
    }
}

          /*  <Canvas x:Name="cvCaca" Height="45.3" Canvas.Left="362.667" Canvas.Top="390.55" Width="74" Opacity="0">
                <Ellipse Fill = "#FF825919" Height="23.05" Stroke="Black" Canvas.Top="22.25" Width="74"/>
                <Ellipse Fill = "#FF825919" Height="22.25" Canvas.Left="9.6" Stroke="Black" Canvas.Top="13.8" Width="56.4"/>
                <Ellipse Fill = "#FF825919" Height="16.25" Canvas.Left="18.8" Stroke="Black" Canvas.Top="7.2" Width="38.8"/>
                <Ellipse Fill = "#FF825919" Height="13.8" Canvas.Left="28" Stroke="Black" Width="18.8"/>
            </Canvas>   */
