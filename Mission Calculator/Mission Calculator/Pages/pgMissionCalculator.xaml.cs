using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mission_Calculator.Classes;
using Mission_Calculator.Enumerators;
using System.Windows.Markup;
using Mission_Calculator.Windows;

namespace Mission_Calculator.Pages
{
    /// <summary>
    /// Interaction logic for pgMissionCalculator.xaml
    /// </summary>
    public partial class pgMissionCalculator : Page
    {
        #region "General Declaration"
        
        List<SelestialObject> currentPlanetList;
        static string saveDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Interplanetary Mission Calulator";
        static string planeDataDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\PlanetsData";
        static string StockPlanetsPath = planeDataDirectoryPath + "\\StockPlanets.json";
        static string OuterPlanetsPath = planeDataDirectoryPath + "\\OuterPlanets.json";
        static string RSSPlanetsPath = planeDataDirectoryPath + "\\RSSPlanets.json";

        TextBlock textBlockOrigin = new TextBlock();
        TextBlock textBlockStop1 = new TextBlock();
        TextBlock textBlockStop2 = new TextBlock();
        TextBlock textBlockStop3 = new TextBlock();
        Image imageOrigin = new Image();
        Image imageStop1 = new Image();
        Image imageStop2 = new Image();
        Image imageStop3 = new Image();
        StackPanel pnlRPOrigin = new StackPanel();
        #endregion

        public pgMissionCalculator()
        {
            InitializeComponent();
            textBlocksInit();
            imagesInit();
            errorFileInit();
            //saveFilesInit();
            //cboGameMode.SelectedIndex = 0;
            cboTimeUnit.SelectedIndex = 1;
            planetFilesInit(0);
        }

        #region "Methods"

        private void saveFilesInit()
        {
            List<SelestialObject> objList = new List<SelestialObject>();
            for (int i = 0; i <= 17; i++)
            {
                objList.Add(new SelestialObject());
            }
            IO.saveListToFile(StockPlanetsPath, objList);
            objList.Clear();
            for (int i = 0; i <= 31; i++)
            {
                objList.Add(new SelestialObject());
            }
            IO.saveListToFile(OuterPlanetsPath, objList);
            objList.Clear();
            for (int i = 0; i <= 16; i++)
            {
                objList.Add( new SelestialObject());
            }
            IO.saveListToFile(RSSPlanetsPath, objList);
            objList.Clear();
        }

        private void errorFileInit()
        {
            string errorFilePath = saveDirectoryPath + "\\errorLog.txt";
            IO.errorFilePath = errorFilePath;
            IO.createFile(errorFilePath, "");
        }

        private void planetFilesInit(int mode)
        {
            if(currentPlanetList != null)currentPlanetList.Clear();
            switch (mode)
            {
                case 0:
                    currentPlanetList = IO.LoadListFromFile(StockPlanetsPath);
                    break;
                case 1:
                    currentPlanetList = IO.LoadListFromFile(OuterPlanetsPath);
                    break;
                case 2:
                    currentPlanetList = IO.LoadListFromFile(RSSPlanetsPath);
                    break;
                default:
                    currentPlanetList = IO.LoadListFromFile(StockPlanetsPath);
                    break;
            }
            comboboxesInit();
        }
        
