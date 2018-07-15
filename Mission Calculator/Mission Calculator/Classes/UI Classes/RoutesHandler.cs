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
using Mission_Calculator.Classes.Static_Classes;

namespace Mission_Calculator.Classes
{
    class RoutesInfo
    {
        #region "General Declaration"

        public Grid parentGrid { get; set; }
        public Routes route { get; set; }
        private Border txtBorder;

        #endregion

        #region "Constractor"

        public RoutesInfo(Grid parentGrid, Routes route, int grdRowIndex)
        {
            this.parentGrid = parentGrid;
            this.txtBorder = txtRouteInfo(grdRowIndex);
            this.route = route;
        }

        #endregion

        #region "Methods"
        private Border txtRouteInfo(int grdRowIndex)
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
                Cursor = Cursors.Hand,
                
            };
            txt.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;
            if (grdRowIndex == 999) grdRowIndex = parentGrid.ColumnDefinitions.Count - 2;
            Border brd = new Border
            {
                Background = Brushes.Transparent,
                BorderBrush = new SolidColorBrush { Color = Color.FromRgb(102, 255, 179), Opacity = 0.1 },
                BorderThickness = new Thickness(3),
                Margin = new Thickness(5),
                Opacity = 0.9
            };
            brd.Child = txt;
            brd.SetValue(Grid.RowProperty,1);
            brd.SetValue(Grid.ColumnProperty, grdRowIndex);
            brd.MouseEnter += brdMouseEnter;
            brd.MouseLeave += brdMouseLeave;
            return brd;
        }

        public void Update()
        {
            try
            {
                if (parentGrid.Children.Contains(txtBorder)) parentGrid.Children.Remove(txtBorder);
                ((TextBlock)txtBorder.Child).Inlines.Clear();
                foreach (Run obj in route.ToShortRunList()) ((TextBlock)txtBorder.Child).Inlines.Add(obj);
                parentGrid.Children.Add(txtBorder);
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

        private void brdMouseEnter(object sender, MouseEventArgs e)
        {
            ((Border)sender).BorderBrush = new SolidColorBrush { Color = Color.FromRgb(102, 255, 179), Opacity = 0.5 };
            ((Border)sender).BorderThickness = new Thickness(6);
            ((Border)sender).Margin = new Thickness(2);
        }

        private void brdMouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).BorderBrush = new SolidColorBrush { Color = Color.FromRgb(102, 255, 179), Opacity = 0.1 };
            ((Border)sender).BorderThickness = new Thickness(3);
            ((Border)sender).Margin = new Thickness(5);
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
        Grid grdRouteInfo;
        ScrollViewer viewer;

        #endregion

        #region "Constractor"

        public RoutesInfoHandler(List<PlanetInfo> planetInfoCSList, pgMissionCalculator parent, CheckBox chkReturn)
        {
            this.planetInfoCSList = planetInfoCSList;
            this.parent = parent;
            this.chkReturn = chkReturn;
            dblDVBudget = 0;
            dblTravelTime = 0;
            grdRouteInfo = UIControls.grdPInit(1);
            viewer = UIControls.viewerInit();
            //viewer.MaxWidth = 500;
            viewer.Content = grdRouteInfo;
            viewer.SetValue(Grid.RowProperty, 3);
            viewer.SetValue(Grid.ColumnProperty, 1);
            parent.grdMain.Children.Add(viewer);
        }

        #endregion

        #region "Methods"

        private void grdRouteInfoAddColumn()
        {
            try
            {
                grdRouteInfo.ColumnDefinitions[grdRouteInfo.ColumnDefinitions.Count - 1].Width = new GridLength(0, GridUnitType.Auto);
                grdRouteInfo.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5) });
                viewer.MaxWidth = parent.ActualWidth - 70;
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
                    {
                        routesCSList.Add(CreateRoute(i));
                    }
                    if (chkReturn.IsChecked == true)
                        routesCSList.Add(CreateRoute(999));
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
                viewer.Content = null;
                grdRouteInfo = UIControls.grdPInit(1);
                viewer.Content = grdRouteInfo;
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
                grdRouteInfoAddColumn();
                if (intListIndex == 999)
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
                route = new Routes(Name, PIFrom, PITo, Brushes.LightGoldenrodYellow);
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
