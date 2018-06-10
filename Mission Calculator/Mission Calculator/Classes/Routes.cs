using Mission_Calculator.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace Mission_Calculator.Classes
{
    public class Routes
    {
        public string Name { get; set; }
        public SelestialObject ObjectFrom { get; set; }
        public SelestialObject ObjectTo { get; set; }
        public Orbit OrbitFrom { get; set; }
        public Orbit OrbitTo { get; set; }

        public double DeparturePhaseAngle { get; set; }
        public double DeltaVBugdet { get; set; }
        public double TranferTime { get; set; }
        public double IntervalBetweenLanchWindows { get; set; }
        public string strTransferTime{get{return Globals.FormatTimeFromSecs(TranferTime);} }
        public string strInterval { get { return Globals.FormatTimeFromSecs(IntervalBetweenLanchWindows); } }
        public string strDv { get { return String.Format("{0:n0}", DeltaVBugdet + " m/s"); } }
        public string strPhAngle { get { return String.Format("{0:n2}", DeparturePhaseAngle + " °"); } }

        public Routes()
        {

        }

        public List<Run> ToShortRunList(Brush nameBrush, Brush valueBrush)
        {
            try
            {
                List<Run> objPropsRunList = new List<Run>();
                objPropsRunList.Clear();

                objPropsRunList.Add(Globals.coloredRun(ObjectFrom.Name, valueBrush));
                objPropsRunList.Add(Globals.coloredRun(" --> ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(ObjectTo.Name, valueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Tr. Time : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strTransferTime, valueBrush));
                objPropsRunList.Add(new Run("\t"));
                objPropsRunList.Add(Globals.coloredRun("Ph. Angle : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strPhAngle, valueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("I.B.L.W : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strInterval, valueBrush));
                objPropsRunList.Add(new Run("\t"));
                objPropsRunList.Add(Globals.coloredRun("Δv : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strDv, valueBrush));
                return objPropsRunList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override string ToString()
        {
            string strPropsToString = string.Empty;
            strPropsToString += String.Format("{0,11} {1}\n", "Name:", Name);
            strPropsToString += String.Format("{0,11} {1,6} ( {2} )\n", "From:", ObjectFrom.Name, OrbitFrom.ToString());
            strPropsToString += String.Format("{0,11} {1,6} ( {2} )\n", "To:", ObjectTo.Name, OrbitFrom.ToString());
            strPropsToString += String.Format("{0,11} {1,6} \n", "Ph. Angle:", strPhAngle);
            strPropsToString += String.Format("{0,11} {1,6} \n", "Tr. Time:", strTransferTime);
            strPropsToString += String.Format("{0,11} {1,6} \n", "I.B.L.W:", strInterval);
            strPropsToString += String.Format("{0,11} {1,6} \n", "Δv:", strInterval);
            return strPropsToString;
        }
    }
}
