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
        /// <summary>
       /// Public Method DeltaVCost 
       /// </summary>
       /// <param name="from">1st mandatory parameter defines the starting point </param>
       /// <param name="orbitHeight"></param>
       /// <returns>Returns the cost of Delta V (m/s) from the parameter planet</returns>
       public static double DeltaVCost(SelestialObject from, Orbit orbitHeight)
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
               double HohmannTransferTime = 0, Angle = 0;

               //calculate phase agnle for moons of the same planet demands more properties for objFrom class so retuern 0 for now.
               if (objTo.System == objFrom.System && objTo.Orbits != objFrom.Orbits) return 0;

               //Calculate the Hohmann's Transer Time in seconds
               //HTT= ((OrbitalPeriod1^2/3 + OrbitalPeriod2^2/3)^1.5)/sqr32
               //calculate the Hohmann's Transfer Time only by the orbital periods of the 2 selestial objects is not the best way.
               HohmannTransferTime = Math.Pow((Math.Pow(objTo.OrbitalPeriod, (2.0 / 3.0)) +
                                     Math.Pow(objFrom.OrbitalPeriod, (2.0 / 3.0))), 1.5) /
                                     Math.Sqrt(32.0);
               Angle = 180 - (360 * (HohmannTransferTime / objTo.OrbitalPeriod));
               if (Angle< -180 && Angle >= -360) Angle += 360;
               else if (Angle< -360) Angle += Math.Abs(Math.Truncate(Angle / 360) * 360);
               return Angle;
           }
           catch (Exception)
           {

               throw;
           }
       }

    }
}
