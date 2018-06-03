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

        #endregion

        #region "Public Properties"

        #region "General Properties"
        public string Name { get; set; }
        public int Index { get; set; }
        public string ImageUri { get; set; }
        public Types Type { get; set; }
        public Systems System { get; set; }
        public Orbits Orbits { get; set; }
        public int ParentObjectIndex { get; set; }
        #endregion

        #region "Technical Properties"
        public double OrbitalPeriod { get; set; }
        public double SphereOfInfluence { get; set; }
        public double SurfaceGravity { get; set; }
        public bool HasAtmosphere { get; set; }
        public bool HasOxigen { get; set; }
        public double AtmosphericPressure { get; set; }
        public double LowerAtmoHeight { get; set; }
        public double UpperAtmoHeight { get; set; }
        public double LowOrbitHeight { get; set; }
        public double EscapeVelocity { get; set; }
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
        public SelestialObject(SelestialObject parentObject = null)
        {
            this.Name = "None";
            this.Index = 0;
            this.ImageUri = @"pack://application:,,/Images/Planets/None.png";
            this.Type = Types.Star;
            this.System = Systems.None;
            this.OrbitalPeriod = 0;
            this.SphereOfInfluence = 0;
            this.LowOrbitHeight = 0;
            this.SurfaceGravity = 0;
            this.HasAtmosphere = false;
            this.HasOxigen = false;
            this.AtmosphericPressure = 0;
            this.LowerAtmoHeight = 0;
            this.UpperAtmoHeight = 0;
            this.LowOrbitHeight = 0;
            this.EscapeVelocity = 0;
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
            strSpecs += "Surface Gravity : " + this.SurfaceGravity + " m/s²    Low Orbit : " + this.LowOrbitHeight;
            strSpecs += Environment.NewLine;
            strSpecs += "Escape Velocity : " + this.EscapeVelocity + " m/s    Sphere of influence : " + this.SphereOfInfluence;
            strSpecs += Environment.NewLine;
            strSpecs += "Atmosphere Present: " + this.HasAtmosphere;

            if (this.HasAtmosphere) strSpecs += "   Oxygen Present : " + this.HasOxigen + "    Pressure : " + this.AtmosphericPressure + " atm";
            
            strSpecs += Environment.NewLine;
            strSpecs += "Biomes : " + this.TotalBiomesCount + "   Scientific Multiplier:    Surface : " + this.SMSurface + "    Lower atmo : " + this.SMLowerAtmosphere;
            strSpecs += Environment.NewLine;
            strSpecs += "Upper Atmo : " + this.SMUpperAtmosphere + "   Near Space : " + this.SMNearSpace + "   Outer Space : " + this.SMOuterSpace;
            strSpecs += Environment.NewLine;
            strSpecs += " Δv info : " + "   Surface to Low Orbit : " + string.Format("{0:n0}", this.SurfaceToLowOrbit) + "m/s    Low Orbit to SOI Edge : " +
                            string.Format("{0:n0}", (this.LowOrbitToMoonIntercept + this.MoonInterceptToElipticalOrbit + this.ElipticalOrbitToPlanetIntercet + this.LowOrbitToElipticalOrbit +
                                                     this.PlanetInterceptToStarElipticalOrbit)) + "m/s";
            return strSpecs;
        }

        #endregion
    }
}
