using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission_Calculator.Enumerators
{

    public class GameConstants
    {
        public const int StockPlanetsCount = 18;
        public const int OuterPlanetsCount = 32;
        public const int RssPlanetsCount = 17;
        public const int KerbinTime = 21600; //seconds per day
        public const int EarthTime = 86400; //seconds per day

    }

    public enum OrbitHeight : Int16
    {
        Surface = 0,
        LowOrbit = 1,
        GeostationaryOrbit = 2,
        EscapeOrbit = 3
    }

    public enum Types : Int16 
    {
        Star = 0,
        Planet = 1,
        Moon = 2,
        Gasgiant = 3,
        UFO = 4
    }

    public enum Systems : Int16
    {
        Kerbol = 0,
        Moho = 1,
        Eve = 2,
        Kerbin = 3,
        Duna = 4,
        Dres = 5,
        Jool = 6,
        Eeloo = 7,
        Sarnus = 8,
        Urlum = 8,
        Neidon = 9,
        Plock = 10,
        Earth = 11,
        Mercury = 12,
        Venus = 13,
        Mars = 14,
        Jupiter = 15,
        Saturn = 16,
        Uranus = 17,
        Neptune = 18,
        None = 19
    }

    public enum Orbits : Int16
    {
        Sun = 0,
        Kerbol = 1,
        Eve = 2,
        Kerbin = 3,
        Duna = 4,
        Jool = 5,
        Sarnus = 6,
        Urlum = 7,
        Neidon = 8,
        Plock = 9,
        Earth = 10,
        Mercury = 11,
        Venus = 12,
        Mars = 13,
        Jupiter = 14,
        Saturn = 15,
        Uranus = 16,
        Neptune = 17,
        None = 18
    }
    
}
