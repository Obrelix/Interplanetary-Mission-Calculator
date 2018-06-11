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
    class RoutesManager
    {
        public Grid parentGrid { get; set; }
        public TextBlock txt { get; set; }
        public Routes route { get; set; }

        public RoutesManager(Grid parentGrid, TextBlock txt, Routes route)
        {
            this.parentGrid = parentGrid;
            this.txt = txt;
            this.route = route;
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

    public class RoutesInfoControlSets
    {

        List<RoutesManager> routesCSList = new List<RoutesManager>();
        TextBlock txtRoute1;
        TextBlock txtRoute2;
        TextBlock txtRoute3;
        TextBlock txtRouteReturn;
        Grid grdRouteInfo;
        CheckBox checkBoxReturn;
        List<PlanetInfoControlSet> planetInfoCSList;
        List<PlanetInfoControlSet> activeList = new List<PlanetInfoControlSet>();
        Rectangle rect;
        public RoutesInfoControlSets(List<PlanetInfoControlSet> planetInfoCSList, Grid grdRouteInfo, CheckBox checkBoxReturn)
        {
            this.planetInfoCSList = planetInfoCSList;
            this.grdRouteInfo = grdRouteInfo;
            this.checkBoxReturn = checkBoxReturn;
            txtTravelInfoInit();
            rectInit();
        }

        private TextBlock dtxtTravelInfo()
        {
            return new TextBlock
            {
                Margin = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14,
                TextAlignment = TextAlignment.Justify,
                FontFamily = new FontFamily("Consolas"),
                Cursor = Cursors.Hand
            };
        }

        private void txtTravelInfoInit()
        {
            try
            {
                txtRoute1 = dtxtTravelInfo();
                txtRoute1.Name = "txtRoute1";
                txtRoute1.SetValue(Grid.RowProperty, 1);
                txtRoute1.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;

                txtRoute2 = dtxtTravelInfo();
                txtRoute2.Name = "txtRoute2";
                txtRoute2.SetValue(Grid.RowProperty, 2);
                txtRoute2.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;

                txtRoute3 = dtxtTravelInfo();
                txtRoute3.Name = "txtRoute3";
                txtRoute3.SetValue(Grid.RowProperty, 3);
                txtRoute3.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;

                txtRouteReturn = dtxtTravelInfo();
                txtRouteReturn.Name = "txtRouteReturn";
                txtRouteReturn.SetValue(Grid.RowProperty, 4);
                txtRouteReturn.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;
            }
            catch (Exception)
            {

                throw;
            }
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
                foreach (PlanetInfoControlSet obj in planetInfoCSList)
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
                foreach (RoutesManager obj in routesCSList) obj.Update();
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
        private RoutesManager CreateRoute(int i)
        {
            try
            {
                TextBlock txt;
                switch (i)
                {
                    case 1: txt = txtRoute1; break;
                    case 2: txt = txtRoute2; break;
                    case 3: txt = txtRoute3; break;
                    case 4: 
                    default: return  new RoutesManager(grdRouteInfo, txtRouteReturn,
                               new Routes("Return ", activeList[activeList.Count - 1].obj, activeList[0].obj,
                    activeList[activeList.Count - 1].exp.Foreground, activeList[0].exp.Foreground, activeList[0].exp.Foreground, Brushes.Tomato));
                }
                return new RoutesManager(grdRouteInfo, txt,
                                    new Routes("Route " + i, activeList[i - 1].obj, activeList[i].obj,
                                    activeList[i - 1].exp.Foreground, activeList[i].exp.Foreground, activeList[i].exp.Foreground, Brushes.Tomato));
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void txtTravelInfo_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            showTransferOrbit(((TextBlock)sender).Name);
        }

        private void showTransferOrbit(string controlName)
        {
            try
            {
                foreach (RoutesManager obj in routesCSList)
                {
                    if (obj.txt.Name == controlName)
                        new winTransferOrbit(obj.route).Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
