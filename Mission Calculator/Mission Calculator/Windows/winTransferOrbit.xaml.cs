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
            this.DrawCanvas.Children.Clear(); // Genocide :P
            this.WindowState = WindowState.Normal;
            this.Title = route.Name + "  [ " + route.ObjectFrom.Name + " ---> " + route.ObjectTo.Name + " ]";
            update();
        }

        

        private void update()
        {
            /// note that the starting point of canvas (0,0) is the left top corner.
            double angle = route.DeparturePhaseAngle * Math.PI / 180;//convert to rads
            SweepDirection dir;
            string strSun = "Kerbol";
            Size canvasSize = new Size(DrawCanvas.Width, DrawCanvas.Height);
            Size outerOrbitSize = new Size(DrawCanvas.Width, DrawCanvas.Height);
            Size innerOrbitSize = new Size(outerOrbitSize.Width / 2, outerOrbitSize.Height / 2);
            Size arcSize = new Size(innerOrbitSize.Width / 4, innerOrbitSize.Height / 4);
            Size planetSize = new Size(30, 30);
            Size sunSize = new Size(planetSize.Width * 2, planetSize.Height * 2);
            double innerRadius = innerOrbitSize.Width / 2;
            double outerRadius = outerOrbitSize.Width / 2;
            double arcRadius = arcSize.Width;
            Point centerPoint = new Point(canvasSize.Width / 2, canvasSize.Height / 2);
            Point outerOrbitPoint = new Point(canvasSize.Width - outerOrbitSize.Width, canvasSize.Height - outerOrbitSize.Height);
            Point innerOrbitPoint = new Point(centerPoint.X - innerRadius, centerPoint.Y - innerRadius); 
            Point sunPoint = new Point(centerPoint.X - sunSize.Width / 2, centerPoint.Y - sunSize.Height / 2);
            Point line1EndPoint = new Point(centerPoint.X + innerRadius, centerPoint.Y);
            Point line2EndPoint = new Point(outerRadius + Math.Cos(angle) * outerRadius, outerRadius - Math.Sin(angle) * outerRadius);
            Point innerPlanetPoint = new Point(line1EndPoint.X - planetSize.Width / 2, line1EndPoint.Y - planetSize.Height / 2);
            Point outerPlanetPoint = new Point(line2EndPoint.X - planetSize.Width / 2, line2EndPoint.Y - planetSize.Height / 2);
            Point arcStartPoint = new Point(centerPoint.X + arcRadius, centerPoint.Y);
            Point arcEndPoint = new Point(centerPoint.X + Math.Cos(angle) * arcRadius, centerPoint.Y - Math.Sin(angle) * arcRadius);

            Ellipse OuterOrbit = Shapes.orbitShape(outerOrbitPoint, outerOrbitSize, route.ObjectOuter.objectColour);
            Ellipse InnerOrbit = Shapes.orbitShape(innerOrbitPoint, innerOrbitSize, route.ObjectInner.objectColour);
            Line line = Shapes.lineShape(centerPoint, line1EndPoint, Brushes.White);
            Line line2 = Shapes.lineShape(centerPoint, line2EndPoint, Brushes.White);
            Ellipse InnerPlanet = Shapes.planetShape(innerPlanetPoint, planetSize, route.ObjectInner.objectColour);
            Ellipse OuterPlanet = Shapes.planetShape(outerPlanetPoint, planetSize, route.ObjectOuter.objectColour);
            Ellipse Sun = Shapes.planetShape(sunPoint, sunSize, Brushes.Yellow);
            dir = (route.DeparturePhaseAngle < 0) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
            Path path = Shapes.arcShape(arcStartPoint, arcEndPoint, arcSize, Brushes.SkyBlue, 90, dir);
            TextBlock AngleText = Shapes.textBlock(route.strPhAngle, arcEndPoint, 14, Brushes.SkyBlue);
            TextBlock InnerPlanetText = Shapes.textBlock(route.ObjectInner.Name, innerPlanetPoint, 14, route.ObjectInner.objectColour);
            TextBlock OuterPlanetText = Shapes.textBlock(route.ObjectOuter.Name, outerPlanetPoint, 14, route.ObjectOuter.objectColour);
            TextBlock SunText = Shapes.textBlock(strSun, sunPoint, 14, Brushes.Yellow);
            SunText.ToolTip = strSun;
            Sun.ToolTip = strSun;
            InnerPlanetText.ToolTip = route.ObjectInner.Name;
            InnerPlanet.ToolTip = route.ObjectInner.Name;
            OuterPlanetText.ToolTip = route.ObjectOuter.Name;
            OuterPlanet.ToolTip = route.ObjectOuter.Name;
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
            
            
}
}
