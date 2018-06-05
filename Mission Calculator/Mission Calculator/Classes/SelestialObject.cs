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
        #region "Private Properties"
        //"Orbital Characteristics"
        private double _semiMajorAxis;
        private double _apoapsis;
        private double _periapsis;
        private double _orbitalEccentricity;
        private double _orbitalInclination;
        private double _argumentOfPeriapsis;
        private double _longitudeOfTheAscendingNode;
        private double _meanAndomaly;
        private double _orbitalVelocity;
        private double _orbitalPeriod;
        //"Phisical Characteristics"
        private double _equatorialRadius;
        private double _equatorialCircumference;
        private double _surfaceArea;
        private double _mass;
        private double _standarGravitonialParameter;
        private double _density;
        private double _surfaceGravity;
        private double _escapeVelocity;
        private double _siderealRotationPeriod;
        private double _solarDay;
        private double _siderealRotationVelocity;
        private double _synchronousOrbit;
        private double _sphereOfInfluence;
        //"Atmospheric Characteristics"
        private bool _atmospherePresent;
        private bool _oxygenPresent;
        private double _atmosphericPressure;
        private double _scaleHeight;
        private double _atmosphericHeight;
        private double _lowOrbitHeight;
        private double _temperatureMin;
        private double _temperatureMax;
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
        public double SemiMajorAxis
        { 
            get { return _semiMajorAxis; }
            set { _semiMajorAxis = value; }
         }
        public double Apoapsis
        { 
            get { return _apoapsis; }
            set { _apoapsis = value; }
         }
        public double Periapsis
        { 
            get { return _periapsis; }
            set { _periapsis = value; }
         }
        public double OrbitalEccentricity
        { 
            get { return _orbitalEccentricity; }
            set { _orbitalEccentricity = value; }
         }
        public double OrbitalInclination
        { 
            get { return _orbitalInclination; }
            set { _orbitalInclination = value; }
         }
        public double ArgumentOfPeriapsis
        { 
            get { return _argumentOfPeriapsis; }
            set { _argumentOfPeriapsis = value; }
         }
        public double LongitudeOfTheAscendingNode
        { 
            get { return _longitudeOfTheAscendingNode; }
            set { _longitudeOfTheAscendingNode = value; }
         }
        public double MeanAndomaly
        { 
            get { return _meanAndomaly; }
            set { _meanAndomaly= value; }
         }
        public double OrbitalVelocity
        { 
            get { return _orbitalVelocity; }
            set { _orbitalVelocity= value; }
         }
        public double OrbitalPeriod
        { 
            get { return _orbitalPeriod; }
            set { _orbitalPeriod = value; }
         }
        #endregion

        #region "Phisical Characteristics"
        public double EquatorialRadius
        { 
            get { return _equatorialRadius; }
            set { _equatorialRadius = value; }
         }
        public double EquatorialCircumference
        { 
            get { return _equatorialCircumference; }
            set { _equatorialCircumference = value; }
         }
        public double SurfaceArea
        { 
            get { return _surfaceArea; }
            set { _surfaceArea = value; }
         }
        public double Mass
        { 
            get { return _mass; }
            set { _mass = value; }
         }
        public double StandarGravitonialParameter
        { 
            get { return _standarGravitonialParameter; }
            set { _standarGravitonialParameter = value; }
         }
        public double Density
        { 
            get { return _density; }
            set { _density = value; }
         }
        public double SurfaceGravity
        { 
            get { return _surfaceGravity; }
            set { _surfaceGravity = value; }
         }
        public double EscapeVelocity
        { 
            get { return _escapeVelocity; }
            set { _escapeVelocity = value; }
         }
        public double SiderealRotationPeriod
        { 
            get { return _siderealRotationPeriod; }
            set { _siderealRotationPeriod = value; }
         }
        public double SolarDay
        { 
            get { return _solarDay; }
            set { _solarDay = value; }
         }
        public double SiderealRotationVelocity
        { 
            get { return _siderealRotationVelocity; }
            set { _siderealRotationVelocity = value; }
         }
        public double SynchronousOrbit
        { 
            get { return _synchronousOrbit; }
            set { _synchronousOrbit = value; }
         }
        public double SphereOfInfluence
        { 
            get { return _sphereOfInfluence; }
            set { _sphereOfInfluence = value; }
         }
        #endregion

        #region "Atmospheric Characteristics"
        public bool AtmospherePresent
        { 
            get { return _atmospherePresent; }
            set { _atmospherePresent = value; }
         }
        public bool OxygenPresent
        { 
            get { return _oxygenPresent; }
            set { _oxygenPresent = value; }
         }
        public double AtmosphericPressure
        { 
            get { return _atmosphericPressure; }
            set { _atmosphericPressure = value; }
         }
        public double ScaleHeight
        { 
            get { return _scaleHeight; }
            set { _scaleHeight = value; }
         }
        public double AtmosphericHeight
        { 
            get { return _atmosphericHeight; }
            set { _atmosphericHeight = value; }
         }
        public double LowOrbitHeight
        { 
            get { return _lowOrbitHeight; }
            set { _lowOrbitHeight = value; }
         }
        public double TemperatureMin
        { 
            get { return _temperatureMin; }
            set { _temperatureMin = value; }
         }
        public double TemperatureMax
        { 
            get { return _temperatureMax; }
            set { _temperatureMax = value; }
         }
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

        /// <summary>
        /// Read Only Properties
        /// </summary>
        #region"ToString Properties
        
        public string strSemiMajorAxis { get { return string.Format("{0:n1}", _semiMajorAxis) + " m"; } }
        public string strApoapsis { get { return string.Format("{0:n1}", _apoapsis) + " m"; } }
        public string strPeriapsis { get { return string.Format("{0:n1}", _periapsis) + " m"; } }
        public string strOrbitalEccentricity { get { return string.Format("{0:n2}", OrbitalEccentricity); } }
        public string strOrbitalInclination { get { return string.Format("{0:n1}", _orbitalInclination) + " °"; } }
        public string strArgumentOfPeriapsis { get { return string.Format("{0:n1}", _argumentOfPeriapsis) + " °"; } }
        public string strLongitudeOfTheAscendingNode { get { return string.Format("{0:n1}", _longitudeOfTheAscendingNode) + " °"; } }
        public string strMeanAndomaly { get { return string.Format("{0:n1}", _meanAndomaly) + " rad"; } }
        public string strOrbitalPeriod { get { return string.Format("{0:n1}", _orbitalPeriod) + " s"; } }
        public string strOrbitalVelocity { get { return string.Format("{0:n1}", _orbitalVelocity) + " m/s"; } }
                      
        public string strEquatorialRadius { get { return string.Format("{0:n1}", _equatorialRadius) + " m"; } }
        public string strEquatorialCircumference { get { return string.Format("{0:n1}", _equatorialCircumference) + " m"; } }
        public string strSurfaceArea { get { return string.Format("{0:n1}", _surfaceArea) + " m²"; } }
        public string strMass { get { return string.Format("{0:n1}", _mass) + " kg"; } }
        public string strStandarGravitonialParameter { get { return string.Format("{0:n1}", _standarGravitonialParameter) + " m²/s²"; } }
        public string strDensity { get { return string.Format("{0:n1}", _density) + " kg/m³"; } }
        public string strSurfaceGravity { get { return string.Format("{0:n1}", _surfaceGravity) + " m/s²"; } }
        public string strEscapeVelocity { get { return string.Format("{0:n1}", _escapeVelocity) + " m/s"; } }
        public string strSiderealRotationPeriod { get { return string.Format("{0:n1}", _siderealRotationPeriod) + " s"; } }
        public string strSolarDay { get { return string.Format("{0:n1}", _solarDay) + " s"; } }
        public string strSiderealRotationVelocity { get { return string.Format("{0:n1}", _siderealRotationVelocity) + " m/s"; } }
        public string strSynchronousOrbit { get { return string.Format("{0:n1}", _synchronousOrbit) + " km"; } }
        public string strSphereOfInfluence { get { return string.Format("{0:n1}", _sphereOfInfluence) + " m"; } }
                      
        public string strAtmosphericPressure { get { return string.Format("{0:n1}", _atmosphericPressure) + " atm"; } }
        public string strScaleHeight { get { return string.Format("{0:n1}", _scaleHeight) + " m"; } }
        public string strAtmosphericHeight { get { return string.Format("{0:n1}", _atmosphericHeight) + " m"; } }
        public string strLowOrbitHeight { get { return string.Format("{0:n1}", _lowOrbitHeight) + " km"; } }
        public string strTemperatureMax { get { return string.Format("{0:n1}", _temperatureMax) + " °C"; } }
        public string strTemperatureMin { get { return string.Format("{0:n1}", _temperatureMin) + " °C"; } }
        public string strDeltaV { get { return " m/s"; } }

        #endregion

        #endregion

        #region "Private Methods"

        /// <summary>
        /// Initialize current object with default values.
        /// </summary>
        private void objInit()
        {
            this.Name = "None";
            this.Index = 0;
            this.ImageUri = @"pack://application:,,/Images/Planets/None.png";
            this.BiomeImageUri = @"pack://application:,,/Images/Biomes/None.png";
            this.Type = Types.Star;
            this.System = Systems.None;
            //"Orbital Characteristics"
            this._semiMajorAxis = 0;
            this._apoapsis = 0;
            this._periapsis = 0;
            this._orbitalEccentricity = 0;
            this._orbitalInclination = 0;
            this._argumentOfPeriapsis = 0;
            this._longitudeOfTheAscendingNode = 0;
            this._meanAndomaly = 0;
            this._orbitalVelocity = 0;
            this._orbitalPeriod = 0;
            //"Phisical Characteristics"
            this._equatorialRadius = 0;
            this._equatorialCircumference = 0;
            this._surfaceArea = 0;
            this._mass = 0;
            this._standarGravitonialParameter = 0;
            this._density = 0;
            this._surfaceGravity = 0;
            this._escapeVelocity = 0;
            this._siderealRotationPeriod = 0;
            this._solarDay = 0;
            this._siderealRotationVelocity = 0;
            this._synchronousOrbit = 0;
            this._sphereOfInfluence = 0;
            //"Atmospheric Characteristics"
            this._atmospherePresent = true;
            this._oxygenPresent = false;
            this._atmosphericPressure = 0;
            this._scaleHeight = 0;
            this._atmosphericHeight = 0;
            this._lowOrbitHeight = 0;
            this._temperatureMin = 0;
            this._temperatureMax = 0;
            //"Biome Characteristics"
            this.TotalBiomesCount = 0;
            this.SMSurface = 0;
            this.SMLowerAtmosphere = 0;
            this.SMUpperAtmosphere = 0;
            this.SMNearSpace = 0;
            this.SMOuterSpace = 0;
            //"Delta v Characteristics"
            this.SurfaceToLowOrbit = 0;
            this.LowOrbitToMoonIntercept = 0;
            this.MoonInterceptToElipticalOrbit = 0;
            this.MoonInterceptToElipticalOrbitMPC = 0;
            this.LowOrbitToElipticalOrbit = 0;
            this.ElipticalOrbitToPlanetIntercet = 0;
            this.PlanetInterceptToStarElipticalOrbit = 0;
            this.MaxPlaneChange = 0;
        }

        #endregion

        #region "Public Methods"

        /// <summary>
        /// Constractor
        /// </summary>
        public SelestialObject()
        {
            objInit();
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
        /// Calculates the phase angle for the Hohhman's Transer Orbit between the current celistial oject 
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
            HohmannTransferTime = Math.Pow( ( Math.Pow( objectTo.OrbitalPeriod , ( 2.0 / 3.0 ) ) + 
                                  Math.Pow( this.OrbitalPeriod, ( 2.0 / 3.0 ) ) ), 1.5 ) / 
                                  Math.Sqrt( 32.0 );
            Angle = 180 - ( 360 * ( HohmannTransferTime / objectTo.OrbitalPeriod ) );
            if (Angle < -180 && Angle >= -360) Angle += 360;
            else if (Angle < -360) Angle += Math.Abs( Math.Truncate( Angle / 360 ) * 360 );
            return Angle;
        }

        /// <summary>
        /// Returns a string format of the class properties in order to print them in the right panel of the calc
        /// </summary>
        /// <returns>Properties to string</returns>
        public string ToTextBox()
        {
            string objToTexbox = string.Empty;

            objToTexbox = "Celestial object : " + Name + "  |  Type : " + Type;
            objToTexbox += (Type == Types.Moon) ? "  |  Moon of : " + System : string.Empty;
            objToTexbox += Environment.NewLine;
            objToTexbox += "Surface Gravity : " + strSurfaceGravity + "  |  Low Orbit : " + strLowOrbitHeight;
            objToTexbox += Environment.NewLine;
            objToTexbox += "Escape Velocity : " + strEscapeVelocity + "  |  Sphere of influence : " + strSphereOfInfluence;
            objToTexbox += Environment.NewLine;
            objToTexbox += "Atmosphere : ";
            if (AtmospherePresent)
            {
                 objToTexbox += "🗸";
                 objToTexbox += "  |  Oxygen : ";
                 objToTexbox += (OxygenPresent) ? "🗸" : "■";
                 objToTexbox += "  |  Pressure : " + strAtmosphericPressure + "  |  Height : " + strAtmosphericHeight;
            }
            else objToTexbox += "■";
            objToTexbox += Environment.NewLine;
            objToTexbox += "Biomes : " + TotalBiomesCount + "  |  Scientific Multiplier: [ S : " + SMSurface + "  |  LA : " + SMLowerAtmosphere;
            objToTexbox += "  |  UA : " + SMUpperAtmosphere + "  |  NS : " + SMNearSpace + "  |  OS : " + SMOuterSpace + " ]";
            objToTexbox += Environment.NewLine;
            objToTexbox += "Surface to Low Orbit : " + string.Format("{0:n0}", SurfaceToLowOrbit) + strDeltaV;
            objToTexbox += "  |  Low Orbit to SOI Edge : ";
            objToTexbox += string.Format("{0:n0}", (LowOrbitToMoonIntercept + MoonInterceptToElipticalOrbit + ElipticalOrbitToPlanetIntercet +
                LowOrbitToElipticalOrbit + PlanetInterceptToStarElipticalOrbit)) + strDeltaV;

            return objToTexbox;
        }

        /// <summary>
        /// Overides the base ToString() method
        /// </summary>
        /// <returns>Returns a string with the properties of the class</returns>
        public override string ToString()
        {
            string strPropsToString = string.Empty;
            strPropsToString += Environment.NewLine;
            strPropsToString += "Name :  " + Name + Environment.NewLine;
            strPropsToString += "Type :  " + Type + Environment.NewLine;
            strPropsToString += "System :  " + System + Environment.NewLine;
            strPropsToString += Environment.NewLine;
            strPropsToString += "Orbital Characteristics :  " + Environment.NewLine;
            strPropsToString += "Semi Major Axis :  " + strSemiMajorAxis + Environment.NewLine;
            strPropsToString += "Apoapsis :  " + strApoapsis + Environment.NewLine;
            strPropsToString += "Periapsis :  " + strPeriapsis + Environment.NewLine;
            strPropsToString += "Orbital Eccentricity :  " + strOrbitalEccentricity + Environment.NewLine;
            strPropsToString += "Orbital Inclination :  " + strOrbitalInclination + Environment.NewLine;
            strPropsToString += "Argument Of Periapsis :  " + strArgumentOfPeriapsis + Environment.NewLine;
            strPropsToString += "Longitude Of The Ascending Node :  " + strLongitudeOfTheAscendingNode + Environment.NewLine;
            strPropsToString += "Mean Andomaly :  " + strMeanAndomaly + Environment.NewLine;
            strPropsToString += "Orbital Velocity :  " + strOrbitalVelocity + Environment.NewLine;
            strPropsToString += "Orbital Period :  " + strOrbitalPeriod + Environment.NewLine;
            strPropsToString += Environment.NewLine;
            strPropsToString += "Phisical Characteristics :  " + Environment.NewLine;
            strPropsToString += "Equatorial Radius :  " + strEquatorialRadius + Environment.NewLine;
            strPropsToString += "Equatorial Circumference :  " + strEquatorialCircumference + Environment.NewLine;
            strPropsToString += "SurfaceArea :  " + strSurfaceArea + Environment.NewLine;
            strPropsToString += "Mass :  " + strMass + Environment.NewLine;
            strPropsToString += "Standar Gravitonial Parameter :  " + strStandarGravitonialParameter + Environment.NewLine;
            strPropsToString += "Density :  " + strDensity + Environment.NewLine;
            strPropsToString += "Surface Gravity :  " + strSurfaceGravity + Environment.NewLine;
            strPropsToString += "Escape Velocity :  " + strEscapeVelocity + Environment.NewLine;
            strPropsToString += "Sidereal Rotation Period :  " + strSiderealRotationPeriod + Environment.NewLine;
            strPropsToString += "Solar Day :  " + strSolarDay + Environment.NewLine;
            strPropsToString += "Sidereal Rotation Velocity :  " + strSiderealRotationVelocity + Environment.NewLine;
            strPropsToString += "Synchronous Orbit :  " + strSynchronousOrbit + Environment.NewLine;
            strPropsToString += "Sphere Of Influence :  " + strSphereOfInfluence + Environment.NewLine;
            strPropsToString += "Atmospheric Characteristics :  " + Environment.NewLine;
            strPropsToString += "Atmosphere Present :  ";
            strPropsToString += (_atmospherePresent) ? "🗸" + Environment.NewLine : "■" + Environment.NewLine;
            strPropsToString += "Oxygen Present :  ";
            strPropsToString += (_oxygenPresent) ? "🗸" + Environment.NewLine : "■" + Environment.NewLine;
            strPropsToString += Environment.NewLine;
            strPropsToString += "Atmospheric Pressure :  " + strAtmosphericPressure + Environment.NewLine;
            strPropsToString += "Scale Height :  " + strScaleHeight + Environment.NewLine;
            strPropsToString += "Atmospheric Height :  " + strAtmosphericHeight + Environment.NewLine;
            strPropsToString += "Low Orbit Height :  " + strLowOrbitHeight + Environment.NewLine;
            strPropsToString += "Temperature Min :  " + strTemperatureMin + Environment.NewLine;
            strPropsToString += "Temperature Max :  " + strTemperatureMax + Environment.NewLine;
            strPropsToString += Environment.NewLine;
            strPropsToString += "Biome Characteristics :  " + Environment.NewLine;
            strPropsToString += "Biomes :  " + TotalBiomesCount + Environment.NewLine;
            strPropsToString += "SMSurface :  " + SMSurface + Environment.NewLine;
            strPropsToString += "SMLowerAtmosphere :  " + SMLowerAtmosphere + Environment.NewLine;
            strPropsToString += "SMUpperAtmosphere :  " + SMUpperAtmosphere + Environment.NewLine;
            strPropsToString += "SMNearSpace :  " + SMNearSpace + Environment.NewLine;
            strPropsToString += "SMOuterSpace :  " + SMOuterSpace + Environment.NewLine;
            strPropsToString += Environment.NewLine;
            strPropsToString += "Delta v Characteristics :  " + Environment.NewLine;
            strPropsToString += "SurfaceToLowOrbit :  " + SurfaceToLowOrbit + Environment.NewLine;
            strPropsToString += "LowOrbitToMoonIntercept :  " + LowOrbitToMoonIntercept + Environment.NewLine;
            strPropsToString += "MoonInterceptToElipticalOrbit :  " + MoonInterceptToElipticalOrbit + Environment.NewLine;
            strPropsToString += "MoonInterceptToElipticalOrbitMPC :  " + MoonInterceptToElipticalOrbitMPC + Environment.NewLine;
            strPropsToString += "LowOrbitToElipticalOrbit :  " + LowOrbitToElipticalOrbit + Environment.NewLine;
            strPropsToString += "ElipticalOrbitToPlanetIntercet :  " + ElipticalOrbitToPlanetIntercet + Environment.NewLine;
            strPropsToString += "PlanetInterceptToStarElipticalOrbit :  " + PlanetInterceptToStarElipticalOrbit + Environment.NewLine;
            strPropsToString += "MaxPlaneChange :  " + MaxPlaneChange + Environment.NewLine;
            strPropsToString += Environment.NewLine;
            return strPropsToString;
        }

        #endregion
    }
}
