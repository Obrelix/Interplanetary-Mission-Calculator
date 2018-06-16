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
using System.Windows.Media.Animation;
using System.Threading;
using System.Security.Permissions;

namespace Mission_Calculator.Windows
{
    /// <summary>
    /// Interaction logic for winTransferOrbit.xaml
    /// </summary>
    public partial class winTransferOrbit : Window
    {
        #region "General Declaration"
        delegate void AddGraphics();
        Routes route;
        Thread AnimationRunner;
        PathGeometry rocketPath;
        Image img;
        Storyboard pathAnimationStoryboard;
        Ellipse OuterOrbit, InnerOrbit, InnerPlanet, OuterPlanet, Sun;
        Line line, line2;
        Path anglePath, HTOArrivalPath, HTODeparturePath;
        TextBlock InnerPlanetText, OuterPlanetText, AngleText, TransferOrbitText, SunText;
        Point centerPoint, outerOrbitPoint, innerOrbitPoint, sunPoint, line1EndPoint, line2EndPoint, innerPlanetPoint, outerPlanetPoint, arcStartPoint, arcEndPoint;
        Size outerOrbitSize, innerOrbitSize, arcSize, sunSize, planetSize, canvasSize, maxSize;
        double innerRadius, outerRadius, arcRadius, rel = 0.5, angleInner, angleOuter, timeCounter = 0;
        MatrixTransform imgMatrixTransform;
        winTransferOrbit form;
        #endregion

        #region "Constractor"

        public winTransferOrbit(Routes route)
        {
            InitializeComponent();
            form = this;
            this.route = route;
            this.Title = route.Name + "  [ " + route.ObjectFrom.Name + " ---> " + route.ObjectTo.Name + " ]";
            this.WindowState = WindowState.Normal;
            planetSize = new Size(30, 30);
            canvasSize = new Size( DrawCanvas.Width, DrawCanvas.Height);
            maxSize = new Size(DrawCanvas.Width, DrawCanvas.Height);
        }

        #endregion

        #region "Methods"

