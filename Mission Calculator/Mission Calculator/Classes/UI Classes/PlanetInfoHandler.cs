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

        Brush defColour;
        public int Index { get; set; }
        public SelestialObject obj { get; set; }
        public ComboBox cbo { get; set; }
        public Expander exp { get; set; }
        public TextBlock txt { get; set; }
        public Image img { get; set; }
        public Grid parentGrid { get; set; }
        public List<SelestialObject> planetList { get; set; }

        #endregion

        #region "Constractor"

        public PlanetInfo()
        {
            this.obj = new SelestialObject();
            this.cbo = new ComboBox();
            this.exp = new Expander();
            this.txt = new TextBlock();
            this.img = new Image();
            this.parentGrid = new Grid();
            this.planetList = new List<SelestialObject>();

        }

        public PlanetInfo(Expander exp, ComboBox cbo, System.Drawing.Point txtPoint, System.Drawing.Point imgPoint, Grid parentGrid)
        {
            this.parentGrid = parentGrid;
            this.cbo = cbo;
            cbo.SelectedIndex = 0;
            this.exp = exp;
            this.txt = txtPlanetInfo(txtPoint.X, txtPoint.Y);
            this.img = imgPlanetInfo(imgPoint.X, imgPoint.Y);
            this.planetList = Globals.objList;
            comboboxesInit();
            this.obj = planetList[cbo.SelectedIndex];
            defColour = exp.Foreground;
        }

        #endregion

        #region "Methods"

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
                txt.MouseLeftButtonDown += textBlockStop_MouseButtonUp;
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
                img.MouseLeftButtonDown += image_MouseLeftButtonDown;
                return img;
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void comboboxesInit()
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
                if (parentGrid.Children.Contains(txt)) parentGrid.Children.Remove(txt);
                if (parentGrid.Children.Contains(img)) parentGrid.Children.Remove(img);
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
                List<Run> runLIst;
                if (parentGrid.Children.Contains(txt)) parentGrid.Children.Remove(txt);
                if (parentGrid.Children.Contains(img)) parentGrid.Children.Remove(img);
                if (isEnabled())
                {
                    //exp.Foreground = obj.objectColour;
                    //cbo.Foreground = obj.objectColour;
                    runLIst = obj.ToShortRunList(defColour, obj.objectColour);
                    txt.Inlines.Clear();
                    foreach (Run objRun in runLIst) txt.Inlines.Add(objRun);
                    img.Source = new BitmapImage(new Uri(obj.ImageUri));
                    if (!parentGrid.Children.Contains(txt)) parentGrid.Children.Add(txt);
                    if (!parentGrid.Children.Contains(img)) parentGrid.Children.Add(img);
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

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        private void textBlockStop_MouseButtonUp(object sender, MouseButtonEventArgs e)
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

        #endregion

    }

    public class PlaneInfoHandler
    {
        #region "General Declaration"

        public List<PlanetInfo> planetInfoCSList = new List<PlanetInfo>();
        List<SelestialObject> currentPlanetList;

        Grid grdPlanetInfo;

        #endregion

        #region "Constractor"

        public PlaneInfoHandler(Grid grdPlanetInfo, List<ComboBox> cboList, List<Expander> expList)
        {

            this.grdPlanetInfo = grdPlanetInfo;
            this.currentPlanetList = Globals.objList;
            planetInfoCSList.Clear();
            for (int i = 0; i < 4; i++)
                planetInfoCSList.Add(new PlanetInfo(expList[i], cboList[i], new System.Drawing.Point(i + 1, 1), new System.Drawing.Point(i + 1, 2), grdPlanetInfo));
        }

        #endregion

        #region "Methods"

        public List<PlanetInfo> CSList()
        {
            return planetInfoCSList;
        }

        public void Update()
        {
            try
            {
                foreach (PlanetInfo obj in planetInfoCSList) obj.Reset();
                foreach (PlanetInfo obj in planetInfoCSList) obj.Update();
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion


    }


}
