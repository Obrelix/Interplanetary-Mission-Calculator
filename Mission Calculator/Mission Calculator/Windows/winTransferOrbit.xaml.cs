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
            this.Title = route.Name + "  [ " + route.ObjectFrom.Name + " ---> " + route.ObjectTo.Name + " ]";
            this.WindowState = WindowState.Normal;
        }

        

        private void update(Size maxSize, Size canvasSize, Size planetSize)
        {
            /// note that the starting point of canvas (0,0) is the left top corner.
            try
            {
                SelestialObject sun = Globals.objList[17];
                Size outerOrbitSize = maxSize;
                Size innerOrbitSize = new Size(outerOrbitSize.Width / 2, outerOrbitSize.Height / 2);
                Size arcSize = new Size(innerOrbitSize.Width / 4, innerOrbitSize.Height / 4);
                Size sunSize = new Size(planetSize.Width * 2, planetSize.Height * 2);

                double innerRadius = innerOrbitSize.Width / 2;
                double outerRadius = outerOrbitSize.Width / 2;
                double arcRadius = arcSize.Width;

                Point centerPoint = new Point(canvasSize.Width / 2, canvasSize.Height / 2);
                Point outerOrbitPoint = new Point(canvasSize.Width - outerOrbitSize.Width, canvasSize.Height - outerOrbitSize.Height);
                Point innerOrbitPoint = new Point(centerPoint.X - innerRadius, centerPoint.Y - innerRadius);
                Point sunPoint = new Point(centerPoint.X - sunSize.Width / 2, centerPoint.Y - sunSize.Height / 2);
                Point line1EndPoint = new Point(centerPoint.X + innerRadius, centerPoint.Y);
                Point line2EndPoint = SMath.FindNextPointByAngleAndDistance(centerPoint, outerRadius, route.DeparturePhaseAngle);
                Point innerPlanetPoint = new Point(line1EndPoint.X - planetSize.Width / 2, line1EndPoint.Y - planetSize.Height / 2);
                Point outerPlanetPoint = new Point(line2EndPoint.X - planetSize.Width / 2, line2EndPoint.Y - planetSize.Height / 2);
                Point arcStartPoint = new Point(centerPoint.X + arcRadius, centerPoint.Y);
                Point arcEndPoint = SMath.FindNextPointByAngleAndDistance(centerPoint, arcRadius, route.DeparturePhaseAngle);

                Line line = Shapes.lineShape(centerPoint, line1EndPoint, Brushes.White);
                Line line2 = Shapes.lineShape(centerPoint, line2EndPoint, Brushes.White);
                Ellipse OuterOrbit = Shapes.orbitShape(outerOrbitPoint, outerOrbitSize, route.ObjectOuter.objectColour);
                Ellipse InnerOrbit = Shapes.orbitShape(innerOrbitPoint, innerOrbitSize, route.ObjectInner.objectColour);
                Ellipse InnerPlanet = Shapes.planetShape(innerPlanetPoint, planetSize, route.ObjectInner.objectColour);
                Ellipse OuterPlanet = Shapes.planetShape(outerPlanetPoint, planetSize, route.ObjectOuter.objectColour);
                Ellipse Sun = Shapes.planetShape(sunPoint, sunSize, Brushes.Yellow);
                SweepDirection dir = (route.DeparturePhaseAngle < 0) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
                Path path = Shapes.arcShape(arcStartPoint, arcEndPoint, arcSize, Brushes.SkyBlue, 90, dir);

                TextBlock AngleText = Shapes.textBlock(route.strPhAngle, new Point(arcEndPoint.X+30, arcEndPoint.Y +10), 14, Brushes.SkyBlue);
                TextBlock InnerPlanetText = Shapes.textBlock(route.ObjectInner.Name, new Point(innerPlanetPoint.X - planetSize.Width - 15, innerPlanetPoint.Y- 15), 16, route.ObjectInner.objectColour);
                TextBlock OuterPlanetText = Shapes.textBlock(route.ObjectOuter.Name, new Point(outerPlanetPoint.X - planetSize.Width - 15, outerPlanetPoint.Y -15), 16, route.ObjectOuter.objectColour);
                TextBlock SunText = Shapes.textBlock(sun.Name, new Point(sunPoint.X-sunSize.Width, sunPoint.Y +20 ), 16, sun.objectColour);

                SunText.ToolTip = sun.Name;
                Sun.ToolTip = sun.Name;
                InnerOrbit.ToolTip = route.ObjectInner.Name;
                InnerPlanetText.ToolTip = route.ObjectInner.Name;
                InnerPlanet.ToolTip = route.ObjectInner.Name;
                OuterOrbit.ToolTip = route.ObjectOuter.Name;
                OuterPlanetText.ToolTip = route.ObjectOuter.Name;
                OuterPlanet.ToolTip = route.ObjectOuter.Name;
                AngleText.ToolTip = route.strPhAngle;
                path.ToolTip = route.strPhAngle;
                line.ToolTip = route.strPhAngle;
                line2.ToolTip = route.strPhAngle;

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
            catch (Exception)
            {

                throw;
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DrawCanvas.Children.Clear(); // Genocide :P
            Size planetSize = new Size(30, 30);
            Size canvasSize = new Size(DrawCanvas.Width, DrawCanvas.Height);
            Size maxSize = new Size(DrawCanvas.Width, DrawCanvas.Height);
            update(canvasSize, maxSize, planetSize);
        }
    }
}
