using Mission_Calculator.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission_Calculator.Classes
{
    public static class SMath
    {
        public static List<SelestialObject> objList { get; set; }
        
        /// <summary>
        /// Public Method DeltaVCost 
        /// </summary>
        /// <param name="from">1st mandatory parameter defines the starting point </param>
        /// <param name="orbitHeight"></param>
        /// <returns>Returns the cost of Delta V (m/s) from the parameter planet</returns>
        public static double DeltaVCost(SelestialObject objFrom, SelestialObject objTo)
       {
           double DVCost = 0.0;
           return DVCost;
       }

       /// <summary>
       /// Calculates the phase angle for the Hohhman's Transer Orbit between the current celistial oject 
       /// and a target selestial object. The bellow method is not quite accurate but it is a start.
       /// </summary>
       /// <param name="objTo">The target selestial object</param>
       /// <returns>Returns the phase angle between the current object and tha target object </returns>
       public static double DeparturePhaseAngle(SelestialObject objFrom, SelestialObject objTo)
       {
           try
           {
                double HohmannTransferTime = 0, Angle = 0 , orbPeriodFrom = 0, orbPeriodTo = 0;
                findActualOrbit(objFrom, objTo, out orbPeriodFrom,out orbPeriodTo);
                HohmannTransferTime = HohmanTransferTime(objFrom, objTo);
                Angle = 180 - (360 * (HohmannTransferTime / orbPeriodTo));
                if (Angle < -180 && Angle >= -360) Angle += 360;
                else if (Angle < -360) Angle += Math.Abs(Math.Truncate(Angle / 360) * 360);
                return Angle;
           }
           catch (Exception)
           {

               throw;
           }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFrom"></param>
        /// <param name="objTo"></param>
        /// <param name="orbPeriodFrom"></param>
        /// <param name="orbPeriodTo"></param>
        private static void findActualOrbit(SelestialObject objFrom, SelestialObject objTo, out double orbPeriodFrom, out double orbPeriodTo)
        {
            if (objFrom.Index != objFrom.ParentObjectIndex &&  objTo.ParentObjectIndex != objTo.Index && 
                objFrom.ParentObjectIndex != objTo.ParentObjectIndex)
            {
                orbPeriodFrom = objList[objFrom.ParentObjectIndex].OrbitalPeriod;
                orbPeriodTo = objList[objTo.ParentObjectIndex].OrbitalPeriod;
            }
            else if (objFrom.Index == objFrom.ParentObjectIndex && objTo.ParentObjectIndex != objTo.Index &&
                objFrom.ParentObjectIndex != objTo.ParentObjectIndex)
            {
                orbPeriodFrom = objFrom.OrbitalPeriod;
                orbPeriodTo = objList[objTo.ParentObjectIndex].OrbitalPeriod;
            }
            else if (objFrom.Index != objFrom.ParentObjectIndex && objTo.ParentObjectIndex == objTo.Index &&
                objFrom.ParentObjectIndex != objTo.ParentObjectIndex)
            {
                orbPeriodFrom = objList[objFrom.ParentObjectIndex].OrbitalPeriod;
                orbPeriodTo = objTo.OrbitalPeriod;
            }
            else if (objFrom.Index != objFrom.ParentObjectIndex && objTo.ParentObjectIndex != objTo.Index &&
                objFrom.ParentObjectIndex == objTo.ParentObjectIndex)
            {
                orbPeriodFrom = objFrom.OrbitalPeriod;
                orbPeriodTo = objTo.OrbitalPeriod;
            }
            else if (objFrom.Index == objTo.ParentObjectIndex)
            {
                orbPeriodFrom = 0;
                orbPeriodTo = 0;
            }
            else
            {
                orbPeriodFrom = objFrom.OrbitalPeriod;
                orbPeriodTo = objTo.OrbitalPeriod;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFrom"></param>
        /// <param name="objTo"></param>
        /// <returns></returns>
        public static double IntervalBetweenLanchWindows(SelestialObject objFrom, SelestialObject objTo)
        {
            try
            {
                double orbPeriodFrom = 0, orbPeriodTo = 0;
                findActualOrbit(objFrom, objTo, out orbPeriodFrom, out orbPeriodTo);
                if (orbPeriodFrom == 0 || orbPeriodTo == 0) return  0;
                else return Math.Abs(1 / ((1 / orbPeriodFrom) - (1 / orbPeriodTo)));
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFrom"></param>
        /// <param name="objTo"></param>
        /// <returns></returns>
        public static double HohmanTransferTime(SelestialObject objFrom, SelestialObject objTo)
        {
            try
            {
                double orbPeriodFrom = 0, orbPeriodTo = 0;
                findActualOrbit(objFrom, objTo, out orbPeriodFrom, out orbPeriodTo);
                //Calculate the Hohmann's Transer Time in seconds
                //HTT= ((OrbitalPeriod1^2/3 + OrbitalPeriod2^2/3)^1.5)/sqr32
                //calculate the Hohmann's Transfer Time only by the orbital periods of the 2 selestial objects is not the best way.
                return Math.Pow((Math.Pow(orbPeriodFrom, (2.0 / 3.0)) + Math.Pow(orbPeriodTo, (2.0 / 3.0))), 1.5) / Math.Sqrt(32.0);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
