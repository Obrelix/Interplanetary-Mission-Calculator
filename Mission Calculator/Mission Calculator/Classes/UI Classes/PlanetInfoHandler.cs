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
using System.Windows.Media.Imaging;
using Mission_Calculator.Enumerators;

namespace Mission_Calculator.Classes
{
    public class PlanetInfo
    {
        #region "General Declaration"
        public PlaneInfoHandler parent;
        public Brush Colour { get; set; }
        public int Index { get; set; }
        public SelestialObject obj { get; set; }
        public ComboBox cbo { get; set; }
        public Expander exp { get; set; }
        public TextBlock txt { get; set; }
        public CheckBox chk { get; set; }
        public CheckBox chkOrbit { get; set; }
        public RadioButton rdo { get; set; }
        public Image img { get; set; }
        public Grid txtparentGrid { get; set; }
        public Grid expParentGrid { get; set; }
        public List<SelestialObject> planetList { get; set; }
        public Orbit orbit { get; set; }

        #endregion

        #region "Constractor"

        public PlanetInfo(int grdRowIndex, Grid txtparentGrid, Grid expParentGrid, Brush foreground, PlaneInfoHandler parent)
        {
            this.parent = parent;
            this.txtparentGrid = txtparentGrid;
            this.txt = txtPlanetInfo(grdRowIndex, 1);
            this.img = imgPlanetInfo(grdRowIndex, 2);
            this.exp = expPlanetInfo(grdRowIndex, 1, foreground);
            expParentGrid.Children.Add(exp);    
            this.planetList = Globals.objList;
            cboInit();
            this.obj = planetList[cbo.SelectedIndex];
            Colour = exp.Foreground;
            this.orbit = Orbit.Surface;
        }

        #endregion

        #region "Methods"

