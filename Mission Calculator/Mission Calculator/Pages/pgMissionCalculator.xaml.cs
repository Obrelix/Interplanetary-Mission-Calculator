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

        #endregion

        public pgMissionCalculator()
        {
            InitializeComponent();
            errorFileInit();
            //saveFilesInit();
            cboGameMode.SelectedIndex = 0;
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

        private void rightPaneUpdate(string cboName)
        {
            try
            {
                List<Run> runLIst;
                string imageUri;
                int intCBOIndex;
                switch (cboName)
                {
                    case "comboBoxOrigin":
                        intCBOIndex = comboBoxOrigin.SelectedIndex;
                        if (intCBOIndex != -1)
                        {
                            runLIst = currentPlanetList[intCBOIndex].LabelsToRunList(Brushes.Wheat);
                            imageUri = currentPlanetList[intCBOIndex].ImageUri;
                            textBlockOrigin.Inlines.Clear();
                            if (intCBOIndex != 0)
                                foreach (Run objRun in runLIst)
                                    textBlockOrigin.Inlines.Add(objRun);
                            else
                                textBlockOrigin.Text = "Origin";
                            imageOrigin.Source = new BitmapImage(new Uri(imageUri));
                        }
                        break;
                    case "comboBoxStop1":
                        intCBOIndex = comboBoxStop1.SelectedIndex;
                        if (intCBOIndex != -1)
                        {
                            runLIst = currentPlanetList[intCBOIndex].LabelsToRunList(Brushes.PowderBlue);
                            imageUri = currentPlanetList[intCBOIndex].ImageUri;
                            textBlockStop1.Inlines.Clear();
                            if (intCBOIndex != 0)
                                foreach (Run objRun in runLIst)
                                    textBlockStop1.Inlines.Add(objRun);
                            else
                                textBlockStop1.Text = "Stop1";
                            imageStop1.Source = new BitmapImage(new Uri(imageUri));
                        }
                        break;
                    case "comboBoxStop2":
                        intCBOIndex = comboBoxStop2.SelectedIndex;
                        if (intCBOIndex != -1)
                        {
                            runLIst = currentPlanetList[intCBOIndex].LabelsToRunList(Brushes.WhiteSmoke);
                            imageUri = currentPlanetList[intCBOIndex].ImageUri;
                            textBlockStop2.Inlines.Clear();
                            if (intCBOIndex != 0)
                                foreach (Run objRun in runLIst)
                                    textBlockStop2.Inlines.Add(objRun);
                            else
                                textBlockStop2.Text = "Stop1";
                            imageStop2.Source = new BitmapImage(new Uri(imageUri));
                        }
                        break;
                    case "comboBoxStop3":
                        intCBOIndex = comboBoxStop3.SelectedIndex;
                        if (intCBOIndex != -1)
                        {
                            runLIst = currentPlanetList[intCBOIndex].LabelsToRunList(Brushes.BurlyWood);
                            imageUri = currentPlanetList[intCBOIndex].ImageUri;
                            textBlockStop3.Inlines.Clear();
                            if (intCBOIndex != 0)
                                foreach (Run objRun in runLIst)
                                    textBlockStop3.Inlines.Add(objRun);
                            else
                                textBlockStop3.Text = "Stop1";
                            imageStop3.Source = new BitmapImage(new Uri(imageUri));
                        }
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

        #endregion

        #region "Event Handlers"

        private void textBlockStop_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int intCboIndex;
                switch (((TextBlock)sender).Name)
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
            try
            {
                int intCboIndex;
                switch (((Image)sender).Name)
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
                        intCboIndex = 0;
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
    }
}
