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
        public SelestialObject ObjectInner { get; private set; }
        public SelestialObject ObjectOuter { get; private set; }
        public Orbit OrbitFrom { get; set; }
        public Orbit OrbitTo { get; set; }
        public Brush FromBrush { get; set; }
        public Brush ToBrush { get; set; }
        public Brush TitleBrush { get; set; }
        public Brush ValueBrush { get; set; }
        public double DeparturePhaseAngle { get; private set; }
        public double DeltaVBugdet { get; private set; }
        public double TranferTime { get; private set; }
        public double IntervalBetweenLanchWindows { get; private set; }


        public string strTransferTime{get{return Globals.FormatTimeFromSecs(TranferTime);} }
        public string strInterval { get { return Globals.FormatTimeFromSecs(IntervalBetweenLanchWindows); } }
        public string strDv { get { return string.Format("{0:n0}", DeltaVBugdet + " m/s"); } }
        public string strPhAngle { get{ return DeparturePhaseAngle.ToString("n2") + " °"; } }

        public Routes()
        {
            ObjectFrom = new SelestialObject();
            ObjectTo = new SelestialObject();
            Name = "";
        }

        public Routes(string Name, SelestialObject ObjectFrom, SelestialObject ObjectTo, 
            Brush FromBrush, Brush ToBrush, Brush TitleBrush, Brush ValueBrush)
        {
            this.FromBrush = FromBrush;
            this.ToBrush = ToBrush;
            this.TitleBrush = TitleBrush;
            this.ValueBrush = ValueBrush;
            this.Name = Name;
            this.ObjectFrom = ObjectFrom;
            this.ObjectTo = ObjectTo;
            IntervalBetweenLanchWindows = SMath.IntervalBetweenLanchWindows(ObjectFrom, ObjectTo);
            TranferTime = SMath.HohmanTransferTime(ObjectFrom, ObjectTo);
            DeparturePhaseAngle = SMath.DeparturePhaseAngle(ObjectFrom, ObjectTo);
            DeltaVBugdet = SMath.DeltaVCost(ObjectFrom, ObjectTo);
            if (DeparturePhaseAngle < 0)
            {
                ObjectInner = ObjectTo;
                ObjectOuter = ObjectFrom;
            }
            else
            {
                ObjectInner = ObjectFrom;
                ObjectOuter = ObjectTo;
            }
        }

        public void Update()
        {
            try
            {
                IntervalBetweenLanchWindows = SMath.IntervalBetweenLanchWindows(ObjectFrom, ObjectTo);
                TranferTime = SMath.HohmanTransferTime(ObjectFrom, ObjectTo);
                DeparturePhaseAngle = SMath.DeparturePhaseAngle(ObjectFrom, ObjectTo);
                DeltaVBugdet = SMath.DeltaVCost(ObjectFrom, ObjectTo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Run> ToShortRunList()
        {
            try
            {
                List<Run> objPropsRunList = new List<Run>();
                objPropsRunList.Clear();
                //objPropsRunList.Add(new Run("\t"));
                objPropsRunList.Add(Globals.coloredRun("[ ", ValueBrush));
                objPropsRunList.Add(Globals.coloredRun(ObjectFrom.Name, FromBrush));
                objPropsRunList.Add(Globals.coloredRun(" --> ", TitleBrush));
                objPropsRunList.Add(Globals.coloredRun(ObjectTo.Name, ToBrush));
                objPropsRunList.Add(Globals.coloredRun(" ]", ValueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Phase Angle : ", TitleBrush));
                objPropsRunList.Add(Globals.coloredRun(strPhAngle, ValueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Transfer Δv : ", TitleBrush));
                objPropsRunList.Add(Globals.coloredRun(strDv, ValueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Travel Time : ", TitleBrush));
                objPropsRunList.Add(Globals.coloredRun(strTransferTime, ValueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("I.B.L.W     : ", TitleBrush, "Interval between launch windows."));
                objPropsRunList.Add(Globals.coloredRun(strInterval, ValueBrush));
                return objPropsRunList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override string ToString()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