        private void textBlocksInit()
        {
            try
            {
                textBlockOrigin.Name = "textBlockOrigin";
                textBlockOrigin.SetValue(Grid.RowProperty, 1);
                textBlockOrigin.SetValue(Grid.ColumnProperty, 1);
                textBlockOrigin.Margin = new Thickness(0);
                textBlockOrigin.HorizontalAlignment = HorizontalAlignment.Left;
                textBlockOrigin.TextWrapping = TextWrapping.Wrap;
                textBlockOrigin.FontSize = 14;
                textBlockOrigin.TextAlignment = TextAlignment.Justify;
                textBlockOrigin.FontFamily = new FontFamily("Consolas");
                textBlockOrigin.MouseLeftButtonDown += textBlockStop_MouseButtonUp;

                textBlockStop1.Name = "textBlockStop1";
                textBlockStop1.SetValue(Grid.RowProperty, 2);
                textBlockStop1.SetValue(Grid.ColumnProperty, 1);
                textBlockStop1.Margin = new Thickness(0);
                textBlockStop1.HorizontalAlignment = HorizontalAlignment.Left;
                textBlockStop1.TextWrapping = TextWrapping.Wrap;
                textBlockStop1.FontSize = 14;
                textBlockStop1.TextAlignment = TextAlignment.Justify;
                textBlockStop1.FontFamily = new FontFamily("Consolas");
                textBlockStop1.MouseLeftButtonDown += textBlockStop_MouseButtonUp;

                textBlockStop2.Name = "textBlockStop2";
                textBlockStop2.SetValue(Grid.RowProperty, 3);
                textBlockStop2.SetValue(Grid.ColumnProperty, 1);
                textBlockStop2.Margin = new Thickness(0);
                textBlockStop2.HorizontalAlignment = HorizontalAlignment.Left;
                textBlockStop2.TextWrapping = TextWrapping.Wrap;
                textBlockStop2.FontSize = 14;
                textBlockStop2.TextAlignment = TextAlignment.Justify;
                textBlockStop2.FontFamily = new FontFamily("Consolas");
                textBlockStop2.MouseLeftButtonDown += textBlockStop_MouseButtonUp;

                textBlockStop3.Name = "textBlockStop3";
                textBlockStop3.SetValue(Grid.RowProperty, 4);
                textBlockStop3.SetValue(Grid.ColumnProperty, 1);
                textBlockStop3.Margin = new Thickness(0);
                textBlockStop3.HorizontalAlignment = HorizontalAlignment.Left;
                textBlockStop3.TextWrapping = TextWrapping.Wrap;
                textBlockStop3.FontSize = 14;
                textBlockStop3.TextAlignment = TextAlignment.Justify;
                textBlockStop3.FontFamily = new FontFamily("Consolas");
                textBlockStop3.MouseLeftButtonDown += textBlockStop_MouseButtonUp;
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
                imageOrigin.Name = "imageOrigin";
                imageOrigin.SetValue(Grid.RowProperty, 1);
                imageOrigin.SetValue(Grid.ColumnProperty, 2);
                imageOrigin.Stretch = Stretch.UniformToFill;
                imageOrigin.MouseLeftButtonDown += image_MouseLeftButtonDown;

                imageStop1.Name = "imageStop1";
                imageStop1.SetValue(Grid.RowProperty, 2);
                imageStop1.SetValue(Grid.ColumnProperty, 2);
                imageStop1.Stretch = Stretch.UniformToFill;
                imageStop1.MouseLeftButtonDown += image_MouseLeftButtonDown;

                imageStop2.Name = "imageStop2";
                imageStop2.SetValue(Grid.RowProperty, 3);
                imageStop2.SetValue(Grid.ColumnProperty, 2);
                imageStop2.Stretch = Stretch.UniformToFill;
                imageStop2.MouseLeftButtonDown += image_MouseLeftButtonDown;

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

        private void comboboxesInit()
        {
            if (comboBoxOrigin.Items != null) comboBoxOrigin.Items.Clear();
            if (comboBoxStop1.Items != null) comboBoxStop1.Items.Clear();
            if (comboBoxStop2.Items != null) comboBoxStop2.Items.Clear();
            if (comboBoxStop3.Items != null) comboBoxStop3.Items.Clear();
            foreach (SelestialObject obj in currentPlanetList)
            {
                comboBoxOrigin.Items.Add(obj.Name);
                comboBoxStop1.Items.Add(obj.Name);
                comboBoxStop2.Items.Add(obj.Name);
                comboBoxStop3.Items.Add(obj.Name);
            }
            comboBoxOrigin.SelectedIndex = 0;
            comboBoxStop1.SelectedIndex = 0;
            comboBoxStop2.SelectedIndex = 0;
            comboBoxStop3.SelectedIndex = 0;
        }

        private void rightPaneUpdate(string controlName)
        {
            try
            {
                switch (controlName)
                {
                    case "expanderOrigin":
                    case "comboBoxOrigin":
                        updateGrid(expanderOrigin, comboBoxOrigin, textBlockOrigin, imageOrigin);
                        break;
                    case "expanderStop1":
                    case "comboBoxStop1":
                        updateGrid(expanderStop1, comboBoxStop1, textBlockStop1, imageStop1);
                        break;
                    case "expanderStop2":
                    case "comboBoxStop2":
                        updateGrid(expanderStop2, comboBoxStop2, textBlockStop2, imageStop2);
                        break;
                    case "expanderStop3":
                    case "comboBoxStop3":
                        updateGrid(expanderStop3, comboBoxStop3, textBlockStop3, imageStop3);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void updateGrid(Expander expander, ComboBox combobox, TextBlock txtBlock, Image Image)
        {
            try
            {
                List<Run> runLIst;
                string imageUri;
                int intCBOIndex = combobox.SelectedIndex;
                bool isExpanded = expander.IsExpanded;
                if (intCBOIndex != -1 && intCBOIndex != 0 && isExpanded)
                {
                    runLIst = currentPlanetList[intCBOIndex].ToShortRunList(expander.Foreground, Brushes.Tomato);
                    imageUri = currentPlanetList[intCBOIndex].ImageUri;
                    txtBlock.Inlines.Clear();
                    foreach (Run objRun in runLIst) txtBlock.Inlines.Add(objRun);
                    Image.Source = new BitmapImage(new Uri(imageUri));
                    if (!grdRightPanel.Children.Contains(txtBlock)) grdRightPanel.Children.Add(txtBlock);
                    if (!grdRightPanel.Children.Contains(Image)) grdRightPanel.Children.Add(Image);
                }
                else
                {
                    if (grdRightPanel.Children.Contains(txtBlock)) grdRightPanel.Children.Remove(txtBlock);
                    if (grdRightPanel.Children.Contains(Image)) grdRightPanel.Children.Remove(Image);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void showObjectInfo(string controlName)
        {
            try
            {
                int intCboIndex;
                switch (controlName)
                {
                    case "textBlockOrigin":
                        intCboIndex = comboBoxOrigin.SelectedIndex;
                        break;
                    case "textBlockStop1":
                        intCboIndex = comboBoxStop1.SelectedIndex;
                        break;
                    case "textBlockStop2":
                        intCboIndex = comboBoxStop2.SelectedIndex;
                        break;
                    case "textBlockStop3":
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
                //currentPlanetList[intCboIndex].Show();
                winBiomeMaps win = new winBiomeMaps(currentPlanetList[intCboIndex]);
                win.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region "Event Handlers"

        private void textBlockStop_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            showObjectInfo(((TextBlock)sender).Name);
        }
        
        private void Main_Loaded(object sender, RoutedEventArgs e)
        {

        }
        
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cboPlanetsSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            rightPaneUpdate(((ComboBox)sender).Name);
        }

        private void cboGameMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            planetFilesInit(((ComboBox)sender).SelectedIndex);
        }

        private void MainEvent(object sender, RoutedEventArgs e)
        {

        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showBiomeMaps(((Image)sender).Name);
        }

        private void expander_Expanded(object sender, RoutedEventArgs e)
        {
            rightPaneUpdate(((Expander)sender).Name);
        }

        #endregion

    }
}
