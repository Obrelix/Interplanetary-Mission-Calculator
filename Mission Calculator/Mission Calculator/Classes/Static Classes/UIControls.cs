using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Mission_Calculator.Classes.Static_Classes
{
    public static class UIControls
    {

        public static StackPanel pnlInit(Orientation orientation)
        {
            return new StackPanel { Orientation = orientation };
        }

        public static ScrollViewer viewerInit()
        {
            return new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
        }

        public static Grid grdPInit(int intColumCounter)
        {
            Grid grd = new Grid();
            grd.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5) });
            for (int i = 0; i < intColumCounter; i++)
                grd.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0, GridUnitType.Auto) });
            grd.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5) });

            grd.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5) });
            grd.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            grd.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5) });

            Rectangle rect = rectInit();
            grd.Children.Add(rect);
            return grd;
        }

        public static Rectangle rectInit()
        {
            Rectangle rect = new Rectangle
            {
                Name = "rectRouteInfo",
                Margin = new Thickness(0),
                RadiusX = 10,
                RadiusY = 10,

            };
            Grid.SetRowSpan(rect, 20);
            Grid.SetColumnSpan(rect, 12);
            rect.Fill = new SolidColorBrush { Color = Color.FromRgb(5, 47, 60), Opacity = 0.5 };
            return rect;
        }

    }
}
