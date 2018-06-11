using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Mission_Calculator.Classes
{
    public static class Shapes
    {
        public static Ellipse planetShape(Point startPoint, Size size, Brush brush)
        {
            Ellipse planet = new Ellipse
            {
                SnapsToDevicePixels = true,
                Visibility = Visibility.Visible,
                Stroke = brush,
                Fill = brush,
                StrokeThickness = 3,
                Height = size.Height,
                Width = size.Width,
                Margin = new Thickness(startPoint.X, startPoint.Y, 0, 0)
            };
            planet.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            return planet;
        }

        public static Ellipse orbitShape(Point startPoint, Size size, Brush brush)
        {
            try
            {
                Ellipse Orbit = new Ellipse
                {
                    SnapsToDevicePixels = true,
                    Visibility = Visibility.Visible,
                    StrokeThickness = 3,
                    Stroke = brush,
                    Height = size.Height,
                    Width = size.Width,
                    Margin = new Thickness(startPoint.X, startPoint.Y, 0, 0)
                };
                Orbit.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                return Orbit;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Line lineShape(Point startPoint, Point endPoint, Brush brush)
        {
            try
            {
                Line line = new Line
                {
                    SnapsToDevicePixels = true,
                    Visibility = Visibility.Visible,
                    StrokeThickness = 3,
                    Stroke = brush,
                    X1 = startPoint.X,
                    Y1 = startPoint.Y,
                    X2 = endPoint.X,
                    Y2 = endPoint.Y
                };
                line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                return line;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Path arcShape(Point startPoint, Point endPoint, Size size, Brush brush, double rotationAngle, SweepDirection dir)
        {
            try
            {
                PathGeometry ArcPath = new PathGeometry();
                PathFigure ArcFigure = new PathFigure();
                ArcFigure.StartPoint = startPoint;
                ArcFigure.Segments.Add(new ArcSegment(endPoint, size, rotationAngle, false, dir, true));
                ArcPath.Figures.Add(ArcFigure);
                Path path = new Path
                {
                    SnapsToDevicePixels = true,
                    Visibility = Visibility.Visible,
                    StrokeThickness = 3,
                    Stroke = brush,
                    Data = ArcPath,
                };
                path.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                return path;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static TextBlock textBlock(string txt, Point startPoint, int size, Brush brush)
        {
            return new TextBlock
            {
                Visibility = Visibility.Visible,
                Text = txt,
                Foreground = brush,
                FontSize = size,
                Margin = new Thickness(startPoint.X, startPoint.Y, 0, 0)
            };
        }


    }
}
