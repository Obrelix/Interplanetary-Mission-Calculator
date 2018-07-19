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


        public const int StockPlanetsCount = 18;
        public const int OuterPlanetsCount = 32;
        public const int RssPlanetsCount = 17;
        public const int KerbinTime = 21600; //seconds per day
        public const int EarthTime = 86400; //seconds per day

        #endregion

        #region "Constractor"

        #endregion

        #region "Methods"

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
                if (double.IsInfinity(secs)) return "∞";
                TimeSpan t = TimeSpan.FromSeconds(secs);
                double DayInSeconds = TimeSpan.FromDays(1).TotalSeconds;
                if (DayInSeconds < secs)
                {
                    return string.Format("{0:D2} d {1:D2} h {2:D2} m", t.Days, t.Hours, t.Minutes);
                } 
                else return string.Format("{0:D2} h {1:D2} m {2:D2} s", t.Hours, t.Minutes, t.Seconds);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

    }
}
