using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mission_Calculator.Enumerators;

namespace Mission_Calculator.Classes
{
    public class SelestialObject
    {
        #region "General Declaration"

        #region "Private Properties"

        private static string SemiMajorAxisUM= "m";
        private static string ApoapsisUM= "m";
        private static string PeriapsisUM= "m";
        private static string OrbitalInclinationUM= "°";
        private static string ArgumentOfPeriapsisUM= "°";
        private static string LongitudeOfTheAscendingNodeUM= "°";
        private static string MeanAndomalyUM= "rad";
        private static string OrbitalPeriodUM = "s";
        private static string OrbitalVelocityUM= "m/s";

        private static string EquatorialRadiusUM= "m";
        private static string EquatorialCircumferenceUM= "m";
        private static string SurfaceAreaUM= "m²";
        private static string MassUM= "kg";
        private static string StandarGravitonialParameterUM= "m²/s²";
        private static string DensityUM= "kg/m³";
        private static string SurfaceGravityUM= "m/s²";
        private static string EscapeVelocityUM= "m/s";
        private static string SiderealRotationPeriodUM= "s";
        private static string SolarDayUM= "s";
        private static string SiderealRotationVelocityUM= "m/s";
        private static string SynchronousOrbitUM= "km";
        private static string SphereOfInfluenceUM= "m";

        private static string AtmosphericPressureUM= "atm";
        private static string ScaleHeightUM= "m";
        private static string AtmosphericHeightUM= "m";
        private static string LowOrbitHeightUM= "km";
        private static string TemperatureUM= "°C";
        private static string DeltaVUM= "m/s";

        #endregion

        #region "Public Properties"

        #region "General Properties"
        public string Name { get; set; }
        public int Index { get; set; }
        public string ImageUri { get; set; }
        public string BiomeImageUri { get; set; }
        public Types Type { get; set; }
        public Systems System { get; set; }
        public Orbits Orbits { get; set; }
        public int ParentObjectIndex { get; set; }
        #endregion

        #region "Orbital Characteristics"
        public double SemiMajorAxis { get; set; }
        public double Apoapsis { get; set; }
        public double Periapsis { get; set; }
        public double OrbitalEccentricity { get; set; }
        public double OrbitalInclination { get; set; }
        public double ArgumentOfPeriapsis { get; set; }
        public double LongitudeOfTheAscendingNode { get; set; }
        public double MeanAndomaly { get; set; }
        public double OrbitalVelocity { get; set; }
        public double OrbitalPeriod { get; set; }
        #endregion

        #region "Phisical Characteristics"
        public double EquatorialRadius { get; set; }
        public double EquatorialCircumference { get; set; }
        public double SurfaceArea { get; set; }
        public double Mass { get; set; }
        public double StandarGravitonialParameter { get; set; }
        public double Density { get; set; }
        public double SurfaceGravity { get; set; }
        public double EscapeVelocity { get; set; }
        public double SiderealRotationPeriod { get; set; }
        public double SolarDay { get; set; }
        public double SiderealRotationVelocity { get; set; }
        public double SynchronousOrbit { get; set; }
        public double SphereOfInfluence { get; set; }
        #endregion

