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

namespace Mission_Calculator.Classes
{
    public class PlanetInfoControlSet
    {
        public int Index { get; set; }
        public SelestialObject obj { get; set; }
        public ComboBox cbo { get; set; }
        public Expander exp { get; set; }
        public TextBlock txt { get; set; }
        public System.Windows.Controls.Image img { get; set; }
        public Grid parentGrid { get; set; }
        public List<SelestialObject> planetList { get; set; }

        public PlanetInfoControlSet()
        {
            this.obj = new SelestialObject();
            this.cbo = new ComboBox();
            this.exp = new Expander();
            this.txt = new TextBlock();
            this.img = new System.Windows.Controls.Image();
            this.parentGrid = new Grid();
            this.planetList = new List<SelestialObject>();

        }

        public PlanetInfoControlSet(Expander exp, ComboBox cbo, TextBlock txt, System.Windows.Controls.Image img, Grid parentGrid, List<SelestialObject> planetList)
        {
            this.parentGrid = parentGrid;
            this.cbo = cbo;
            cbo.SelectedIndex = 0;
            this.exp = exp;
            this.txt = txt;
            this.img = img;
            this.planetList = planetList;
            this.obj = planetList[cbo.SelectedIndex];
        }

        public bool isEnabled()
        {
            int intCBOIndex = cbo.SelectedIndex;
            bool isExpanded = exp.IsExpanded;
            return (intCBOIndex != -1 && intCBOIndex != 0 && isExpanded);
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
                    runLIst = obj.ToShortRunList(exp.Foreground, Brushes.Tomato);
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
    }

    public class PlaneInfoManager
    {
        public List<PlanetInfoControlSet> planetInfoCSList = new List<PlanetInfoControlSet>();
        List<SelestialObject> currentPlanetList;

        TextBlock txtSOOrigin;
        TextBlock txtSOStop1;
        TextBlock txtSOStop2;
        TextBlock txtSOStop3;
        Image imageOrigin;
        Image imageStop1;
        Image imageStop2;
        Image imageStop3;
        Grid grdPlanetInfo;
        ComboBox comboBoxOrigin;
        ComboBox comboBoxStop1;
        ComboBox comboBoxStop2;
        ComboBox comboBoxStop3;
        Expander expanderOrigin;
        Expander expanderStop1;
        Expander expanderStop2;
        Expander expanderStop3;

        public PlaneInfoManager(List<SelestialObject> currentPlanetList, Grid grdPlanetInfo,
        ComboBox comboBoxOrigin,ComboBox comboBoxStop1,ComboBox comboBoxStop2,ComboBox comboBoxStop3,
            Expander expanderOrigin,Expander expanderStop1,Expander expanderStop2,Expander expanderStop3)
        {
            this.grdPlanetInfo = grdPlanetInfo;
            this.currentPlanetList = currentPlanetList;
            this.comboBoxOrigin = comboBoxOrigin;
            this.comboBoxStop1 = comboBoxStop1;
            this.comboBoxStop2 = comboBoxStop2;
            this.comboBoxStop3 = comboBoxStop3;
            this.expanderOrigin = expanderOrigin;
            this.expanderStop1 = expanderStop1;
            this.expanderStop2 = expanderStop2;
            this.expanderStop3 = expanderStop3;
            txtPlanetInfoInit();
            imagesInit();
            planetInfoCSList.Clear();
            planetInfoCSList.Add(new PlanetInfoControlSet(expanderOrigin, comboBoxOrigin, txtSOOrigin, imageOrigin, grdPlanetInfo, currentPlanetList));
            planetInfoCSList.Add(new PlanetInfoControlSet(expanderStop1, comboBoxStop1, txtSOStop1, imageStop1, grdPlanetInfo, currentPlanetList));
            planetInfoCSList.Add(new PlanetInfoControlSet(expanderStop2, comboBoxStop2, txtSOStop2, imageStop2, grdPlanetInfo, currentPlanetList));
            planetInfoCSList.Add(new PlanetInfoControlSet(expanderStop3, comboBoxStop3, txtSOStop3, imageStop3, grdPlanetInfo, currentPlanetList));
        }

