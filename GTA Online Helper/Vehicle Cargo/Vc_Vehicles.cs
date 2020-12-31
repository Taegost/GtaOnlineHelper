using Microsoft.Extensions.FileProviders;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static System.Console;

namespace GTA_Online_Helper.Shared
{
    public class Vc_Vehicles
    {
        public List<Vc_Vehicle> Vehicles { get; set; } = new List<Vc_Vehicle>();

        public Vc_Vehicles()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Data_Files", "Vehicle_Cargo.json")))
                {
                    dynamic loadedVehicles = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    // If loadedvehicles is null, we need to throw an exception ***
                    foreach (var vehicle in loadedVehicles)
                    {
                        string name = vehicle.Name;
                        foreach (var sub in vehicle.Value)
                        {
                            string? collection = sub["collection"]?.ToString();
                            if (string.IsNullOrEmpty(collection)) { collection = ""; }
                            string plate = sub["plate"].ToString();
                            string range = sub["range"].ToString();

                            Vehicles.Add(new Vc_Vehicle(name, plate, range, collection));
                        } // foreach (var sub in vehicle.Value)
                    } // foreach (var vehicle in loadedVehicles)
                } // using
            }
            catch (Exception ex)
            {
                string msg = $"Unhandled exception occurred: \n{ex.Message}";
                ErrorHandling.WriteToLog(msg);
            }

        } // constructor

#region "Public Methods"

        public List<string> GetVehicleCollectionNames()
        {
            List<string> collectionList = new List<string>();
            foreach (var collection in GetVehicleCollections())
            {
                collectionList.Add(collection.Key);
            }
            return collectionList;
        } // method GetVehicleCollections()

        public Dictionary<string, List<Vc_Vehicle>> GetVehicleCollections()
        {
            Dictionary<string, List<Vc_Vehicle>> collections = new Dictionary<string, List<Vc_Vehicle>>();
            foreach (Vc_Vehicle vehicle in Vehicles)
            {
                if (!string.IsNullOrEmpty(vehicle.Collection))
                {
                if (!collections.ContainsKey(vehicle.Collection)) { collections.Add(vehicle.Collection, new List<Vc_Vehicle>()); }
                    collections[vehicle.Collection].Add(vehicle);
                }
            }
            return collections;
        } // method GetVehicleCollections()

        public List<Vc_Vehicle> GetVehiclesInCollection(string collection)
        {
            if (string.IsNullOrEmpty(collection)) { throw new ArgumentException("Collection name must contain a value"); }
            List<Vc_Vehicle> collectionList = new List<Vc_Vehicle>();
            if (GetVehicleCollections().TryGetValue(collection, out collectionList)) { return collectionList; }
            else
            { throw new ArgumentException($"Collection name not found: {collection}"); }
        } // method GetVehiclesInCollection

        public List<string> GetUniqueVehicleNames()
        {
            List<string> uniqueVehicleList = new List<string>();
            foreach (Vc_Vehicle vehicle in Vehicles)
            {
                if (!uniqueVehicleList.Contains(vehicle.Name)) { uniqueVehicleList.Add(vehicle.Name); }
            } // foreach (Vc_Vehicle vehicle in Vehicles)
            return uniqueVehicleList;
        } // method GetUniqueVehicleNames

        public List<string> GetPlatesForVehicle(string vehicleName)
        {
            List<string> plateList = new List<string>();
            foreach (Vc_Vehicle vehicle in Vehicles)
            { if (vehicle.Name == vehicleName) { plateList.Add(vehicle.Plate);  } }
            return plateList;
        } // method GetPlatesForVehicle

        public Vc_Vehicle GetVehicleByNameAndPlate(string name, string plate)
        {
            List<Vc_Vehicle> vehicles = GetVehiclesByName(name);
            foreach (Vc_Vehicle vehicle in vehicles) { if (vehicle.Plate == plate) return vehicle; }
            throw new ArgumentException($"No vehicle found with the following criteria: Vehicle Name: {name}  Vehicle Plate: {plate}");
        } // method GetVehicleByNameAndPlate

        public List<Vc_Vehicle> GetVehiclesByName(string name)
        {
            List<Vc_Vehicle> vehicleList = new List<Vc_Vehicle>();
            foreach (Vc_Vehicle vehicle in Vehicles) { if (vehicle.Name == name) { vehicleList.Add(vehicle); } }
            return vehicleList;
        } // method GetVehiclesByName

        public int GetNumberOfDriversByCollection(string collection)
        {
            return GetVehiclesInCollection(collection).Count();
        } // method GetNumberOfDriversByCollection

        public List<string> GetCompletedCollectionsFromList(List<Vc_Vehicle> vehicleList)
        {
            List<string> completeCollectionList = new List<string>();
            Dictionary<string, List<Vc_Vehicle>> fullCollectionList = GetVehicleCollections();
            Dictionary<string, List<Vc_Vehicle>> currentCollectionList = new Dictionary<string, List<Vc_Vehicle>>();
            foreach (Vc_Vehicle vehicle in vehicleList)
            {
                if (!string.IsNullOrWhiteSpace(vehicle.Collection) ) 
                {
                    if (!currentCollectionList.ContainsKey(vehicle.Collection)) { currentCollectionList.Add(vehicle.Collection, new List<Vc_Vehicle>()); }
                    currentCollectionList[vehicle.Collection].Add(vehicle);
                }
                
            }
            foreach (string key in currentCollectionList.Keys)
            {
                if ((currentCollectionList[key].Count == fullCollectionList[key].Count) && (!(completeCollectionList.Contains(key))))
                {
                    completeCollectionList.Add(key);
                }
            }
            return completeCollectionList;
        } // GetCompletedCollectionsFromList

        #endregion // "Public Methods"
    } // class Vc_Vehicles
} // namespace
