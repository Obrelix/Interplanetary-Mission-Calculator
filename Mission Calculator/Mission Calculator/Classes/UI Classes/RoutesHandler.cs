using Mission_Calculator.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Mission_Calculator.Classes
{
    class RoutesInfo
    {
        public Grid parentGrid { get; set; }
        public TextBlock txt { get; set; }
        public Routes route { get; set; }

        public RoutesInfo(Grid parentGrid, Routes route, int grdRowIndex)
        {
            this.parentGrid = parentGrid;
            this.txt = txtTravelInfo(grdRowIndex);
            this.route = route;
        }

        private TextBlock txtTravelInfo(int grdRowIndex)
        {
            TextBlock txt = new TextBlock
            {
                Name = "txtRoute" + grdRowIndex,
                Margin = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14,
                TextAlignment = TextAlignment.Justify,
                FontFamily = new FontFamily("Consolas"),
                Cursor = Cursors.Hand
            };
            txt.SetValue(Grid.RowProperty, grdRowIndex);
            txt.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;
            return txt;
        }


        private void txtTravelInfo_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                new winTransferOrbit(route).Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update()
        {
            try
            {
                if (parentGrid.Children.Contains(txt)) parentGrid.Children.Remove(txt);
                txt.Inlines.Clear();
                foreach (Run obj in route.ToShortRunList()) txt.Inlines.Add(obj);
                parentGrid.Children.Add(txt);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }

    public class RoutesInfoHandler
    {

        List<RoutesInfo> routesCSList = new List<RoutesInfo>();
        Grid grdRouteInfo;
        CheckBox checkBoxReturn;
        List<PlanetInfo> planetInfoCSList;
        List<PlanetInfo> activeList = new List<PlanetInfo>();
        Rectangle rect;
        public RoutesInfoHandler(List<PlanetInfo> planetInfoCSList, Grid grdRouteInfo, CheckBox checkBoxReturn)
        {
            this.planetInfoCSList = planetInfoCSList;
            this.grdRouteInfo = grdRouteInfo;
            this.checkBoxReturn = checkBoxReturn;
            rectInit();
        }

        
        private void rectInit()
        {
            rect = new Rectangle
            {
                Name = "rectRouteInfo",
                Margin = new Thickness(0),
                RadiusX = 10,
                RadiusY = 10,

            };
            Grid.SetRowSpan(rect, 6);
            rect.Fill = new SolidColorBrush { Color = Color.FromRgb(5, 47, 60), Opacity = 0.5 };
        }

        public void Update()
        {
            try
            {
                if (this == null) return;
                routesCSList.Clear();
                activeList.Clear();
                foreach (PlanetInfo obj in planetInfoCSList)
                    if (obj.isEnabled())
                        activeList.Add(obj);
                if (activeList.Count > 1)
                {
                    for (int i = 1; i < activeList.Count; i++)
                         routesCSList.Add(CreateRoute(i));
                    if (checkBoxReturn.IsChecked == true)
                        routesCSList.Add(CreateRoute(4));
                }
                gridReset();
                foreach (RoutesInfo obj in routesCSList) obj.Update();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void gridReset()
        {
            try
            {
                grdRouteInfo.Children.Clear();
                if(rect != null)grdRouteInfo.Children.Add(rect);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private RoutesInfo CreateRoute(int i)
        {
            try
            {         
                if(i > 3) return  new RoutesInfo(grdRouteInfo,
                               new Routes("Return ", activeList[activeList.Count - 1].obj, activeList[0].obj, activeList[0].exp.Foreground, Brushes.Tomato), i);
                else return new RoutesInfo(grdRouteInfo, 
                                new Routes("Route " + i, activeList[i - 1].obj, activeList[i].obj, activeList[i].exp.Foreground, Brushes.Tomato), i);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
