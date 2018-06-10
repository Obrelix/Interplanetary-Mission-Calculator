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
        RoutesInfoControlSets RoutesControler;
        PlaneInfoManager PlanetInfoControler;

        #endregion

        /// <summary>
        /// Constractror
        /// </summary>
        public pgMissionCalculator()
        {
            InitializeComponent();
            errorFileInit();
            planetFilesInit(0);
            SMath.objList = currentPlanetList;
            PlanetInfoControler = new PlaneInfoManager(currentPlanetList, grdPlanetInfo,
                comboBoxOrigin, comboBoxStop1, comboBoxStop2, comboBoxStop3, 
                expanderOrigin, expanderStop1, expanderStop2, expanderStop3);
            RoutesControler = new RoutesInfoControlSets(PlanetInfoControler.CSList(), grdRouteInfo, checkBoxReturn);
            RoutesControler.Update();
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
                string displayName = string.Empty;
                displayName = (obj.Type == Types.Moon) ? "    " + obj.Name : obj.Name;
                comboBoxOrigin.Items.Add(displayName);
                comboBoxStop1.Items.Add(displayName);
                comboBoxStop2.Items.Add(displayName);
                comboBoxStop3.Items.Add(displayName);
            }
            comboBoxOrigin.SelectedIndex = 0;
            comboBoxStop1.SelectedIndex = 0;
            comboBoxStop2.SelectedIndex = 0;
            comboBoxStop3.SelectedIndex = 0;
        }

        #endregion

        #region "Event Handlers"


        private void Main_Loaded(object sender, RoutedEventArgs e)
        {

        }
        
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cboPlanetsSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if(PlanetInfoControler != null)PlanetInfoControler.Update();
            if (RoutesControler != null) RoutesControler.Update();
        }

        //private void cboGameMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    planetFilesInit(((ComboBox)sender).SelectedIndex);
        //}

        private void MainEvent(object sender, RoutedEventArgs e)
        {
            if (PlanetInfoControler != null) PlanetInfoControler.Update();
            if (RoutesControler != null) RoutesControler.Update();
        }

        private void expander_Expanded(object sender, RoutedEventArgs e)
        {
            if (PlanetInfoControler != null) PlanetInfoControler.Update();
            if (RoutesControler != null) RoutesControler.Update();
        }

        #endregion

    }
}