        private void rocketImageInit()
        {
            try
            {
                img = new Image
                {
                    Width = 50,
                    Height = 10,
                    MinWidth = 50,
                    MinHeight = 10,
                    Stretch = Stretch.UniformToFill,
                    Cursor = Cursors.Hand,
                    Source = new BitmapImage(new Uri(@"pack://application:,,/Images/Misc/Rockets.png")),
                };

                MatrixAnimationUsingPath matrixAnimation =
                    new MatrixAnimationUsingPath();
                matrixAnimation.PathGeometry = rocketPath;
                matrixAnimation.Duration = TimeSpan.FromSeconds(10);
                matrixAnimation.RepeatBehavior = RepeatBehavior.Forever;
                matrixAnimation.DoesRotateWithTangent = true;

                Storyboard.SetTargetName(matrixAnimation, "imgMatrixTransform");
                Storyboard.SetTargetProperty(matrixAnimation, new PropertyPath(MatrixTransform.MatrixProperty));

                pathAnimationStoryboard = new Storyboard();
                pathAnimationStoryboard.Children.Add(matrixAnimation);

                imgMatrixTransform = new MatrixTransform();
                img.RenderTransform = imgMatrixTransform;
                this.RegisterName("imgMatrixTransform", imgMatrixTransform);
                this.RegisterName("imgRocket", img);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AnimationRun()
        {
            try
            {
                angleInner = 0;
                angleOuter = route.DeparturePhaseAngle;
                AnimationRunner = new Thread(new ThreadStart(Runner));
                AnimationRunner.IsBackground = true;
                AnimationRunner.Start();
                //img.Loaded += delegate (object sender, RoutedEventArgs e)
                //{
                //    // Start the storyboard.

                //};
                pathAnimationStoryboard.Begin(this,true);
                this.DrawCanvas.Children.Add(img);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Runner()
        {
            try
            {
                while (timeCounter < 190)
                {
                    timeCounter++;
                    DrawCanvas.Dispatcher.Invoke(new AddGraphics(animation));
                    Thread.Sleep(50);
                }
                if (pathAnimationStoryboard != null) pathAnimationStoryboard.Stop(form);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void update(Size maxSize, Size canvasSize, Size planetSize)
        {
            /// note that the starting point of canvas (0,0) is the left top corner.
            try
            {
                cleanCanvas();
                this.planetSize = planetSize;
                SelestialObject sun = Globals.objList[Globals.objList.Count-1];
                //double rel = (route.ObjectInner.OrbitalPeriod / route.ObjectOuter.OrbitalPeriod) ;
                outerOrbitSize = maxSize;
                innerOrbitSize = new Size(outerOrbitSize.Width * rel, outerOrbitSize.Height * rel);
                arcSize = new Size(innerOrbitSize.Width / 4, innerOrbitSize.Height / 4);
                sunSize = new Size(planetSize.Width * 2, planetSize.Height * 2);

                innerRadius = innerOrbitSize.Width / 2;
                outerRadius = outerOrbitSize.Width / 2;
                arcRadius = arcSize.Width;

                centerPoint = new Point(canvasSize.Width / 2, canvasSize.Height / 2);
                outerOrbitPoint = new Point(canvasSize.Width - outerOrbitSize.Width, canvasSize.Height - outerOrbitSize.Height);
                innerOrbitPoint = new Point(centerPoint.X - innerRadius, centerPoint.Y - innerRadius);
                sunPoint = new Point(centerPoint.X - sunSize.Width / 2, centerPoint.Y - sunSize.Height / 2);
                line1EndPoint = new Point(centerPoint.X + innerRadius, centerPoint.Y);
                line2EndPoint = SMath.FindNextPointByAngleAndDistance(centerPoint, outerRadius, route.DeparturePhaseAngle);
                innerPlanetPoint = new Point(line1EndPoint.X - planetSize.Width / 2, line1EndPoint.Y - planetSize.Height / 2);
                outerPlanetPoint = new Point(line2EndPoint.X - planetSize.Width / 2, line2EndPoint.Y - planetSize.Height / 2);
                arcStartPoint = new Point(centerPoint.X + arcRadius, centerPoint.Y);
                arcEndPoint = SMath.FindNextPointByAngleAndDistance(centerPoint, arcRadius, route.DeparturePhaseAngle);

                line = Shapes.lineShape(centerPoint, line1EndPoint, Brushes.White);
                line2 = Shapes.lineShape(centerPoint, line2EndPoint, Brushes.White);
                OuterOrbit = Shapes.orbitShape(outerOrbitPoint, outerOrbitSize, route.ObjectOuter.objectColour);
                InnerOrbit = Shapes.orbitShape(innerOrbitPoint, innerOrbitSize, route.ObjectInner.objectColour);
                InnerPlanet = Shapes.planetShape(innerPlanetPoint, planetSize, route.ObjectInner.objectColour);
                OuterPlanet = Shapes.planetShape(outerPlanetPoint, planetSize, route.ObjectOuter.objectColour);
                Sun = Shapes.planetShape(sunPoint, sunSize, Brushes.Yellow);
                SweepDirection dir = (route.DeparturePhaseAngle < 0) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
                anglePath = Shapes.arcShape(arcStartPoint, arcEndPoint, arcSize, Brushes.SkyBlue, 90, dir);
                AngleText = Shapes.textBlock(route.strPhAngle, new Point(arcEndPoint.X + 30, arcEndPoint.Y + 10), 14, Brushes.SkyBlue);
                InnerPlanetText = Shapes.textBlock(route.ObjectInner.Name, new Point(innerPlanetPoint.X - planetSize.Width - 15, innerPlanetPoint.Y - 15), 16, route.ObjectInner.objectColour);
                OuterPlanetText = Shapes.textBlock(route.ObjectOuter.Name, new Point(outerPlanetPoint.X - planetSize.Width - 15, outerPlanetPoint.Y - 15), 16, route.ObjectOuter.objectColour);
                SunText = Shapes.textBlock(sun.Name, new Point(sunPoint.X - sunSize.Width, sunPoint.Y + 20), 16, sun.objectColour);


                if (route.ObjectInner.ParentObjectIndex == route.ObjectFrom.ParentObjectIndex)
                {
                    HTOArrivalPath = Shapes.arcShape(line1EndPoint, new Point(0, centerPoint.Y), new Size(83, 100), Brushes.LightSeaGreen, 90, dir);
                    HTODeparturePath = Shapes.arcShape(new Point(0, centerPoint.Y), line1EndPoint, new Size(83, 100), Brushes.Gray, 90, dir);
                    rocketPath = Shapes.animationShape(new Point(line1EndPoint.X - 6, line1EndPoint.Y), new Point(6, centerPoint.Y), new Size(83, 100), 90, dir);
                    TransferOrbitText = Shapes.textBlock("", new Point(10, centerPoint.Y -20), 10, Brushes.LightGreen);
                }
                else
                {
                    HTOArrivalPath = Shapes.arcShape(line2EndPoint, SMath.FindNextPointByAngleAndDistance(centerPoint, innerRadius, 180 + route.DeparturePhaseAngle), 
                        new Size(83, 100), Brushes.LightSeaGreen, 90 - route.DeparturePhaseAngle, SweepDirection.Counterclockwise);
                    HTODeparturePath = Shapes.arcShape(line2EndPoint, SMath.FindNextPointByAngleAndDistance(centerPoint, innerRadius, 180 + route.DeparturePhaseAngle), 
                        new Size(83, 100), Brushes.Gray, 90 - route.DeparturePhaseAngle, SweepDirection.Clockwise);
                    rocketPath = Shapes.animationShape(
                        SMath.FindNextPointByAngleAndDistance(centerPoint, outerRadius - 6, route.DeparturePhaseAngle),
                        SMath.FindNextPointByAngleAndDistance(centerPoint, innerRadius -6, 180 + route.DeparturePhaseAngle),
                        new Size(83, 100),90 - route.DeparturePhaseAngle, SweepDirection.Counterclockwise);
                    TransferOrbitText = Shapes.textBlock("", SMath.FindNextPointByAngleAndDistance(centerPoint, innerRadius, 180 + route.DeparturePhaseAngle), 10, Brushes.LightGreen);

                }

                TransferOrbitText.Inlines.Clear();
                for (int i = 8; i < route.ToShortRunList().Count -2; i++)
                    TransferOrbitText.Inlines.Add(route.ToShortRunList()[i]);
                rocketPath.Freeze();
                SunText.ToolTip = sun.Name;
                Sun.ToolTip = sun.Name;
                InnerOrbit.ToolTip = route.ObjectInner.Name;
                InnerPlanetText.ToolTip = route.ObjectInner.Name;
                InnerPlanet.ToolTip = route.ObjectInner.Name;
                OuterOrbit.ToolTip = route.ObjectOuter.Name;
                OuterPlanetText.ToolTip = route.ObjectOuter.Name;
                OuterPlanet.ToolTip = route.ObjectOuter.Name;
                AngleText.ToolTip = route.strPhAngle;
                anglePath.ToolTip = route.strPhAngle;
                line.ToolTip = route.strPhAngle;
                line2.ToolTip = route.strPhAngle;
                rocketImageInit();

                this.DrawCanvas.Children.Add(HTOArrivalPath);
                this.DrawCanvas.Children.Add(HTODeparturePath);
                this.DrawCanvas.Children.Add(OuterOrbit);
                this.DrawCanvas.Children.Add(InnerOrbit);
                this.DrawCanvas.Children.Add(line);
                this.DrawCanvas.Children.Add(line2);
                this.DrawCanvas.Children.Add(InnerPlanet);
                this.DrawCanvas.Children.Add(OuterPlanet);
                this.DrawCanvas.Children.Add(anglePath);
                this.DrawCanvas.Children.Add(Sun);
                this.DrawCanvas.Children.Add(AngleText);
                this.DrawCanvas.Children.Add(InnerPlanetText);
                this.DrawCanvas.Children.Add(SunText);
                this.DrawCanvas.Children.Add(OuterPlanetText);
                this.DrawCanvas.Children.Add(TransferOrbitText);

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void cleanCanvas()
        {
            try
            {
                
                if (imgMatrixTransform != null) this.UnregisterName("imgMatrixTransform");
                if (img != null) this.UnregisterName("imgRocket");
                if (DrawCanvas.Children.Contains(HTOArrivalPath)) this.DrawCanvas.Children.Remove(HTOArrivalPath);
                if (DrawCanvas.Children.Contains(HTODeparturePath)) this.DrawCanvas.Children.Remove(HTODeparturePath);
                if (DrawCanvas.Children.Contains(OuterOrbit)) this.DrawCanvas.Children.Remove(OuterOrbit);
                if (DrawCanvas.Children.Contains(InnerOrbit)) this.DrawCanvas.Children.Remove(InnerOrbit);
                if (DrawCanvas.Children.Contains(line)) this.DrawCanvas.Children.Remove(line);
                if (DrawCanvas.Children.Contains(line2)) this.DrawCanvas.Children.Remove(line2);
                if (DrawCanvas.Children.Contains(InnerPlanet)) this.DrawCanvas.Children.Remove(InnerPlanet);
                if (DrawCanvas.Children.Contains(OuterPlanet)) this.DrawCanvas.Children.Remove(OuterPlanet);
                if (DrawCanvas.Children.Contains(anglePath)) this.DrawCanvas.Children.Remove(anglePath);
                if (DrawCanvas.Children.Contains(Sun)) this.DrawCanvas.Children.Remove(Sun);
                if (DrawCanvas.Children.Contains(AngleText)) this.DrawCanvas.Children.Remove(AngleText);
                if (DrawCanvas.Children.Contains(InnerPlanetText)) this.DrawCanvas.Children.Remove(InnerPlanetText);
                if (DrawCanvas.Children.Contains(SunText)) this.DrawCanvas.Children.Remove(SunText);
                if (DrawCanvas.Children.Contains(OuterPlanetText)) this.DrawCanvas.Children.Remove(OuterPlanetText);
                if (DrawCanvas.Children.Contains(TransferOrbitText)) this.DrawCanvas.Children.Remove(TransferOrbitText);
                if (DrawCanvas.Children.Contains(img)) this.DrawCanvas.Children.Remove(img);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cleanForUpdate()
        {
            try
            {
                if (DrawCanvas.Children.Contains(line)) this.DrawCanvas.Children.Remove(line);
                if (DrawCanvas.Children.Contains(line2)) this.DrawCanvas.Children.Remove(line2);
                if (DrawCanvas.Children.Contains(InnerPlanet)) this.DrawCanvas.Children.Remove(InnerPlanet);
                if (DrawCanvas.Children.Contains(OuterPlanet)) this.DrawCanvas.Children.Remove(OuterPlanet);
                if (DrawCanvas.Children.Contains(anglePath)) this.DrawCanvas.Children.Remove(anglePath);
                if (DrawCanvas.Children.Contains(AngleText)) this.DrawCanvas.Children.Remove(AngleText);
                if (DrawCanvas.Children.Contains(InnerPlanetText)) this.DrawCanvas.Children.Remove(InnerPlanetText);
                if (DrawCanvas.Children.Contains(SunText)) this.DrawCanvas.Children.Remove(SunText);
                if (DrawCanvas.Children.Contains(OuterPlanetText)) this.DrawCanvas.Children.Remove(OuterPlanetText);
                if (DrawCanvas.Children.Contains(TransferOrbitText)) this.DrawCanvas.Children.Remove(TransferOrbitText);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void animation()
        {
            try
            {
                cleanForUpdate();
                double Incr;
                if (route.ObjectInner.ParentObjectIndex == route.ObjectFrom.ParentObjectIndex)
                {
                    Incr = SMath.map(0, route.ObjectOuter.OrbitalPeriod,0,7, route.ObjectInner.OrbitalPeriod);
                    Incr = (180 - route.DeparturePhaseAngle) / 190;
                    angleOuter += Incr;
                    angleInner += Incr * 2;
                }
                else
                {
                    Incr = Math.Abs((route.DeparturePhaseAngle + 180 + 360) / 190);
                    angleOuter += Incr / 4;
                    angleInner += Incr;
                }

                line1EndPoint = SMath.FindNextPointByAngleAndDistance(centerPoint, innerRadius, angleInner);
                line2EndPoint = SMath.FindNextPointByAngleAndDistance(centerPoint, outerRadius, angleOuter);
                innerPlanetPoint = new Point(line1EndPoint.X - planetSize.Width / 2, line1EndPoint.Y - planetSize.Height / 2);
                outerPlanetPoint = new Point(line2EndPoint.X - planetSize.Width / 2, line2EndPoint.Y - planetSize.Height / 2);
                InnerPlanet.Margin = new Thickness(innerPlanetPoint.X, innerPlanetPoint.Y, 0, 0);
                OuterPlanet.Margin = new Thickness(outerPlanetPoint.X, outerPlanetPoint.Y, 0, 0);
                this.DrawCanvas.Children.Add(InnerPlanet);
                this.DrawCanvas.Children.Add(OuterPlanet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void KillTheThread()
        {
            AnimationRunner.Abort();
        }

        #endregion

        #region "Event Handlers"

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //this.DrawCanvas.Children.Clear(); // Genocide :P
                update(canvasSize, maxSize, planetSize);
                expRouteInfo.Header = route.Name + " Info";
                TextBlock routeInfo = new TextBlock
                {
                    Margin = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 14,
                    TextAlignment = TextAlignment.Justify,
                    FontFamily = new FontFamily("Consolas"),
                };
                routeInfo.Inlines.Clear();
                foreach (Run obj in route.ToShortRunList()) routeInfo.Inlines.Add(obj);
                grdRouteInfo.Children.Add(routeInfo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (button.IsChecked == true)
                AnimationRun();
            else
            {
                KillTheThread();
                update(canvasSize, maxSize, planetSize);
                timeCounter = 0;
            }
        }

        #endregion

    }
}
