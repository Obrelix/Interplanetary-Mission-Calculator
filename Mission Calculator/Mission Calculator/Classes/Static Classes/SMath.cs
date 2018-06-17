using Mission_Calculator.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mission_Calculator.Classes
{
    public static class SMath
    {
        #region "General Declaration"

        static Routes route;
        static List<SelestialObject> objList = Globals.objList;
        static bool isParentPlanetToMoon;
        static bool isMoonToParentPlanet;
        static bool is0;
        static bool isMoonsOfOtherPlanets;
        static bool isPlanetToOtherMoon;
        static bool isMoonToOtherPlanet;
        static bool isMoonsOfTheSameSystem;
        static bool isInterplanetary;

        #endregion

        #region "Constractor"

        #endregion

        #region "Methods"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="distance"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Point FindNextPointByAngleAndDistance(Point startPoint, double distance, double angle)
        {
            try
            {
                double angleRads = angle * Math.PI / 180;//convert to rads
                double X2 = startPoint.X + Math.Cos(angleRads) * distance;
                double Y2 = startPoint.Y - Math.Sin(angleRads) * distance;
                return new Point(X2, Y2);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Public Method DeltaVCost 
        /// </summary>
        /// <param name="from">1st mandatory parameter defines the starting point </param>
        /// <param name="orbitHeight"></param>
        /// <returns>Returns the cost of Delta V (m/s) from the parameter planet</returns>
        public static double DeltaVCost(Routes route)
        {
            double DVCost = 0.0;
            SMath.route = route;
            blnPropsInit();

            if (route.OrbitFrom != Orbit.Low)
                DVCost += route.ObjectFrom.SurfaceToLowOrbit;
            DVCost += route.ObjectFrom.LowOrbitToElipticalOrbit + route.ObjectFrom.LowOrbitToMoonIntercept + route.ObjectFrom.MoonInterceptToElipticalOrbit;

            if (route.OrbitTo != Orbit.Low && !route.ObjectTo.AtmospherePresent)
                DVCost += route.ObjectTo.SurfaceToLowOrbit;
            DVCost += route.ObjectTo.LowOrbitToMoonIntercept + route.ObjectTo.LowOrbitToElipticalOrbit + route.ObjectTo.MoonInterceptToElipticalOrbit;

            if (isInterplanetary)
            {
                DVCost += route.ObjectFrom.ElipticalOrbitToPlanetIntercet + route.ObjectFrom.PlanetInterceptToStarElipticalOrbit + route.ObjectFrom.MaxPlaneChange;
                DVCost += route.ObjectTo.ElipticalOrbitToPlanetIntercet + route.ObjectTo.PlanetInterceptToStarElipticalOrbit + route.ObjectTo.MaxPlaneChange;
            }

            return DVCost;
        }

        /// <summary>
        /// Calculates the phase angle for the Hohhman's Transer Orbit between 2 celistial ojects.         
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public static double DeparturePhaseAngle(Routes route, out double Rotations)
        {
            try
            {
                double HohmannTransferTime = 0, Angle = 0, orbPeriodFrom = 0, orbPeriodTo = 0;
                HohmannTransferTime = HohmanTransferTime(route);
                Rotations = 0;
                if (!findActualOrbit(out orbPeriodFrom, out orbPeriodTo)) return 0;
                Angle = 180 - (360 * (HohmannTransferTime / orbPeriodTo));
                Rotations = Math.Abs(Angle / 360);
                if (Angle < -360) Angle += Math.Abs(Math.Truncate(Angle / 360) * 360);
                if (Angle < -180) Angle += 360;
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
        private static void blnPropsInit()
        {
            try
            {

                isParentPlanetToMoon = (route.ObjectFrom.ParentObjectIndex == route.ObjectTo.Index);

                isMoonToParentPlanet = (route.ObjectFrom.Index == route.ObjectTo.ParentObjectIndex);

                is0 = (route.ObjectFrom.OrbitalPeriod == 0 || route.ObjectTo.OrbitalPeriod == 0);

                isMoonsOfOtherPlanets = (route.ObjectFrom.Index != route.ObjectFrom.ParentObjectIndex
                                            && route.ObjectTo.ParentObjectIndex != route.ObjectTo.Index
                                            && route.ObjectFrom.ParentObjectIndex != route.ObjectTo.ParentObjectIndex);

                isPlanetToOtherMoon = (route.ObjectFrom.Index == route.ObjectFrom.ParentObjectIndex
                                            && route.ObjectTo.ParentObjectIndex != route.ObjectTo.Index
                                            && route.ObjectFrom.ParentObjectIndex != route.ObjectTo.ParentObjectIndex);

                isMoonToOtherPlanet = (route.ObjectFrom.Index != route.ObjectFrom.ParentObjectIndex
                                            && route.ObjectTo.ParentObjectIndex == route.ObjectTo.Index
                                            && route.ObjectFrom.ParentObjectIndex != route.ObjectTo.ParentObjectIndex);

                isMoonsOfTheSameSystem = (route.ObjectFrom.Index != route.ObjectFrom.ParentObjectIndex
                                            && route.ObjectTo.ParentObjectIndex != route.ObjectTo.Index
                                            && route.ObjectFrom.ParentObjectIndex == route.ObjectTo.ParentObjectIndex);

                isInterplanetary = (isMoonsOfOtherPlanets || isMoonToOtherPlanet || isPlanetToOtherMoon || isMoonToOtherPlanet) 
                                            || (route.ObjectFrom.ParentObjectIndex == route.ObjectFrom.Index && route.ObjectTo.Index == route.ObjectTo.ParentObjectIndex 
                                            && route.ObjectFrom.Index != route.ObjectTo.Index);
                                        

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orbPeriodFrom"></param>
        /// <param name="orbPeriodTo"></param>
        /// <returns></returns>
        static bool findActualOrbit(out double orbPeriodFrom, out double orbPeriodTo)
        {
            try
            {
                blnPropsInit();
                if (is0 || isMoonToParentPlanet || isParentPlanetToMoon) { orbPeriodFrom = 0; orbPeriodTo = 0; return false; }

                if (isMoonsOfOtherPlanets)
                {
                    orbPeriodFrom = objList[route.ObjectFrom.ParentObjectIndex].OrbitalPeriod;
                    orbPeriodTo = objList[route.ObjectTo.ParentObjectIndex].OrbitalPeriod;
                    return true;
                }
                else if (isPlanetToOtherMoon)
                {
                    orbPeriodFrom = route.ObjectFrom.OrbitalPeriod;
                    orbPeriodTo = objList[route.ObjectTo.ParentObjectIndex].OrbitalPeriod;
                    return true;
                }
                else if (isMoonToOtherPlanet)
                {
                    orbPeriodFrom = objList[route.ObjectFrom.ParentObjectIndex].OrbitalPeriod;
                    orbPeriodTo = route.ObjectTo.OrbitalPeriod;
                    return true;
                }
                else { orbPeriodFrom = route.ObjectFrom.OrbitalPeriod; orbPeriodTo = route.ObjectTo.OrbitalPeriod; return true; }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void findActualObject(out SelestialObject objInner, out SelestialObject objOuter)
        {
            try
            {
                blnPropsInit();

                if (isMoonsOfOtherPlanets)
                {
                    switch (objList[route.ObjectFrom.ParentObjectIndex].OrbitalPeriod < objList[route.ObjectTo.ParentObjectIndex].OrbitalPeriod)
                    {
                        case true:
                            objInner = objList[route.ObjectFrom.ParentObjectIndex];
                            objOuter = objList[route.ObjectTo.ParentObjectIndex];
                            break;
                        default:
                            objInner = objList[route.ObjectTo.ParentObjectIndex];
                            objOuter = objList[route.ObjectFrom.ParentObjectIndex];
                            break;
                    }
                }
                else if (isPlanetToOtherMoon)
                {
                    switch (route.ObjectFrom.OrbitalPeriod < objList[route.ObjectTo.ParentObjectIndex].OrbitalPeriod)
                    {
                        case true:
                            objInner = route.ObjectFrom;
                            objOuter = objList[route.ObjectTo.ParentObjectIndex];
                            break;
                        default:
                            objInner = objList[route.ObjectTo.ParentObjectIndex];
                            objOuter = route.ObjectFrom;
                            break;
                    }
                }
                else if (isMoonToOtherPlanet)
                {
                    switch (objList[route.ObjectFrom.ParentObjectIndex].OrbitalPeriod < route.ObjectTo.OrbitalPeriod)
                    {
                        case true:
                            objInner = objList[route.ObjectFrom.ParentObjectIndex];
                            objOuter = route.ObjectTo;
                            break;
                        default:
                            objInner = route.ObjectTo;
                            objOuter = objList[route.ObjectFrom.ParentObjectIndex];
                            break;
                    }
                }
                else
                {
                    switch (route.ObjectFrom.OrbitalPeriod < route.ObjectTo.OrbitalPeriod)
                    {
                        case true:
                            objInner = route.ObjectFrom;
                            objOuter = route.ObjectTo;
                            break;
                        default:
                            objInner = route.ObjectTo;
                            objOuter = route.ObjectFrom;
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public static double IntervalBetweenLanchWindows(Routes route)
        {
            try
            {
                SMath.route = route;
                double orbPeriodFrom = 0, orbPeriodTo = 0;
                if (!findActualOrbit(out orbPeriodFrom, out orbPeriodTo)) return 0;
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
        /// <param name="route"></param>
        /// <returns></returns>
        public static double HohmanTransferTime(Routes route)
        {
            try
            {
                SMath.route = route;
                double orbPeriodFrom = 0, orbPeriodTo = 0;
                if (!findActualOrbit(out orbPeriodFrom, out orbPeriodTo)) return 0;
                //Calculate the Hohmann's Transer Time in seconds
                //HTT= ((OrbitalPeriod1^2/3 + OrbitalPeriod2^2/3)^1.5)/sqr32
                //calculate the Hohmann's Transfer Time only by the orbital periods of the 2 selestial objects is not the best way but it is a start :P.
                return Math.Pow((Math.Pow(orbPeriodFrom, (2.0 / 3.0)) + Math.Pow(orbPeriodTo, (2.0 / 3.0))), 1.5) / Math.Sqrt(32.0);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static double map(
           double originalStart, double originalEnd, // original range
           double newStart, double newEnd, // desired range
           double value) // value to convert
        {
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (newStart + ((value - originalStart) * scale));
        }
        #endregion


    }
}
