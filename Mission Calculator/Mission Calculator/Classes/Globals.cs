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

        /// <summary>
        /// Returns a new coloured Run with text
        /// </summary>
        /// <param name="txt">Text to include the Run</param>
        /// <param name="brush">Colour of Text</param>
        /// <returns>A new coloured Run with text</returns>
        public static Run coloredRun(string txt, Brush brush)
        {
            try
            {
                return new Run(txt) { Foreground = brush };
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
                return string.Format("{0:D2}h {1:D2}m {2:D2}s", t.Hours, t.Minutes, t.Seconds);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
