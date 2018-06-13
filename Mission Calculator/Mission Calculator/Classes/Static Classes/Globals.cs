using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace Mission_Calculator.Classes
{
    public static class Globals
    {
        #region "General Declaration"

        public static List<SelestialObject> objList { get; set; }
        public static MainWindow ParetWindow { get; set; }

        public const int StockPlanetsCount = 18;
        public const int OuterPlanetsCount = 32;
        public const int RssPlanetsCount = 17;
        public const int KerbinTime = 21600; //seconds per day
        public const int EarthTime = 86400; //seconds per day

        static string saveDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Interplanetary Mission Calulator";
        static string planeDataDirectoryPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\PlanetsData";
        static string StockPlanetsPath = planeDataDirectoryPath + "\\StockPlanets.json";
        static string OuterPlanetsPath = planeDataDirectoryPath + "\\OuterPlanets.json";
        static string RSSPlanetsPath = planeDataDirectoryPath + "\\RSSPlanets.json";

        #endregion

        #region "Constractor"

        #endregion

        #region "Methods"
        public static List<SelestialObject> planetFilesInit(int mode)
        {
            if (objList != null) objList.Clear();
            switch (mode)
            {
                case 0:
                    objList = IO.LoadListFromFile(StockPlanetsPath);
                    break;
                case 1:
                    objList = IO.LoadListFromFile(OuterPlanetsPath);
                    break;
                case 2:
                    objList = IO.LoadListFromFile(RSSPlanetsPath);
                    break;
                default:
                    objList = IO.LoadListFromFile(StockPlanetsPath);
                    break;
            }
            return objList;
        }

        public static void errorFileInit()
        {
            string errorFilePath = saveDirectoryPath + "\\errorLog.txt";
            IO.errorFilePath = errorFilePath;
            IO.createFile(errorFilePath, "");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void saveFilesInit()
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
                objList.Add(new SelestialObject());
            }
            IO.saveListToFile(RSSPlanetsPath, objList);
            objList.Clear();
        }

        /// <summary>
        /// Returns a new coloured Run with text
        /// </summary>
        /// <param name="txt">Text to include the Run</param>
        /// <param name="brush">Colour of Text</param>
        /// <returns>A new coloured Run with text</returns>
        public static Run coloredRun(string txt, Brush brush, string txtToolTip = "")
        {
            try
            {
                if (String.IsNullOrEmpty(txtToolTip))
                    return new Run { Text = txt, Foreground = brush };
                else
                    return new Run { Text = txt, Foreground = brush, ToolTip = txtToolTip };
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secs"></param>
        /// <returns></returns>
        public static string FormatTimeFromSecs(double secs)
        {
            try
            {
                TimeSpan t = TimeSpan.FromSeconds(secs);
                return string.Format("{0:D2} d {1:D2} h {2:D2} m", t.Days, t.Hours, t.Minutes);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
