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
using Mission_Calculator.Pages;
using System.Windows.Shapes;
using Mission_Calculator.Classes.Static_Classes;

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
        public CheckBox chkReturn { get; set; }
        public CheckBox chkOrbit { get; set; }
        public RadioButton rdoSurface { get; set; }
        public RadioButton rdoLO { get; set; }
        public Image img { get; set; }
        public Grid txtparentGrid { get; set; }
        public Grid expParentGrid { get; set; }
        public List<SelestialObject> planetList { get; set; }
        public Orbit orbit { get; set; }
        public StackPanel pnl { get; set; }
        public Border brdTxt { get; set; }
        public Border brdImg { get; set; }
        public Border brdExp { get; set; }
        #endregion

        #region "Constractor"

        public PlanetInfo(int grdRowIndex, Grid txtparentGrid, Grid expParentGrid, Brush foreground, PlaneInfoHandler parent)
        {
            this.parent = parent;
            this.txtparentGrid = txtparentGrid;
            this.expParentGrid = expParentGrid;
            this.txt = txtPlanetInfo(grdRowIndex);
            this.img = imgPlanetInfo(grdRowIndex);
            this.brdImg = brdInit();
            this.brdTxt = brdInit();
            this.brdExp = brdInit();
            //this.brdTxt.ToolTip = "Click to show S.O. characteristics.";
            //this.brdImg.ToolTip = "Click to Show Biome map.";
            this.brdTxt.Child = txt;
            this.brdImg.Child = img;

            this.pnl = pnlPlanetInfo(grdRowIndex, 1);
            pnl.Children.Add(brdTxt);
            pnl.Children.Add(brdImg);
            this.exp = expPlanetInfo(grdRowIndex, 1, foreground);
            expParentGrid.Children.Add(exp);    
            this.planetList = IO.objList;
            cboInit();
            this.obj = planetList[cbo.SelectedIndex];
            Colour = exp.Foreground;
            this.orbit = Orbit.Surface;
        }

        #endregion

        #region "Methods"
        private Border brdInit()
        {
            try
            {
                Border brd = new Border
                {
                    Background = Brushes.Transparent,
                    //BorderBrush = new SolidColorBrush { Color = Color.FromRgb(102, 255, 179), Opacity = 0.5 },
                    BorderBrush = Brushes.Transparent,
                    BorderThickness = new Thickness(4),
                    Margin = new Thickness(0),
                    //Opacity = 0.9
                };
                brd.MouseEnter += brdMouseEnter;
                brd.MouseLeave += brdMouseLeave;
                return brd;
            }
            catch (Exception)
            {

                throw;
            }
        }
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
                    this.chkReturn = chkPlanetInfo(1, foreground);
                    pnlCHK.Children.Add(chkReturn);
                    this.chkOrbit = chkPlanetInfo(2, foreground);
                    pnlCHK.Children.Add(chkOrbit);
                }
                else
                {
                    this.chkOrbit = new CheckBox();
                    this.rdoSurface = rdoPlanetInfo(grdRowIndex, 1, foreground);
                    pnlCHK.Children.Add(rdoSurface);
                    this.rdoLO = rdoPlanetInfo(grdRowIndex, 2, foreground);
                    pnlCHK.Children.Add(rdoLO);
                }

                pnlMain.Children.Add(pnlCBO);
                pnlMain.Children.Add(pnlCHK);
                grd.Children.Add(pnlMain);

                Expander exp = new Expander
                {
                    Name = "expPlanetInfo" + grdRowIndex,
                    Header = (grdRowIndex == 1) ? "Origin" : "Stop " + (grdRowIndex - 1),
                    Margin = new Thickness(1),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontSize = 14,
                    ExpandDirection = ExpandDirection.Right,
                    Foreground = foreground,
                    BorderThickness = new Thickness(5),
                    BorderBrush = Brushes.Transparent
            };

                exp.Content = grd;
                //exp.IsExpanded = !(grdRowIndex == 1);
                exp.SetValue(Grid.RowProperty, grdRowIndex);
                exp.SetValue(Grid.ColumnProperty, grdColumnIndex);
                exp.Expanded += MainEvent;
                exp.Collapsed += MainEvent;
                exp.MouseEnter += MouseEnter;
                exp.MouseLeave += MouseLeave;
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

        private StackPanel pnlPlanetInfo(int grdRowIndex, int grdColumnIndex)
        {
            try
            {
                StackPanel pnl = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Name = "pnlPlanetInfo" + grdRowIndex,
                    Margin = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                };
                pnl.SetValue(Grid.RowProperty, grdRowIndex);
                pnl.SetValue(Grid.ColumnProperty, grdColumnIndex);
                return pnl;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private TextBlock txtPlanetInfo(int grdRowIndex)
        {
            try
            {
                TextBlock txt = new TextBlock
                {
                    Name = "txtPlanetInfo" + grdRowIndex,
                    Margin = new Thickness(1),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 14,
                    TextAlignment = TextAlignment.Justify,
                    FontFamily = new FontFamily("Consolas"),
                    Cursor = Cursors.Hand
                };
                txt.MouseLeftButtonDown += txt_MouseButtonDown;
                return txt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Image imgPlanetInfo(int grdRowIndex)
        {
            try
            {
                Image img = new Image
                {
                    Name = "imgPlanetInfo" + grdRowIndex,
                    Stretch = Stretch.UniformToFill,
                    Margin = new Thickness(1),
                    Cursor = Cursors.Hand,
                    MaxHeight = 130,
                    MaxWidth =130
                };
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
                if (txtparentGrid.Children.Contains(pnl)) txtparentGrid.Children.Remove(pnl);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ResetExp()
        {
            try
            {
                if (expParentGrid.Children.Contains(exp)) expParentGrid.Children.Remove(exp);
                pnl.Children.Clear();
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
                bool hasSurface = (obj.Type != Types.Gasgiant && obj.Type != Types.Star);
                bool isLowOrbit = false;

                if (rdoSurface != null) isLowOrbit = (rdoSurface.IsChecked == false);
                else if (chkOrbit != null) isLowOrbit = (chkOrbit.IsChecked == true);

                orbit = (isLowOrbit || !hasSurface) ? Orbit.Low : Orbit.Surface;

                if (isEnabled())
                {
                    runLIst = obj.ToShortRunList(Colour, obj.objectColour);
                    txt.Inlines.Clear();
                    foreach (Run objRun in runLIst) txt.Inlines.Add(objRun);
                    img.Source = new BitmapImage(new Uri(obj.ImageUri));
                    if (!txtparentGrid.Children.Contains(pnl)) txtparentGrid.Children.Add(pnl);
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

            Update();
            parent.UpdateRoutes();
        }

        private void MouseEnter(object sender, MouseEventArgs e)
        {
            
            ((Expander)sender).BorderBrush =  new SolidColorBrush { Color = ((SolidColorBrush)((Expander)sender).Foreground).Color, Opacity = 0.2 };
            //((Expander)sender).BorderBrush.Opacity = 0.5;
        }

        private void MouseLeave(object sender, MouseEventArgs e)
        {
            ((Expander)sender).BorderBrush = Brushes.Transparent;
        }

        private void brdMouseEnter(object sender, MouseEventArgs e)
        {
            ((Border)sender).BorderBrush = new SolidColorBrush { Color = ((SolidColorBrush)obj.objectColour).Color , Opacity = 0.2 };
        }

        private void brdMouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).BorderBrush = Brushes.Transparent;
        }
        
        #endregion

    }

    public class PlaneInfoHandler
    {
        #region "General Declaration"
        public RoutesInfoHandler routesInfo;
        public List<PlanetInfo> planetInfoCSList = new List<PlanetInfo>();
        List<SelestialObject> currentPlanetList;
        pgMissionCalculator parent;
        List<Brush> foregroundList;
        ScrollViewer vrPI, vrPS;
        public Button btnAddPI, btnRemovePI;
        public Grid grdPlanetInfo, grdPlanetSelection;
        public static int RowCounter = 0;
        #endregion


        #region "Constractor"

        public PlaneInfoHandler(pgMissionCalculator parent, List<Brush> foregroundList )
        {
            this.foregroundList = foregroundList;
            this.parent = parent;
            this.currentPlanetList = IO.objList;
            planetInfoCSList.Clear();
            grdPlanetInfo = UIControls.grdPInit(1);

            vrPI = UIControls.viewerInit();
            vrPI.Name = "vrPI";
            vrPI.MaxHeight =570;
            vrPI.Content = grdPlanetInfo;
            vrPI.ScrollChanged += ScrollChanged;
            vrPI.SetValue(Grid.RowProperty, 1);
            vrPI.SetValue(Grid.ColumnProperty, 3);
            parent.pnlDown.Children.Add(vrPI);

            StackPanel pnlMainControls = UIControls.pnlInit(Orientation.Vertical);
            grdPlanetSelection = UIControls.grdPInit(1);
            vrPS = UIControls.viewerInit();
            vrPS.Content = grdPlanetSelection;
            vrPS.Name = "vrPS";
            vrPS.MaxHeight = 570;
            vrPS.ScrollChanged += ScrollChanged;
            btnAddPI = btnAddInit();
            btnRemovePI = btnRemovedInit();
            StackPanel pnlBtns = UIControls.pnlInit(Orientation.Horizontal);
            pnlBtns.HorizontalAlignment = HorizontalAlignment.Right;
            pnlBtns.VerticalAlignment = VerticalAlignment.Top;
            pnlBtns.Margin = new Thickness(0, 5, 0, 0);
            pnlBtns.Background = new SolidColorBrush { Color = Color.FromRgb(5, 47, 60), Opacity = 0.5 };
            pnlBtns.Children.Add(btnAddPI);
            pnlBtns.Children.Add(btnRemovePI);
            pnlBtns.SetValue(Grid.RowProperty, 0);
            pnlBtns.SetValue(Grid.ColumnProperty, 0);
            pnlMainControls.Children.Add(vrPS);
            parent.grdTop.Children.Add(pnlBtns);
            parent.pnlDownLeft.Children.Add(pnlMainControls);

            planetInfoCSList.Add(new PlanetInfo(RowCounter + 1, grdPlanetInfo, grdPlanetSelection, foregroundList[RowCounter], this));
            routesInfo = new RoutesInfoHandler(planetInfoCSList, parent, planetInfoCSList[0].chkReturn);
           


        }

        #endregion

        #region "Methods"

        private Button btnAddInit()
        {
            try
            {
                Button rdo = new Button
                {
                    Name = "btnAddPlanet",
                    Content = "+",
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(7),
                    Height = 20,
                    Width = 20,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 12,
                    Foreground = Brushes.Black
                };
                rdo.Click += btnAddClick;
                return rdo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Button btnRemovedInit()
        {
            try
            {
                Button rdo = new Button
                {
                    Name = "btnRemovePlanet",
                    Content = "-",
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(7),
                    Height = 20,
                    Width = 20,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 12,
                    Foreground = Brushes.Black
                };
                rdo.Click += btnRemoveClick;
                return rdo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void grdPlanetSelectionAddRow()
        {
            try
            {
                grdPlanetSelection.RowDefinitions[grdPlanetSelection.RowDefinitions.Count - 1].Height = new GridLength(0, GridUnitType.Auto);
                grdPlanetSelection.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5) });
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void grdPlanetInfoAddRow()
        {
            try
            {
                grdPlanetInfo.RowDefinitions[grdPlanetInfo.RowDefinitions.Count - 1].Height = new GridLength(0, GridUnitType.Auto);
                grdPlanetInfo.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5) });
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void grdPlanetSelectionRemoveRow()
        {
            try
            {
                grdPlanetSelection.RowDefinitions.Remove(grdPlanetSelection.RowDefinitions[grdPlanetSelection.RowDefinitions.Count - 1]);
                grdPlanetSelection.RowDefinitions[grdPlanetSelection.RowDefinitions.Count - 1].Height = new GridLength(5);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void grdPlanetInfoRemoveRow()
        {
            try
            {
                grdPlanetInfo.RowDefinitions.Remove(grdPlanetInfo.RowDefinitions[grdPlanetInfo.RowDefinitions.Count - 1]);
                grdPlanetInfo.RowDefinitions[grdPlanetInfo.RowDefinitions.Count - 1].Height = new GridLength(5);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void addPI()
        {
            grdPlanetSelectionAddRow();
            grdPlanetInfoAddRow();
            planetInfoCSList.Add(new PlanetInfo(RowCounter + 1, grdPlanetInfo, grdPlanetSelection, foregroundList[RowCounter], this));
        }


        private void removePI()
        {
            grdPlanetSelectionRemoveRow();
            grdPlanetInfoRemoveRow();

            planetInfoCSList[planetInfoCSList.Count - 1].Reset();
            planetInfoCSList[planetInfoCSList.Count - 1].ResetExp();
            planetInfoCSList.Remove(planetInfoCSList[planetInfoCSList.Count -1]);
            UpdateRoutes();
        }

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

        #region "Event Handlers"

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            if (RowCounter > 18) return;
            RowCounter++;
            addPI();
        }

        private void btnRemoveClick(object sender, RoutedEventArgs e)
        {
            if (RowCounter < 1) return;
            RowCounter--;
            removePI();
        }


        private void ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }


}