        private Expander expPlanetInfo(int grdRowIndex, int grdColumnIndex, Brush foreground)
        {
            try
            {

                Grid grd = new Grid();
                StackPanel pnlMain = new StackPanel { Orientation = Orientation.Horizontal };
                StackPanel pnlCBO = new StackPanel();
                cbo = cboPlanetInfo(grdRowIndex);
                pnlCBO.Children.Add(cbo);
                StackPanel pnlCHK = new StackPanel { Width = 88 };

                if (grdRowIndex == 1)
                {
                    this.chk = chkPlanetInfo(1, foreground);
                    pnlCHK.Children.Add(chk);
                    this.chkOrbit = chkPlanetInfo(2, foreground);
                    pnlCHK.Children.Add(chkOrbit);
                }
                else
                {
                    this.chkOrbit = new CheckBox();
                    this.rdo = rdoPlanetInfo(grdRowIndex, 1, foreground);
                    pnlCHK.Children.Add(rdo);
                    pnlCHK.Children.Add(rdoPlanetInfo(grdRowIndex, 2, foreground));
                }

                pnlMain.Children.Add(pnlCBO);
                pnlMain.Children.Add(pnlCHK);
                grd.Children.Add(pnlMain);

                Expander exp = new Expander
                {
                    Name = "expPlanetInfo" + grdRowIndex,
                    Header = (grdRowIndex == 1) ? "Origin" : "Stop " + grdRowIndex,
                    Margin = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontSize = 14,
                    ExpandDirection = ExpandDirection.Right,
                    Foreground = foreground

                };

                exp.Content = grd;
                exp.SetValue(Grid.RowProperty, grdRowIndex);
                exp.SetValue(Grid.ColumnProperty, grdColumnIndex);
                exp.Expanded += MainEvent;
                exp.Collapsed += MainEvent;
                return exp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ComboBox cboPlanetInfo(int grdRowIndex)
        {
            try
            {
                ComboBox cbo = new ComboBox
                {
                    Name = "cboPlanetInfo" + grdRowIndex,
                    Margin = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 100,
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("BatangChe"),
                };
                cbo.SelectionChanged += cboPlanetsSelectionChange;
                return cbo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private RadioButton rdoPlanetInfo(int grdRowIndex,int index, Brush foreground)
        {
            try
            {
                RadioButton rdo = new RadioButton
                {
                    Name = "rdoPlanetInfo" + grdRowIndex,
                    Content = (index == 1) ? "Surface" : "Low Orbit",
                    Margin = new Thickness(6, 0, 0, 0),
                    GroupName = "Stop"+ grdRowIndex,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    FontSize = 12,
                    Foreground = foreground
                };
                rdo.IsChecked = (index == 1);
                rdo.Unchecked += MainEvent;
                rdo.Checked += MainEvent;
                return rdo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private CheckBox chkPlanetInfo(int grdRowIndex, Brush foreground)
        {
            try
            {
                CheckBox chk = new CheckBox
                {
                    Name = (grdRowIndex == 1) ? "chkRoundTrip" : "chkPlanetInfo" + grdRowIndex,
                    Content = (grdRowIndex == 1) ? "Round Trip" : "Low Orbit",
                    Margin = new Thickness(6,0,0,0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    FontSize = 12,
                    Foreground = foreground
                }; 
                chk.Unchecked += MainEvent;
                chk.Checked += MainEvent;
                return chk;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private TextBlock txtPlanetInfo(int grdRowIndex, int grdColumnIndex)
        {
            try
            {
                TextBlock txt = new TextBlock
                {
                    Name = "txtPlanetInfo" + grdRowIndex,
                    Margin = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 14,
                    TextAlignment = TextAlignment.Justify,
                    FontFamily = new FontFamily("Consolas"),
                    Cursor = Cursors.Hand
                };
                txt.SetValue(Grid.RowProperty, grdRowIndex);
                txt.SetValue(Grid.ColumnProperty, grdColumnIndex);
                txt.MouseLeftButtonDown += txt_MouseButtonDown;
                return txt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Image imgPlanetInfo(int grdRowIndex, int grdColumnIndex)
        {
            try
            {
                Image img = new Image
                {
                    Name = "imgPlanetInfo" + grdRowIndex,
                    Stretch = Stretch.UniformToFill,
                    Cursor = Cursors.Hand
                };
                img.SetValue(Grid.RowProperty, grdRowIndex);
                img.SetValue(Grid.ColumnProperty, grdColumnIndex);
                img.MouseLeftButtonDown += img_MouseLeftButtonDown;
                return img;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        private void cboInit()
        {
            foreach (SelestialObject obj in planetList)
            {
                string displayName = displayName = (obj.Type == Types.Moon) ? "    " + obj.Name : obj.Name;
                cbo.Items.Add(displayName);
            }
            cbo.SelectedIndex = 0;
        }
        
        public bool isEnabled()
        {
            return (cbo.SelectedIndex != -1 && cbo.SelectedIndex != 0 && exp.IsExpanded);
        }

        public void Reset()
        {
            try
            {
                if (txtparentGrid.Children.Contains(txt)) txtparentGrid.Children.Remove(txt);
                if (txtparentGrid.Children.Contains(img)) txtparentGrid.Children.Remove(img);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update()
        {
            this.obj = planetList[cbo.SelectedIndex];
            try
            {
                Reset();
                List<Run> runLIst;
                if (isEnabled())
                {
                    runLIst = obj.ToShortRunList(Colour, obj.objectColour);
                    txt.Inlines.Clear();
                    foreach (Run objRun in runLIst) txt.Inlines.Add(objRun);
                    img.Source = new BitmapImage(new Uri(obj.ImageUri));
                    if (!txtparentGrid.Children.Contains(txt)) txtparentGrid.Children.Add(txt);
                    if (!txtparentGrid.Children.Contains(img)) txtparentGrid.Children.Add(img);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void IndexChange(int index)
        {
            this.obj = planetList[cbo.SelectedIndex];

        }

        #endregion

        #region "Event Handlers"

        private void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                new winBiomeMaps(obj).Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txt_MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                obj.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cboPlanetsSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            Update();
            parent.UpdateRoutes();
        }
        
        private void MainEvent(object sender, RoutedEventArgs e)
        {
            if(rdo != null && chkOrbit != null)
            orbit = (rdo.IsChecked == true || chkOrbit.IsChecked == true) ? Orbit.Low : Orbit.Surface;
            Update();
            parent.UpdateRoutes();
        }
        

        #endregion

    }

    public class PlaneInfoHandler
    {
        #region "General Declaration"
        public RoutesInfoHandler routesInfo;
        public List<PlanetInfo> planetInfoCSList = new List<PlanetInfo>();
        List<SelestialObject> currentPlanetList;

        Grid grdPlanetInfo;

        #endregion

        #region "Constractor"

        public PlaneInfoHandler(Grid grdPlanetInfo, Grid expParentGrid, Grid grdRouteInfo, List<Brush> foregroundList )
        {

            this.grdPlanetInfo = grdPlanetInfo;
            this.currentPlanetList = Globals.objList;
            planetInfoCSList.Clear();
            for (int i = 0; i < 4; i++)
                planetInfoCSList.Add(new PlanetInfo(i + 1, grdPlanetInfo, expParentGrid, foregroundList[i], this));
            routesInfo = new RoutesInfoHandler(planetInfoCSList, grdRouteInfo, planetInfoCSList[0].chk);
        }

        #endregion

        #region "Methods"

        public List<PlanetInfo> CSList()
        {
            return planetInfoCSList;
        }

        public void UpdateRoutes()
        {
            try
            {
                if (routesInfo != null)routesInfo.Update();
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion


    }


}