        public List<PlanetInfoControlSet> CSList()
        {
            return planetInfoCSList;
        }
        public void Update()
        {
            try
            {
                foreach (PlanetInfoControlSet obj in planetInfoCSList) obj.Reset();
                foreach (PlanetInfoControlSet obj in planetInfoCSList) obj.Update();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private TextBlock dtxtPlanetInfo()
        {
            return new TextBlock
            {
                Margin = new Thickness(0),
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14,
                TextAlignment = TextAlignment.Justify,
                FontFamily = new FontFamily("Consolas"),
            };
        }

        private void txtPlanetInfoInit()
        {
            try
            {
                txtSOOrigin = dtxtPlanetInfo();
                txtSOOrigin.Name = "txtSOOrigin";
                txtSOOrigin.SetValue(Grid.RowProperty, 1);
                txtSOOrigin.SetValue(Grid.ColumnProperty, 1);
                txtSOOrigin.MouseLeftButtonDown += textBlockStop_MouseButtonUp;

                txtSOStop1 = dtxtPlanetInfo();
                txtSOStop1.Name = "txtSOStop1";
                txtSOStop1.SetValue(Grid.RowProperty, 2);
                txtSOStop1.SetValue(Grid.ColumnProperty, 1);
                txtSOStop1.MouseLeftButtonDown += textBlockStop_MouseButtonUp;

                txtSOStop2 = dtxtPlanetInfo();
                txtSOStop2.Name = "txtSOStop2";
                txtSOStop2.SetValue(Grid.RowProperty, 3);
                txtSOStop2.SetValue(Grid.ColumnProperty, 1);
                txtSOStop2.MouseLeftButtonDown += textBlockStop_MouseButtonUp;

                txtSOStop3 = dtxtPlanetInfo();
                txtSOStop3.Name = "txtSOStop3";
                txtSOStop3.SetValue(Grid.RowProperty, 4);
                txtSOStop3.SetValue(Grid.ColumnProperty, 1);
                txtSOStop3.MouseLeftButtonDown += textBlockStop_MouseButtonUp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void imagesInit()
        {
            try
            {
                imageOrigin = new Image();
                imageOrigin.Name = "imageOrigin";
                imageOrigin.Stretch = Stretch.UniformToFill;
                imageOrigin.SetValue(Grid.RowProperty, 1);
                imageOrigin.SetValue(Grid.ColumnProperty, 2);
                imageOrigin.MouseLeftButtonDown += image_MouseLeftButtonDown;

                imageStop1 = new Image();
                imageStop1.Name = "imageStop1";
                imageStop1.SetValue(Grid.RowProperty, 2);
                imageStop1.SetValue(Grid.ColumnProperty, 2);
                imageStop1.Stretch = Stretch.UniformToFill;
                imageStop1.MouseLeftButtonDown += image_MouseLeftButtonDown;

                imageStop2 = new Image();
                imageStop2.Name = "imageStop2";
                imageStop2.SetValue(Grid.RowProperty, 3);
                imageStop2.SetValue(Grid.ColumnProperty, 2);
                imageStop2.Stretch = Stretch.UniformToFill;
                imageStop2.MouseLeftButtonDown += image_MouseLeftButtonDown;

                imageStop3 = new Image();
                imageStop3.Name = "imageStop3";
                imageStop3.SetValue(Grid.RowProperty, 4);
                imageStop3.SetValue(Grid.ColumnProperty, 2);
                imageStop3.Stretch = Stretch.UniformToFill;
                imageStop3.MouseLeftButtonDown += image_MouseLeftButtonDown;
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showBiomeMaps(((Image)sender).Name);
        }

        private void textBlockStop_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            showObjectInfo(((TextBlock)sender).Name);
        }

        private void showObjectInfo(string controlName)
        {
            try
            {
                int intCboIndex;
                switch (controlName)
                {
                    case "txtSOOrigin":
                        intCboIndex = comboBoxOrigin.SelectedIndex;
                        break;
                    case "txtSOStop1":
                        intCboIndex = comboBoxStop1.SelectedIndex;
                        break;
                    case "txtSOStop2":
                        intCboIndex = comboBoxStop2.SelectedIndex;
                        break;
                    case "txtSOStop3":
                        intCboIndex = comboBoxStop3.SelectedIndex;
                        break;
                    default:
                        intCboIndex = 0;
                        break;
                }
                currentPlanetList[intCboIndex].Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void showBiomeMaps(string controlName)
        {
            try
            {
                int intCboIndex;
                switch (controlName)
                {
                    case "imageOrigin":
                        intCboIndex = comboBoxOrigin.SelectedIndex;
                        break;
                    case "imageStop1":
                        intCboIndex = comboBoxStop1.SelectedIndex;
                        break;
                    case "imageStop2":
                        intCboIndex = comboBoxStop2.SelectedIndex;
                        break;
                    case "imageStop3":
                        intCboIndex = comboBoxStop3.SelectedIndex;
                        break;
                    default:
                        intCboIndex = 1;
                        break;
                }
                winBiomeMaps win = new winBiomeMaps(currentPlanetList[intCboIndex]);
                win.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }


}
