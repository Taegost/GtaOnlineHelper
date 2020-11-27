using Newtonsoft.Json;
using System;

/// <summary>
/// Describes a Vehicle Cargo vehicle
/// </summary>
namespace GTA_Online_Helper
{
    public class Vc_Vehicle
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name must have a value");
                }
                else
                { _Name = value; }
            } // set
        } // public string Name
        
        private string _Plate;
        public string Plate 
        { 
            get { return _Plate; } 
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Plate must have a value");
                }
                else
                { _Plate = value; }
            } // set
        } // public string Plate { get; private set; }
        public string Collection { get; private set; }
        public string Range { get; private set; }

        [JsonConstructor]
        public Vc_Vehicle(string name, string plate, string range, string collection)
        {
            Name = name;
            Plate = plate;
            Range = range;
            Collection = collection;
        } // 3 input constructor

        public Vc_Vehicle(string inName, string inPlate, string range) : this(inName, inPlate, range, "")
        {
        } // 3 input constructor

        public bool InCollection()
        {
            return !(string.IsNullOrEmpty(Collection));
        }

        public string GetNameAndPlate()
        {
            return $"{Name} - {Plate}";
        }
    } // class Vc_Vehicle
} // namespace GTA_Online_Helper
