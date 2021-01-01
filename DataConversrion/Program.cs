using System;
using System.Collections.Generic;
using System.Linq;
using GTA_Online_Helper.Shared;
using Microsoft.EntityFrameworkCore;
using WebFrontEnd.Data;
using WebFrontEnd.Models;

namespace DataConversrion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start with vehicles
            Vc_Vehicles vehicles = new Vc_Vehicles();

            using (var database = new ConversionDatabaseContext())
            {
                Console.WriteLine("Converting {0}", "VcCollectionTypes");
                foreach (string collection in vehicles.GetVehicleCollectionNames())
                {
                    database.VcCollectionTypes.Add(new VcCollectionType { Name = collection });
                    database.SaveChanges();
                } // VcCollectionTypes

                Console.WriteLine("Converting {0}", "VcRangeTypes"); 
                foreach (string range in new[] { "Standard", "Mid", "Top"} )
                {
                    database.VcRangeTypes.Add(new VcRangeType { Name = range }) ;
                    database.SaveChanges();
                } // VcRangeTypes

                Console.WriteLine("Converting {0}", "VcVehicles"); 
                foreach (string vehicle in vehicles.GetUniqueVehicleNames())
                {
                    database.VcVehicles.Add(new VcVehicle { Name = vehicle });
                    database.SaveChanges();
                } // VcVehicles

                Console.WriteLine("Converting {0}", "VcPlates"); 
                foreach (Vc_Vehicle vehicle in vehicles.Vehicles)
                {
                    VcPlate plateRow = new VcPlate
                    {
                        Name = vehicle.Plate,
                        Vehicle = database.VcVehicles.First(v => v.Name == vehicle.Name),
                        Range = database.VcRangeTypes.First(r => r.Name == vehicle.Range)
                    };
                    database.VcPlates.Add(plateRow);
                    database.SaveChanges();
                } // VcPlates

                Console.WriteLine("Converting {0}", "VcCollections"); 
                foreach (var collection in vehicles.GetVehicleCollections())
                {
                    string collectionName = collection.Key;
                    foreach (Vc_Vehicle vehicle in collection.Value)
                    {
                        VcCollection collectionRow = new VcCollection
                        {
                            Plate = database.VcPlates.First(p => p.Name == vehicle.Plate),
                            CollectionType = database.VcCollectionTypes.First(c => c.Name == collectionName)
                        };
                        database.VcCollections.Add(collectionRow);
                        database.SaveChanges();
                    }
                } // VcCollections
            }
        } // Main
    }
}
