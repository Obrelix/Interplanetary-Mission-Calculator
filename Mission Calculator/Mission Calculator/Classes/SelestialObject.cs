using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mission_Calculator.Enumerators;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;

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
        public double SemiMajorAxis{get { return _semiMajorAxis; } set { _semiMajorAxis = value; }}
        public double Apoapsis{ get { return _apoapsis; } set { _apoapsis = value; } }
        public double Periapsis{ get { return _periapsis; }set { _periapsis = value; }}
        public double OrbitalEccentricity{ get { return _orbitalEccentricity; } set { _orbitalEccentricity = value; } }
        public double OrbitalInclination{ get { return _orbitalInclination; } set { _orbitalInclination = value; } }
        public double ArgumentOfPeriapsis{ get { return _argumentOfPeriapsis; } set { _argumentOfPeriapsis = value; } }
        public double LongitudeOfTheAscendingNode{ get { return _longitudeOfTheAscendingNode; } set { _longitudeOfTheAscendingNode = value; } }
        public double MeanAndomaly{ get { return _meanAndomaly; } set { _meanAndomaly= value; } }
        public double OrbitalVelocity{ get { return _orbitalVelocity; } set { _orbitalVelocity= value; } }
        public double OrbitalPeriod{ get { return _orbitalPeriod; } set { _orbitalPeriod = value; } }
        #endregion

        #region "Phisical Characteristics"
        public double EquatorialRadius{ get { return _equatorialRadius; } set { _equatorialRadius = value; } }
        public double EquatorialCircumference{ get { return _equatorialCircumference; } set { _equatorialCircumference = value; } }
        public double SurfaceArea{ get { return _surfaceArea; } set { _surfaceArea = value; } }
        public double Mass{ get { return _mass; } set { _mass = value; } }
        public double StandarGravitonialParameter{ get { return _standarGravitonialParameter; } set { _standarGravitonialParameter = value; } }
        public double Density{ get { return _density; } set { _density = value; } }
        public double SurfaceGravity{ get { return _surfaceGravity; } set { _surfaceGravity = value; } }
        public double EscapeVelocity { get { return _escapeVelocity; } set { _escapeVelocity = value; } }
        public double SiderealRotationPeriod{get { return _siderealRotationPeriod; } set { _siderealRotationPeriod = value; } }
        public double SolarDay{ get { return _solarDay; } set { _solarDay = value; } }
        public double SiderealRotationVelocity { get { return _siderealRotationVelocity; } set { _siderealRotationVelocity = value; } }
        public double SynchronousOrbit{ get { return _synchronousOrbit; } set { _synchronousOrbit = value; } }
        public double SphereOfInfluence{ get { return _sphereOfInfluence; } set { _sphereOfInfluence = value; } }
        #endregion

        #region "Atmospheric Characteristics"
        public bool AtmospherePresent{ get { return _atmospherePresent; } set { _atmospherePresent = value; } }
        public bool OxygenPresent{ get { return _oxygenPresent; } set { _oxygenPresent = value; } }
        public double AtmosphericPressure{ get { return _atmosphericPressure; } set { _atmosphericPressure = value; } }
        public double ScaleHeight{ get { return _scaleHeight; } set { _scaleHeight = value; } }
        public double AtmosphericHeight{ get { return _atmosphericHeight; } set { _atmosphericHeight = value; } }
        public double LowOrbitHeight{ get { return _lowOrbitHeight; } set { _lowOrbitHeight = value; } }
        public double TemperatureMin{ get { return _temperatureMin; } set { _temperatureMin = value; } }
        public double TemperatureMax{ get { return _temperatureMax; } set { _temperatureMax = value; } }
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
        public string strOrbitalPeriod { get { return Globals.FormatTimeFromSecs(_orbitalPeriod); } }
        public string strOrbitalVelocity { get { return string.Format("{0:n1}", _orbitalVelocity) + " m/s"; } }
                      
        public string strEquatorialRadius { get { return string.Format("{0:n1}", _equatorialRadius) + " m"; } }
        public string strEquatorialCircumference { get { return string.Format("{0:n1}", _equatorialCircumference) + " m"; } }
        public string strSurfaceArea { get { return string.Format("{0:E3}", _surfaceArea) + " m²"; } }
        public string strMass { get { return string.Format("{0:E3}", _mass) + " kg"; } }
        public string strStandarGravitonialParameter { get { return string.Format("{0:E3}", _standarGravitonialParameter) + " m²/s²"; } }
        public string strDensity { get { return string.Format("{0:n1}", _density) + " kg/m³"; } }
        public string strSurfaceGravity { get { return string.Format("{0:n1}", _surfaceGravity) + " m/s²"; } }
        public string strEscapeVelocity { get { return string.Format("{0:n1}", _escapeVelocity) + " m/s"; } }
        public string strSiderealRotationPeriod { get { return Globals.FormatTimeFromSecs(_siderealRotationPeriod); } }
        public string strSolarDay { get { return Globals.FormatTimeFromSecs(_solarDay); } }
        public string strSiderealRotationVelocity { get { return string.Format("{0:n1}", _siderealRotationVelocity) + " m/s"; } }
        public string strSynchronousOrbit { get { return string.Format("{0:n1}", _synchronousOrbit) + " km"; } }
        public string strSphereOfInfluence { get { return string.Format("{0:n1}", _sphereOfInfluence/1000) + " km"; } }
                      
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

        /// <summary>
        /// Constractor
        /// </summary>
        public SelestialObject()
        {
            objInit();
        }

        #region "Public Methods"
        
        /// <summary>
        /// Returns a string format of the class properties in order to print them in the right panel of the calc
        /// </summary>
        /// <returns>Properties to string</returns>
        public List<Run> ToShortRunList(Brush nameBrush, Brush valueBrush)
        {
            try
            {
                List<Run> objPropsRunList = new List<Run>();
                objPropsRunList.Clear();

                objPropsRunList.Add(Globals.coloredRun("Celestial object : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(Name, valueBrush));
                objPropsRunList.Add(new Run("\t\t"));
                objPropsRunList.Add(Globals.coloredRun("Type       : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(Type.ToString(), valueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Surface Gravity  : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strSurfaceGravity, valueBrush));
                objPropsRunList.Add(new Run("\t\t"));
                objPropsRunList.Add(Globals.coloredRun("Mass       : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strMass, valueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Escape Velocity  : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strEscapeVelocity, valueBrush));
                if (strEscapeVelocity.Length > 9) objPropsRunList.Add(new Run("\t"));
                else objPropsRunList.Add(new Run("\t\t"));
                objPropsRunList.Add(Globals.coloredRun("S.O.I.     : ", nameBrush, "Sphere of influence"));
                objPropsRunList.Add(Globals.coloredRun(strSphereOfInfluence, valueBrush, "Sphere of influence"));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Rot. Velocity    : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strSiderealRotationVelocity, valueBrush));
                if (strSiderealRotationVelocity.Length > 9) objPropsRunList.Add(new Run("\t"));
                else objPropsRunList.Add(new Run("\t\t"));
                objPropsRunList.Add(Globals.coloredRun("Biomes     : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(TotalBiomesCount.ToString(), valueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Low Orbit        : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strLowOrbitHeight, valueBrush));
                if (strLowOrbitHeight.Length > 9) objPropsRunList.Add(new Run("\t"));
                else objPropsRunList.Add(new Run("\t\t"));
                objPropsRunList.Add(Globals.coloredRun("Syn. Orbit : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strSynchronousOrbit, valueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("To Low Orbit     : ", nameBrush, "Dv cost from object's surface to object's low orbit."));
                objPropsRunList.Add(Globals.coloredRun(string.Format("{0:n0}", SurfaceToLowOrbit) + strDeltaV, valueBrush, "Dv cost from planet's surface to low orbit."));
                objPropsRunList.Add(new Run("\t\t"));
                objPropsRunList.Add(Globals.coloredRun("To S.O.I.  : ", nameBrush, "Dv cost from object's surface to parent planet's Sphere of influence edge."));
                objPropsRunList.Add(Globals.coloredRun(string.Format("{0:n0}", (SurfaceToLowOrbit + LowOrbitToMoonIntercept +
                    MoonInterceptToElipticalOrbit + ElipticalOrbitToPlanetIntercet +
                    LowOrbitToElipticalOrbit + PlanetInterceptToStarElipticalOrbit)) +
                    strDeltaV, valueBrush, "Dv cost from low orbit to planet Sphere of influence edge."));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Atmosphere : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun((AtmospherePresent) ? "🗸 " : "■ ", valueBrush));
                objPropsRunList.Add(Globals.coloredRun("Oxygen : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun((OxygenPresent) ? "🗸 " : "■ ", valueBrush));
                objPropsRunList.Add(new Run("\t\t"));
                objPropsRunList.Add(Globals.coloredRun("Height     : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strAtmosphericHeight, valueBrush));
                objPropsRunList.Add(new Run(Environment.NewLine));
                objPropsRunList.Add(Globals.coloredRun("Tmin : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strTemperatureMin, valueBrush));
                objPropsRunList.Add(Globals.coloredRun(" Tmax : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strTemperatureMax, valueBrush));
                if (strTemperatureMax.Length > 6) objPropsRunList.Add(new Run("\t"));
                else objPropsRunList.Add(new Run("\t\t"));
                objPropsRunList.Add(Globals.coloredRun("Solar Day  : ", nameBrush));
                objPropsRunList.Add(Globals.coloredRun(strSolarDay, valueBrush));

                return objPropsRunList;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Returns a string format of the class properties in order to print them in the right panel of the calc
        /// </summary>
        /// <returns>Properties to string</returns>
        public string ToTextBox()
        {
            string objToTexbox = string.Empty;

            objToTexbox = "Celestial object :" + Name + "  |  Type : " + Type;
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
        /// Generates a new pop up window with class atrributes printed on it
        /// </summary>
        public void Show()
        {
            try
            {
                Window popUpWindow = new Window
                {
                    Title = this.Name + " Characteristics",
                    Width = 320,
                    MinWidth = 320,
                    MaxWidth = 320,
                    Height = 750
                };
                ScrollViewer viewer = new ScrollViewer
                {
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                TextBlock txt = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    FontFamily = new FontFamily("Consolas"),
                    FontSize = 12,
                    Background = Brushes.Black

                };
                txt.Inlines.Clear();
                foreach (Run objRun in this.ToLongRunList()) txt.Inlines.Add(objRun);
                viewer.Content = txt;
                popUpWindow.Content = viewer;
                popUpWindow.Show();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Run> ToLongRunList()
        {
            try
            {
                string strPropsToString = string.Empty;
                List<Run> objPropsRunList = new List<Run>();
                objPropsRunList.Clear();
                strPropsToString = String.Format("\r\n\t{0}\r\n", "General Characteristics");
                objPropsRunList.Add(new Run(strPropsToString)
                { Foreground = Brushes.Tomato, BaselineAlignment = BaselineAlignment.Superscript, FontWeight = FontWeights.Bold, });
                strPropsToString = String.Format("{0,21} {1}\n", "Name:", Name);
                strPropsToString += String.Format("{0,21} {1}\n", "Type:", Type);
                strPropsToString += String.Format("{0,21} {1}\n", "System:", System);
                objPropsRunList.Add(Globals.coloredRun(strPropsToString, Brushes.WhiteSmoke));
                strPropsToString = String.Format("\r\n\t{0}\r\n", "Orbital Characteristics");
                objPropsRunList.Add(new Run(strPropsToString)
                {Foreground = Brushes.Tomato,BaselineAlignment = BaselineAlignment.Superscript,FontWeight = FontWeights.Bold,});
                strPropsToString = String.Format("{0,21} {1}\n", "Semi Major Axis:", strSemiMajorAxis);
                strPropsToString += String.Format("{0,21} {1}\n", "Apoapsis:", strApoapsis);
                strPropsToString += String.Format("{0,21} {1}\n", "Periapsis:", strPeriapsis);
                strPropsToString += String.Format("{0,21} {1}\n", "Orbital Ecc.:", strOrbitalEccentricity);
                strPropsToString += String.Format("{0,21} {1}\n", "Orbital Inc.:", strOrbitalInclination);
                strPropsToString += String.Format("{0,21} {1}\n", "A.O.P:", strArgumentOfPeriapsis);
                strPropsToString += String.Format("{0,21} {1}\n", "L.O.T.A.N.:", strLongitudeOfTheAscendingNode);
                strPropsToString += String.Format("{0,21} {1}\n", "Mean Andomaly:", strMeanAndomaly);
                strPropsToString += String.Format("{0,21} {1}\n", "Orbital Velocity:", strOrbitalVelocity);
                strPropsToString += String.Format("{0,21} {1}\n", "Orbital Period:", strOrbitalPeriod);
                objPropsRunList.Add(Globals.coloredRun(strPropsToString, Brushes.WhiteSmoke));
                strPropsToString = String.Format("\r\n\t{0}\r\n", "Phisical Characteristics");
                objPropsRunList.Add(new Run(strPropsToString)
                { Foreground = Brushes.Tomato, BaselineAlignment = BaselineAlignment.Superscript, FontWeight = FontWeights.Bold, });
                strPropsToString = String.Format("{0,21} {1}\n", "Equatorial Radius:", strEquatorialRadius);
                strPropsToString += String.Format("{0,21} {1}\n", "Equatorial Cir/nce:", strEquatorialCircumference);
                strPropsToString += String.Format("{0,21} {1}\n", "SurfaceArea:", strSurfaceArea);
                strPropsToString += String.Format("{0,21} {1}\n", "Mass:", strMass);
                strPropsToString += String.Format("{0,21} {1}\n", "St. Grav. Parameter:", strStandarGravitonialParameter);
                strPropsToString += String.Format("{0,21} {1}\n", "Density:", strDensity);
                strPropsToString += String.Format("{0,21} {1}\n", "Surface Gravity:", strSurfaceGravity);
                strPropsToString += String.Format("{0,21} {1}\n", "Escape Velocity:", strEscapeVelocity);
                strPropsToString += String.Format("{0,21} {1}\n", "Sid. Rot. Period:", strSiderealRotationPeriod);
                strPropsToString += String.Format("{0,21} {1}\n", "Solar Day:", strSolarDay);
                strPropsToString += String.Format("{0,21} {1}\n", "Sid. Rot. Velocity:", strSiderealRotationVelocity);
                strPropsToString += String.Format("{0,21} {1}\n", "Synchronous Orbit:", strSynchronousOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "Sphere Of Influence:", strSphereOfInfluence);
                objPropsRunList.Add(Globals.coloredRun(strPropsToString, Brushes.WhiteSmoke));
                strPropsToString = String.Format("\r\n\t{0}\r\n", "Atmospheric Characteristics");
                objPropsRunList.Add(new Run(strPropsToString)
                { Foreground = Brushes.Tomato, BaselineAlignment = BaselineAlignment.Superscript, FontWeight = FontWeights.Bold, });
                strPropsToString = String.Format("{0,21} {1}\n", "Atmosphere Present:", (_atmospherePresent) ? "🗸" : "■");
                strPropsToString += String.Format("{0,21} {1}\n", "Oxygen Present:", (_oxygenPresent) ? "🗸" : "■");
                strPropsToString += String.Format("{0,21} {1}\n", "Atmospheric Pressure:", strAtmosphericPressure);
                strPropsToString += String.Format("{0,21} {1}\n", "Scale Height:", strScaleHeight);
                strPropsToString += String.Format("{0,21} {1}\n", "Atmospheric Height:", strAtmosphericHeight);
                strPropsToString += String.Format("{0,21} {1}\n", "Low Orbit Height:", strLowOrbitHeight);
                strPropsToString += String.Format("{0,21} {1}\n", "Temperature Min:", strTemperatureMin);
                strPropsToString += String.Format("{0,21} {1}\n", "Temperature Max:", strTemperatureMax);
                objPropsRunList.Add(Globals.coloredRun(strPropsToString, Brushes.WhiteSmoke));
                strPropsToString = String.Format("\r\n\t{0}\r\n", "Biome Characteristicss");
                objPropsRunList.Add(new Run(strPropsToString)
                { Foreground = Brushes.Tomato, BaselineAlignment = BaselineAlignment.Superscript, FontWeight = FontWeights.Bold, });
                strPropsToString = String.Format("{0,21} {1}\n", "Biomes:", TotalBiomesCount);
                strPropsToString += String.Format("{0,21} {1}\n", "SMSurface:", SMSurface);
                strPropsToString += String.Format("{0,21} {1}\n", "SMLowerAtmosphere:", SMLowerAtmosphere);
                strPropsToString += String.Format("{0,21} {1}\n", "SMUpperAtmosphere:", SMUpperAtmosphere);
                strPropsToString += String.Format("{0,21} {1}\n", "SMNearSpace:", SMNearSpace);
                strPropsToString += String.Format("{0,21} {1}\n", "SMOuterSpace:", SMOuterSpace);
                objPropsRunList.Add(Globals.coloredRun(strPropsToString, Brushes.WhiteSmoke));
                strPropsToString = String.Format("\r\n\t{0}\r\n", "Delta V Characteristics");
                objPropsRunList.Add(new Run(strPropsToString)
                { Foreground = Brushes.Tomato, BaselineAlignment = BaselineAlignment.Superscript, FontWeight = FontWeights.Bold, });
                strPropsToString = String.Format("{0,21} {1}\n", "Surface-->L.O.:", SurfaceToLowOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "L.O.-->M.I.:", LowOrbitToMoonIntercept);
                strPropsToString += String.Format("{0,21} {1}\n", "M.I.-->E.O.:", MoonInterceptToElipticalOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "M.I.-->E.O.MPC:", MoonInterceptToElipticalOrbitMPC);
                strPropsToString += String.Format("{0,21} {1}\n", "L.O.--?E.O.:", LowOrbitToElipticalOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "E.O.-->P.I.:", ElipticalOrbitToPlanetIntercet);
                strPropsToString += String.Format("{0,21} {1}\n", "P.I-->S.E.O.:", PlanetInterceptToStarElipticalOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "MaxPlaneChange:", MaxPlaneChange);
                objPropsRunList.Add(Globals.coloredRun(strPropsToString, Brushes.WhiteSmoke));
                return objPropsRunList;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Overides the base ToString() method
        /// </summary>
        /// <returns>Returns a string with the properties of the class</returns>
        public override string ToString()
        {
            try
            {
                string strPropsToString = string.Empty;
                strPropsToString += Environment.NewLine;
                strPropsToString += String.Format("{0,35}\n", "[ General Characteristics ]", "");
                strPropsToString += String.Format("{0,21} {1}\n", "Name:", Name);
                strPropsToString += String.Format("{0,21} {1}\n", "Type:", Type);
                strPropsToString += String.Format("{0,21} {1}\n", "System:", System);
                strPropsToString += Environment.NewLine;
                strPropsToString += String.Format("{0,35}\n", "[ Orbital Characteristics ]", "");
                strPropsToString += String.Format("{0,21} {1}\n", "Semi Major Axis:", strSemiMajorAxis);
                strPropsToString += String.Format("{0,21} {1}\n", "Apoapsis:", strApoapsis);
                strPropsToString += String.Format("{0,21} {1}\n", "Periapsis:", strPeriapsis);
                strPropsToString += String.Format("{0,21} {1}\n", "Orbital Ecc.:", strOrbitalEccentricity);
                strPropsToString += String.Format("{0,21} {1}\n", "Orbital Inc.:", strOrbitalInclination);
                strPropsToString += String.Format("{0,21} {1}\n", "A.O.P:", strArgumentOfPeriapsis);
                strPropsToString += String.Format("{0,21} {1}\n", "L.O.T.A.N.:", strLongitudeOfTheAscendingNode);
                strPropsToString += String.Format("{0,21} {1}\n", "Mean Andomaly:", strMeanAndomaly);
                strPropsToString += String.Format("{0,21} {1}\n", "Orbital Velocity:", strOrbitalVelocity);
                strPropsToString += String.Format("{0,21} {1}\n", "Orbital Period:", strOrbitalPeriod);
                strPropsToString += Environment.NewLine;
                strPropsToString += String.Format("{0,35}\n", "[ Phisical Characteristics ]", "");
                strPropsToString += String.Format("{0,21} {1}\n", "Equatorial Radius:", strEquatorialRadius);
                strPropsToString += String.Format("{0,21} {1}\n", "Equatorial Cir/nce:", strEquatorialCircumference);
                strPropsToString += String.Format("{0,21} {1}\n", "SurfaceArea:", strSurfaceArea);
                strPropsToString += String.Format("{0,21} {1}\n", "Mass:", strMass);
                strPropsToString += String.Format("{0,21} {1}\n", "St. Grav. Parameter:", strStandarGravitonialParameter);
                strPropsToString += String.Format("{0,21} {1}\n", "Density:", strDensity);
                strPropsToString += String.Format("{0,21} {1}\n", "Surface Gravity:", strSurfaceGravity);
                strPropsToString += String.Format("{0,21} {1}\n", "Escape Velocity:", strEscapeVelocity);
                strPropsToString += String.Format("{0,21} {1}\n", "Sid. Rot. Period:", strSiderealRotationPeriod);
                strPropsToString += String.Format("{0,21} {1}\n", "Solar Day:", strSolarDay);
                strPropsToString += String.Format("{0,21} {1}\n", "Sid. Rot. Velocity:", strSiderealRotationVelocity);
                strPropsToString += String.Format("{0,21} {1}\n", "Synchronous Orbit:", strSynchronousOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "Sphere Of Influence:", strSphereOfInfluence);
                strPropsToString += Environment.NewLine;
                strPropsToString += String.Format("{0,35}\n", "[ Atmospheric Characteristics ]", "");
                strPropsToString += String.Format("{0,21} {1}\n", "Atmosphere Present:", (_atmospherePresent) ? "🗸" : "■");
                strPropsToString += String.Format("{0,21} {1}\n", "Oxygen Present:", (_oxygenPresent) ? "🗸" : "■");
                strPropsToString += String.Format("{0,21} {1}\n", "Atmospheric Pressure:", strAtmosphericPressure);
                strPropsToString += String.Format("{0,21} {1}\n", "Scale Height:", strScaleHeight);
                strPropsToString += String.Format("{0,21} {1}\n", "Atmospheric Height:", strAtmosphericHeight);
                strPropsToString += String.Format("{0,21} {1}\n", "Low Orbit Height:", strLowOrbitHeight);
                strPropsToString += String.Format("{0,21} {1}\n", "Temperature Min:", strTemperatureMin);
                strPropsToString += String.Format("{0,21} {1}\n", "Temperature Max:", strTemperatureMax);
                strPropsToString += Environment.NewLine;
                strPropsToString += String.Format("{0,35}\n", "[ Biome Characteristics ]", "");
                strPropsToString += String.Format("{0,21} {1}\n", "Biomes:", TotalBiomesCount);
                strPropsToString += String.Format("{0,21} {1}\n", "SMSurface:", SMSurface);
                strPropsToString += String.Format("{0,21} {1}\n", "SMLowerAtmosphere:", SMLowerAtmosphere);
                strPropsToString += String.Format("{0,21} {1}\n", "SMUpperAtmosphere:", SMUpperAtmosphere);
                strPropsToString += String.Format("{0,21} {1}\n", "SMNearSpace:", SMNearSpace);
                strPropsToString += String.Format("{0,21} {1}\n", "SMOuterSpace:", SMOuterSpace);
                strPropsToString += Environment.NewLine;
                strPropsToString += String.Format("{0,35}\n", "[ Delta V Characteristics ]", "");
                strPropsToString += String.Format("{0,21} {1}\n", "Surface-->L.O.:", SurfaceToLowOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "L.O.-->M.I.:", LowOrbitToMoonIntercept);
                strPropsToString += String.Format("{0,21} {1}\n", "M.I.-->E.O.:", MoonInterceptToElipticalOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "M.I.-->E.O.MPC:", MoonInterceptToElipticalOrbitMPC);
                strPropsToString += String.Format("{0,21} {1}\n", "L.O.--?E.O.:", LowOrbitToElipticalOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "E.O.-->P.I.:", ElipticalOrbitToPlanetIntercet);
                strPropsToString += String.Format("{0,21} {1}\n", "P.I-->S.E.O.:", PlanetInterceptToStarElipticalOrbit);
                strPropsToString += String.Format("{0,21} {1}\n", "MaxPlaneChange:", MaxPlaneChange);
                return strPropsToString;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
