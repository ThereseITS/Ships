using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    internal class Vessel
    {
        // These static class values are shared by all class members- for convenience in this simple example.
    
        static readonly string[] locations = { "Pacific", "Atlantic", "Mediterranean", "Indian Ocean", "Other seas" };
        static readonly int[] costs = { 2610, 2350, 2050, 999, 2550, 2510 };
        static readonly string[] types = { "Aircraft carrier", "Cruiser/Battleship", "Destroyer", "Frigate", "Nuclear Submarine", "Minelayer/Sweeper" };

       // Details of each vessel
       
        string _name;
        int _type;
        int _tonnage;
        int _crew;
        int _locationCode;

        //Properties
        public string Name { get { return _name; } }
        public int Tonnage { get { return _tonnage;} }
        public int Crew { get { return _crew; } }
        public string Location { get {  return locations[_locationCode-1]; } }
        public string VesselType {  get {  return types[_type-1]; } }

        // Note the keyword static needs to be repeated here.
        public static string[] Locations { get { return locations; } }

        // constructor
        public Vessel(string name, int type, int tonnage, int crew, int locationCode)
        {
            _name = name;
            _type = type;
            _tonnage = tonnage;
            _crew = crew;
            _locationCode = locationCode;
        }
/// <summary>
/// Calulates the monthly running cost based on the number of crew 
/// and the cost per crew number from that particular ship. 
/// </summary>
/// <returns></returns>
        public decimal CalculateMonthlyRunningCost()
        {

            return (decimal) costs[_type - 1] * _crew;

        }
        public override string ToString()
        {
            return $"{_name} {types[_type-1]} {locations[_locationCode-1]}";
        }

    }
}