        #region "Atmospheric Characteristics"
        public bool AtmospherePresent { get; set; }
        public bool OxygenPresent { get; set; }
        public double AtmosphericPressure { get; set; }
        public double ScaleHeight { get; set; }
        public double AtmosphericHeight { get; set; }
        public double LowOrbitHeight { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        #endregion

        #region "Science Relative Properties"
        public int TotalBiomesCount { get; set; }
        public double SMSurface { get; set; }
        public double SMLowerAtmosphere { get; set; }
        public double SMUpperAtmosphere { get; set; }
        public double SMNearSpace { get; set; }
        public double SMOuterSpace { get; set; }
        #endregion

        #region "Delta V Relative Properties"
        public int SurfaceToLowOrbit { get; set; }
        public int LowOrbitToMoonIntercept { get; set; }
        public int MoonInterceptToElipticalOrbit { get; set; }
        public int MoonInterceptToElipticalOrbitMPC { get; set; }
        public int LowOrbitToElipticalOrbit { get; set; }
        public int ElipticalOrbitToPlanetIntercet { get; set; }
        public int PlanetInterceptToStarElipticalOrbit { get; set; }
        public int MaxPlaneChange { get; set; }
        #endregion

        #endregion

        #endregion

        #region "Public Methods"

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="parentObject"></param>
        public SelestialObject()
        {
            this.Name = "None";
            this.Index = 0;
            this.ImageUri = @"pack://application:,,/Images/Planets/None.png";
            this.BiomeImageUri = @"pack://application:,,/Images/Planets/None.png";
            this.Type = Types.Star;
            this.System = Systems.None;

            this.SemiMajorAxis= 0;
            this.Apoapsis= 0;
            this.Periapsis= 0;
            this.OrbitalEccentricity= 0;
            this.OrbitalInclination= 0;
            this.ArgumentOfPeriapsis= 0;
            this.LongitudeOfTheAscendingNode= 0;
            this.MeanAndomaly= 0;
            this.OrbitalPeriod= 0;
            this.OrbitalVelocity = 0;

            this.EquatorialRadius= 0;
            this.EquatorialCircumference= 0;
            this.SurfaceArea= 0;
            this.Mass= 0;
            this.StandarGravitonialParameter= 0;
            this.Density= 0;
            this.SurfaceGravity= 0;
            this.EscapeVelocity= 0;
            this.SiderealRotationPeriod= 0;
            this.SolarDay= 0;
            this.SiderealRotationVelocity= 0;
            this.SynchronousOrbit= 0;
            this.SphereOfInfluence= 0;

            this.AtmospherePresent= false;
            this.OxygenPresent= false;
            this.AtmosphericPressure= 0;
            this.ScaleHeight= 0;
            this.AtmosphericHeight= 0;
            this.LowOrbitHeight= 0;
            this.TemperatureMin= 0;
            this.TemperatureMax= 0;

            this.TotalBiomesCount = 0;
            this.SMSurface = 0;
            this.SMLowerAtmosphere = 0;
            this.SMUpperAtmosphere = 0;
            this.SMNearSpace = 0;
            this.SMOuterSpace = 0;
            this.SurfaceToLowOrbit = 0;
            this.LowOrbitToMoonIntercept = 0;
            this.MoonInterceptToElipticalOrbit = 0;
            this.MoonInterceptToElipticalOrbitMPC = 0;
            this.LowOrbitToElipticalOrbit = 0;
            this.ElipticalOrbitToPlanetIntercet = 0;
            this.PlanetInterceptToStarElipticalOrbit = 0;
            this.MaxPlaneChange = 0;
        }

        /// <summary>
        /// Public Method DeltaVCost 
        /// </summary>
        /// <param name="from">1st mandatory parameter defines the starting point </param>
        /// <param name="orbitHeight"></param>
        /// <returns>Returns the cost of Delta V (m/s) from the parameter planet</returns>
        public double DeltaVCost(SelestialObject from, OrbitHeight orbitHeight)
        {
            double DVCost = 0.0;
            return DVCost;
        }

        /// <summary>
        /// Public Method that calculates the phase angle for the Hohhman's Transer Orbit between the current celistial oject 
        /// and a target selestial object. The bellow method is not quite accurate but it is a start.
        /// </summary>
        /// <param name="objectTo">The target selestial object</param>
        /// <returns>Returns the phase angle between the current object and tha target object </returns>
        public double PhaseAngle(SelestialObject objectTo)
        {
            double HohmannTransferTime = 0, Angle = 0;

            //calculate phase agnle for moons of the same planet demands more properties for this class so retuern 0 for now.
            if (objectTo.System == this.System && objectTo.Orbits != this.Orbits) return 0;

            //Calculate the Hohmann's Transer Time in seconds
            //HTT= ((OrbitalPeriod1^2/3 + OrbitalPeriod2^2/3)^1.5)/sqr32
            //calculate the Hohmann's Transfer Time only by the orbital periods of the 2 selestial objects is not the best way.
            HohmannTransferTime = Math.Pow((Math.Pow(objectTo.OrbitalPeriod, (2.0 / 3.0)) + Math.Pow(this.OrbitalPeriod, (2.0 / 3.0))), 1.5) / Math.Sqrt(32.0);
            Angle = 180 - (360 * (HohmannTransferTime / objectTo.OrbitalPeriod));
            if (Angle < -180 && Angle >= -360) Angle += 360;
            else if (Angle < -360) Angle += Math.Abs(Math.Truncate(Angle / 360) * 360);
            return Angle;
        }

        /// <summary>
        /// Overides the base ToString() method
        /// </summary>
        /// <returns>Returns a string with the properties of the class</returns>
        public override string ToString()
        {
            string strSpecs = string.Empty;

            strSpecs = "Celestial object : " + this.Name + "    Type : " + this.Type;

            if (this.Type == Types.Moon) strSpecs += "    Moon of : " + this.System;

            strSpecs += Environment.NewLine;
            strSpecs += "Surface Gravity : " + this.SurfaceGravity + " m/s²    Low Orbit : " + this.LowOrbitHeight + "km    Low Orbit : ";
            strSpecs += Environment.NewLine;
            strSpecs += "Escape Velocity : " + this.EscapeVelocity.ToString("N") + " m/s    Sphere of influence : " + this.SphereOfInfluence.ToString("N") + " m";
            strSpecs += Environment.NewLine;
            strSpecs += "Atmosphere Present: " + this.AtmospherePresent;

            if (this.AtmospherePresent) strSpecs += "   Oxygen Present : " + this.OxygenPresent + "    Pressure : " + this.AtmosphericPressure + " atm";
            
            strSpecs += Environment.NewLine;
            strSpecs += "Biomes : " + this.TotalBiomesCount + "   Scientific Multiplier:[  S : " + this.SMSurface + "    LA : " + this.SMLowerAtmosphere;
            strSpecs += "    UA : " + this.SMUpperAtmosphere + "   NS : " + this.SMNearSpace + "   OS : " + this.SMOuterSpace + "  ]";
            strSpecs += Environment.NewLine;
            strSpecs += "Δv info : " + "   Surface to Low Orbit : " + string.Format("{0:n0}", this.SurfaceToLowOrbit) + " m/s    Low Orbit to SOI Edge : " +
                            string.Format("{0:n0}", (this.LowOrbitToMoonIntercept + this.MoonInterceptToElipticalOrbit + this.ElipticalOrbitToPlanetIntercet + this.LowOrbitToElipticalOrbit +
                                                     this.PlanetInterceptToStarElipticalOrbit)) + " m/s";
            return strSpecs;
        }

        #endregion
    }
}
