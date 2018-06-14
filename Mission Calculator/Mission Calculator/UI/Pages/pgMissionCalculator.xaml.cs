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
        PlaneInfoHandler PlanetInfoControler;
        List<Brush> UIColors = new List<Brush>();

        #endregion

        /// <summary>
        /// Constractror
        /// </summary>
        public pgMissionCalculator()
        {
            InitializeComponent();
            Globals.errorFileInit();
            currentPlanetList = Globals.planetFilesInit(0);
            UIColors.Add(Brushes.Wheat);
            UIColors.Add(Brushes.PowderBlue);
            UIColors.Add(Brushes.AliceBlue);
            UIColors.Add(Brushes.Aquamarine);
        }

        #region "Methods"


        #endregion

        #region "Event Handlers"


        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                PlanetInfoControler = new PlaneInfoHandler(grdPlanetInfo, grdPlanetSelection, grdRouteInfo, UIColors);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
       
        #endregion

    }
}
