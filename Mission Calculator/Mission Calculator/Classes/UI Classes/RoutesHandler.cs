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
using Mission_Calculator.Pages;
using Mission_Calculator.Enumerators;

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
            this.txt = txtRouteInfo(grdRowIndex);
            this.route = route;
        }

        #endregion

        #region "Methods"

        private TextBlock txtRouteInfo(int grdRowIndex)
        {
            TextBlock txt = new TextBlock
            {
                Name = "txtRoute" + grdRowIndex,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14,
                TextAlignment = TextAlignment.Justify,
                FontFamily = new FontFamily("Consolas"),
                Cursor = Cursors.Hand
            };
            txt.SetValue(Grid.RowProperty, grdRowIndex);
            txt.SetValue(Grid.ColumnProperty, 1);
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

        double dblDVBudget, dblTravelTime;
        List<RoutesInfo> routesCSList = new List<RoutesInfo>();
        pgMissionCalculator parent;
        CheckBox chkReturn;
        List<PlanetInfo> planetInfoCSList;
        List<PlanetInfo> activeList = new List<PlanetInfo>();
        Rectangle rect;


        #endregion

        #region "Constractor"

        public RoutesInfoHandler(List<PlanetInfo> planetInfoCSList, pgMissionCalculator parent, CheckBox chkReturn)
        {
            this.planetInfoCSList = planetInfoCSList;
            this.parent = parent;
            this.chkReturn = chkReturn;
            dblDVBudget = 0;
            dblTravelTime = 0;
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
            Grid.SetRowSpan(rect, 8);
            Grid.SetColumnSpan(rect, 6);
            rect.Fill = new SolidColorBrush { Color = Color.FromRgb(5, 47, 60), Opacity = 0.5 };
        }

        public void Update()
        {
            try
            {
                if (this == null) return;
                Reset();
                routesCSList.Clear();
                activeList.Clear();
                foreach (PlanetInfo obj in planetInfoCSList)
                    if (obj.isEnabled())
                        activeList.Add(obj);
                if (activeList.Count > 1)
                {
                    for (int i = 1; i < activeList.Count; i++)
                        routesCSList.Add(CreateRoute(i));
                    if (chkReturn.IsChecked == true)
                        routesCSList.Add(CreateRoute(4));
                }
                foreach (RoutesInfo obj in routesCSList)
                {
                    obj.Update();
                    dblDVBudget += obj.route.DeltaVBugdet;
                    dblTravelTime += obj.route.TranferTime;
                }
                parent.txtDVBudget.Text = string.Format("{0:n0}", dblDVBudget) + " m/s";
                parent.txtTotaTime.Text = Globals.FormatTimeFromSecs(dblTravelTime);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Reset()
        {
            try
            {
                dblDVBudget = 0;
                dblTravelTime = 0;
                parent.txtDVBudget.Text = "";
                parent.txtTotaTime.Text = "";
                parent.grdRouteInfo.Children.Clear();
                if (rect != null) parent.grdRouteInfo.Children.Add(rect);
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
                PlanetInfo PIFrom, PITo;
                string Name = string.Empty;
                if (intListIndex > 3)
                {
                    PIFrom = activeList[activeList.Count - 1];
                    PITo = activeList[0];
                    Name = "Return ";
                }
                else
                {
                    Name = "Route ";
                    PIFrom = activeList[intListIndex - 1];
                    PITo = activeList[intListIndex];
                }
                route = new Routes(Name, PIFrom, PITo, Brushes.Tomato);
                return new RoutesInfo(parent.grdRouteInfo, route, intListIndex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
