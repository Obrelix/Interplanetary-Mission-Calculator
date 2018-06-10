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
        List<List<SelestialObject>> couplesList;
        static string saveDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Interplanetary Mission Calulator";
        static string planeDataDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\PlanetsData";
        static string StockPlanetsPath = planeDataDirectoryPath + "\\StockPlanets.json";
        static string OuterPlanetsPath = planeDataDirectoryPath + "\\OuterPlanets.json";
        static string RSSPlanetsPath = planeDataDirectoryPath + "\\RSSPlanets.json";

        TextBlock txtSOOrigin;
        TextBlock txtSOStop1;
        TextBlock txtSOStop2;
        TextBlock txtSOStop3;
        TextBlock txtTravelStop1;
        TextBlock txtTravelStop2;
        TextBlock txtTravelStop3;
        TextBlock txtTravelReturn;
        Image imageOrigin = new Image();
        Image imageStop1 = new Image();
        Image imageStop2 = new Image();
        Image imageStop3 = new Image();
        StackPanel pnlRPOrigin = new StackPanel();
        #endregion

        /// <summary>
        /// Constractror
        /// </summary>
        public pgMissionCalculator()
        {
            InitializeComponent();
            txtPlanetInfoInit(); txtTravelInfoInit(); imagesInit();
            errorFileInit();
            planetFilesInit(0);
            couplesList = new List<List<SelestialObject>>();
        }
        //saveFilesInit();
        //cboGameMode.SelectedIndex = 0;
        //cboTimeUnit.SelectedIndex = 1;

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



        //<!--<TextBlock x:Name="textBlockStop1Travel" Grid.Row="1" TextWrapping="Wrap" Foreground="#FF9CDBDE" Text=""  Cursor="Hand" />
        //<TextBlock x:Name="textBlockStop2Travel" Grid.Row="2" TextWrapping="Wrap" Foreground="#FFDAC5FF" Text="" Cursor="Hand"/>
        //<TextBlock x:Name="textBlockStop3Travel" Grid.Row="3" TextWrapping="Wrap" Foreground="#FFB3FFC8" Text="" Cursor="Hand"/>
        //<TextBlock x:Name="textBlockOriginTravel" Grid.Row="4" TextWrapping="Wrap" Foreground="#FF02FD69" Text="" Cursor="Hand" />-->

        private void txtTravelInfoInit()
        {
            try
            {
                txtTravelStop1 = dtxtTravelInfo();
                txtTravelStop1.Name = "txtTravelStop1";
                txtTravelStop1.SetValue(Grid.RowProperty, 1);
                txtTravelStop1.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;

                txtTravelStop2 = dtxtTravelInfo();
                txtTravelStop2.Name = "txtTravelStop2";
                txtTravelStop2.SetValue(Grid.RowProperty, 2);
                txtTravelStop2.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;

                txtTravelStop3 = dtxtTravelInfo();
                txtTravelStop3.Name = "txtTravelStop3";
                txtTravelStop3.SetValue(Grid.RowProperty, 3);
                txtTravelStop3.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;

                txtTravelReturn = dtxtTravelInfo();
                txtTravelReturn.Name = "txtTravelReturn";
                txtTravelReturn.SetValue(Grid.RowProperty, 4);
                txtTravelReturn.MouseLeftButtonDown += txtTravelInfo_MouseButtonUp;
            }
            catch (Exception)
            {

                throw;
            }
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
                        updateGrid(expanderOrigin, comboBoxOrigin, txtSOOrigin, imageOrigin);
                        break;
                    case "expanderStop1":
                    case "comboBoxStop1":
                        updateGrid(expanderStop1, comboBoxStop1, txtSOStop1, imageStop1);
                        break;
                    case "expanderStop2":
                    case "comboBoxStop2":
                        updateGrid(expanderStop2, comboBoxStop2, txtSOStop2, imageStop2);
                        break;
                    case "expanderStop3":
                    case "comboBoxStop3":
                        updateGrid(expanderStop3, comboBoxStop3, txtSOStop3, imageStop3);
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

        private bool isActive(Expander exp)
        {
            switch (exp.Name)
            {
                case "expanderOrigin":
                    if (exp.IsExpanded) return (comboBoxOrigin.SelectedIndex != 0 && comboBoxOrigin.SelectedIndex != -1);
                    else return false;
                case "expanderStop1":
                    if (exp.IsExpanded) return (comboBoxStop1.SelectedIndex != 0 && comboBoxStop1.SelectedIndex != -1);
                    else return false;
                case "expanderStop2":
                    if (exp.IsExpanded) return (comboBoxStop2.SelectedIndex != 0 && comboBoxStop2.SelectedIndex != -1);
                    else return false;
                case "expanderStop3":
                    if (exp.IsExpanded) return (comboBoxStop3.SelectedIndex != 0 && comboBoxStop3.SelectedIndex != -1);
                    else return false;
                default:
                    return false;
            }
        }

        private bool findIndex(Expander exp)
        {
            switch (exp.Name)
            {
                case "expanderOrigin":
                    if (exp.IsExpanded) return (comboBoxOrigin.SelectedIndex != 0 && comboBoxOrigin.SelectedIndex != -1);
                    else return false;
                case "expanderStop1":
                    if (exp.IsExpanded) return (comboBoxStop1.SelectedIndex != 0 && comboBoxStop1.SelectedIndex != -1);
                    else return false;
                case "expanderStop2":
                    if (exp.IsExpanded) return (comboBoxStop2.SelectedIndex != 0 && comboBoxStop2.SelectedIndex != -1);
                    else return false;
                case "expanderStop3":
                    if (exp.IsExpanded) return (comboBoxStop3.SelectedIndex != 0 && comboBoxStop3.SelectedIndex != -1);
                    else return false;
                default:
                    return false;
            }
        }

        private void showTransferOrbit(string controlName)
        {
            try
            {

                int intCboIndexFrom, intCboIndexTo;
                switch (controlName)
                {
                    case "txtTravelStop1":
                        intCboIndexFrom = comboBoxOrigin.SelectedIndex; intCboIndexTo = 0;
                        winTransferOrbit win = new winTransferOrbit(currentPlanetList[intCboIndexFrom], currentPlanetList[intCboIndexTo]);
                        win.Show();
                        break;
                    case "txtTravelStop2":
                        intCboIndexFrom = comboBoxStop1.SelectedIndex; intCboIndexTo = 0;
                        break;
                    case "txtTravelStop3":
                        intCboIndexFrom = comboBoxStop2.SelectedIndex; intCboIndexTo = 0;
                        break;
                    case "txtTravelReturn":
                        intCboIndexFrom = comboBoxStop3.SelectedIndex; intCboIndexTo = 0;
                        break;
                    default:
                        intCboIndexFrom = 0; intCboIndexTo = 0;
                        break;
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

        private void txtTravelInfo_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            showTransferOrbit(((TextBlock)sender).Name);
        }

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

        //private void cboGameMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    planetFilesInit(((ComboBox)sender).SelectedIndex);
        //}

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
