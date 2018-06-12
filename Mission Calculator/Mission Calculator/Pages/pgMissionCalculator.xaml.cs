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
        List<ComboBox> cboList = new List<ComboBox>();
        List<Expander> expList = new List<Expander>();
        RoutesInfoHandler RoutesControler;
        PlaneInfoHandler PlanetInfoControler;
        #endregion

        /// <summary>
        /// Constractror
        /// </summary>
        public pgMissionCalculator()
        {
            InitializeComponent();
            Globals.errorFileInit();
            currentPlanetList = Globals.planetFilesInit(0);
            cboList.Add(comboBoxOrigin);
            cboList.Add(comboBoxStop1);
            cboList.Add(comboBoxStop2);
            cboList.Add(comboBoxStop3);
            expList.Add(expanderOrigin);
            expList.Add(expanderStop1);
            expList.Add(expanderStop2);
            expList.Add(expanderStop3);
        }

        #region "Methods"


        #endregion

        #region "Event Handlers"


        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetInfoControler = new PlaneInfoHandler(grdPlanetInfo, cboList, expList);
                RoutesControler = new RoutesInfoHandler(PlanetInfoControler.CSList(), grdRouteInfo, checkBoxReturn);
                RoutesControler.Update();
            }
            catch (Exception)
            {

                throw;
            }
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
