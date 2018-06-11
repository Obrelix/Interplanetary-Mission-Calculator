using Mission_Calculator.Classes;
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
using System.Windows.Shapes;

namespace Mission_Calculator.Windows
{
    /// <summary>
    /// Interaction logic for winTransferOrbit.xaml
    /// </summary>
    public partial class winTransferOrbit : Window
    {

        Routes route;
        public winTransferOrbit(Routes route)
        {
            InitializeComponent();
            this.route = route;
            this.DrawCanvas.Children.Clear();
            this.WindowState = WindowState.Normal;
            this.Title = route.Name + "  [ " + route.ObjectFrom.Name + " ---> " + route.ObjectTo.Name + " ]";
            update();
        }

        

        private void update()
        {

            //angle = AngleDegrees * Math.PI / 180;//convert to rads
            string strSun = "Kerbol";
            Ellipse OuterOrbit = Shapes.orbitShape(new Point(), new Size(), Brushes.Orange);
            Ellipse InnerOrbit = Shapes.orbitShape(new Point(), new Size(), Brushes.Blue);
            Line line = Shapes.lineShape(new Point(), new Point(), Brushes.White);
            Line line2 = Shapes.lineShape(new Point(), new Point(), Brushes.White);
            Ellipse InnerPlanet = Shapes.orbitShape(new Point(), new Size(), Brushes.Blue);
            Ellipse OuterPlanet = Shapes.orbitShape(new Point(), new Size(), Brushes.Orange);
            Ellipse Sun = Shapes.orbitShape(new Point(), new Size(), Brushes.Yellow);
            Path path = Shapes.arcShape(new Point(), new Point(), new Size(), Brushes.SkyBlue, 90, SweepDirection.Clockwise);
            TextBlock AngleText = Shapes.textBlock(route.strPhAngle, new Point(), 14, Brushes.SkyBlue);
            TextBlock InnerPlanetText = Shapes.textBlock(route.ObjectInner.Name, new Point(), 14, Brushes.Blue);
            TextBlock OuterPlanetText = Shapes.textBlock(route.ObjectOuter.Name, new Point(), 14, Brushes.Orange);
            TextBlock SunText = Shapes.textBlock(strSun, new Point(), 14, Brushes.Orange);
            this.DrawCanvas.Children.Add(OuterOrbit);
            this.DrawCanvas.Children.Add(InnerOrbit);
            this.DrawCanvas.Children.Add(line);
            this.DrawCanvas.Children.Add(line2);
            this.DrawCanvas.Children.Add(InnerPlanet);
            this.DrawCanvas.Children.Add(OuterPlanet);
            this.DrawCanvas.Children.Add(path);
            this.DrawCanvas.Children.Add(Sun);
            this.DrawCanvas.Children.Add(AngleText);
            this.DrawCanvas.Children.Add(InnerPlanetText);
            this.DrawCanvas.Children.Add(SunText);
            this.DrawCanvas.Children.Add(OuterPlanetText);
        }
            
            
}
}
