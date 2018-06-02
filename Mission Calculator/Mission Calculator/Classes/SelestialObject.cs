using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mission_Calculator.Enumerators;

namespace Mission_Calculator.Classes
{
    public abstract class SelestialObject
    {

        #region "General Properties"
        protected string Name;
        protected int Index;
        protected int ParentIndex;
        protected string ImageUri;
        protected Types Type;
        protected Systems System;
        protected Orbits Orbits;
        #endregion

        #region "Technical Properties"
        protected double OrbitalPeriod;
        protected double SphereOfInfluence;
        protected double SurfaceGravity;
        protected bool HasAtmosphere;
        protected bool HasOxigen;
        protected double AtmosphericPressure;
        protected double LowerAtmoHeight;
        protected double UpperAtmoHeight;
        protected double LowOrbitHeight;
        protected double EscapeVelocity;
        #endregion

        #region "Science Relative Properties"
        protected int TotalBiomesCount;
        protected double SMSurface;
        protected double SMLowerAtmosphere;
        protected double SMUpperAtmosphere;
        protected double SMNearSpace;
        protected double SMOuterSpace;
        #endregion

        #region "Delta V Relative Properties"
        protected int SurfaceToLowOrbit;
        protected int LowOrbitToMoonIntercept;
        protected int MoonInterceptToElipticalOrbit;
        protected int MoonInterceptToElipticalOrbitMPC;
        protected int LowOrbitToElipticalOrbit;
        protected int ElipticalOrbitToPlanetIntercet;
        protected int PlanetInterceptToStarElipticalOrbit;
        protected int MaxPlaneChange;
        #endregion

        #region "Protected Mehods"
        protected virtual double DeltaVCost(SelestialObject from)
        {
            double DVCost = 0.0;
            return DVCost;
        }
        #endregion

        #region "Public Methods"
        public override string ToString()
        {
            string strSpecs = string.Empty;

            strSpecs = "Celestial object : " + this.Name + "    Type : " + this.Type;

            if (this.Type == Types.Moon) strSpecs += "    Moon of : " + this.System;

            strSpecs += Environment.NewLine;
            strSpecs += "Surface Gravity : " + this.SurfaceGravity + " m/s²    Low Orbit : " + this.LowOrbitHeight;
            strSpecs += Environment.NewLine;
            strSpecs += "Escape Velocity : " + this.EscapeVelocity + "    Sphere of influence : " + this.SphereOfInfluence;
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
