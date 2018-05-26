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
    }
}
