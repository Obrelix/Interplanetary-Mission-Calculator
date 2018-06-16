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
        #region "General Declaration"

        public Grid parentGrid { get; set; }
        public TextBlock txt { get; set; }
        public Routes route { get; set; }

        #endregion

        #region "Constractor"

        public RoutesInfo(Grid parentGrid, Routes route, int grdRowIndex)
        {
            this.parentGrid = parentGrid;
            this.txt = txtTravelInfo(grdRowIndex);
            this.route = route;
        }

        #endregion

        #region "Methods"

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



        #endregion

        #region "Event handlers"

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

        #endregion

    }

    public class RoutesInfoHandler
    {

        #region "General Declaration"

        List<RoutesInfo> routesCSList = new List<RoutesInfo>();
        Grid grdRouteInfo;
        CheckBox checkBoxReturn;
        List<PlanetInfo> planetInfoCSList;
        List<PlanetInfo> activeList = new List<PlanetInfo>();
        Rectangle rect;


        #endregion

        #region "Constractor"

        public RoutesInfoHandler(List<PlanetInfo> planetInfoCSList, Grid grdRouteInfo, CheckBox checkBoxReturn)
        {
            this.planetInfoCSList = planetInfoCSList;
            this.grdRouteInfo = grdRouteInfo;
            this.checkBoxReturn = checkBoxReturn;
            rectInit();
        }

        #endregion

        #region "Methods"
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
                if (rect != null) grdRouteInfo.Children.Add(rect);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private RoutesInfo CreateRoute(int intListIndex)
        {
            try
            {
                Routes route;
                if (intListIndex > 3) route = new Routes("Return ", activeList[activeList.Count - 1].obj, activeList[0].obj, activeList[0].exp.Foreground, Brushes.Tomato);
                else route = new Routes("Route " + intListIndex, activeList[intListIndex - 1].obj, activeList[intListIndex].obj, activeList[intListIndex].exp.Foreground, Brushes.Tomato);
                return new RoutesInfo(grdRouteInfo, route, intListIndex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
