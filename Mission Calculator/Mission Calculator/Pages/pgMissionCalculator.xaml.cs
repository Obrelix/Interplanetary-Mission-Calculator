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

namespace Mission_Calculator.Pages
{
    /// <summary>
    /// Interaction logic for pgMissionCalculator.xaml
    /// </summary>
    public partial class pgMissionCalculator : Page
    {
        #region "General Declaration"

        List<SelestialObject> StockPlanetList;
        List<SelestialObject> OuterPlanetList;
        List<SelestialObject> RSSPlanetList;
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
            planetFilesInit();
            comboboxesInit();
        }

        #region "Methods"

        private void errorFileInit()
        {
            string errorFilePath = saveDirectoryPath + "\\errorLog.txt";
            IO.errorFilePath = errorFilePath;
            IO.createFile(errorFilePath, "");
        }

        private void planetFilesInit()
        {
            StockPlanetList = IO.LoadListFromFile(StockPlanetsPath);
            OuterPlanetList = IO.LoadListFromFile(OuterPlanetsPath);
            RSSPlanetList = IO.LoadListFromFile(RSSPlanetsPath);
        }

        private void comboboxesInit()
        {
            foreach (SelestialObject obj in StockPlanetList)
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
                switch (cboName)
                {
                    case "comboBoxOrigin":
                        if (comboBoxOrigin.SelectedIndex != 0) textBlockOrigin.Text = StockPlanetList[comboBoxOrigin.SelectedIndex].ToString();
                        else textBlockOrigin.Text = "Origin";
                        imageOrigin.Source = new BitmapImage(new Uri(StockPlanetList[comboBoxOrigin.SelectedIndex].ImageUri));
                        break;
                    case "comboBoxStop1":
                        if (comboBoxStop1.SelectedIndex != 0) textBlockStop1.Text = StockPlanetList[comboBoxStop1.SelectedIndex].ToString();
                        else textBlockStop1.Text = "Stop 1";
                        imageStop1.Source = new BitmapImage(new Uri(StockPlanetList[comboBoxStop1.SelectedIndex].ImageUri));
                        break;
                    case "comboBoxStop2":
                        if (comboBoxStop2.SelectedIndex != 0) textBlockStop2.Text = StockPlanetList[comboBoxStop2.SelectedIndex].ToString();
                        else textBlockStop2.Text = "Stop 2";
                        imageStop2.Source = new BitmapImage(new Uri(StockPlanetList[comboBoxStop2.SelectedIndex].ImageUri));
                        break;
                    case "comboBoxStop3":
                        if (comboBoxStop3.SelectedIndex != 0) textBlockStop3.Text = StockPlanetList[comboBoxStop3.SelectedIndex].ToString();
                        else textBlockStop3.Text = "Stop 3";
                        imageStop3.Source = new BitmapImage(new Uri(StockPlanetList[comboBoxStop3.SelectedIndex].ImageUri));
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

        private void textBlockStop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            switch (((TextBlock)sender).Name)
            {
                case "textBlockOrigin":
                    break;
                case "textBlockStop1":
                    break;
                case "textBlockStop2":
                    break;
                case "textBlockStop3":
                    break;
                default:
                    break;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void radioButtonNormal_Checked(object sender, RoutedEventArgs e)
        {

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

        #endregion
    }
}
