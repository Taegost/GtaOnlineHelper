using GTA_Online_Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GTA_Online_Helper.Tests
{
    [TestClass()]
    public class Vc_VehiclesTests
    {
        Vc_Vehicles test = new Vc_Vehicles();
        string goodName = "Good Name";
        string goodPlate = "Good Plate";
        string goodCollection = "Good Collection";

        Vc_Vehicle testCarOne = new Vc_Vehicle("Car One", "Plate One", "Top");
        Vc_Vehicle testCarTwo = new Vc_Vehicle("Car Two", "Plate Two", "Top");
        Vc_Vehicle fadingPowerBlackFin = new Vc_Vehicle("Coquette BlackFin", "V1NT4G3", "Top", "Fading Power");
        Vc_Vehicle fadingPowerNightShade = new Vc_Vehicle("Nightshade", "TH37OS", "Top", "Fading Power");
        Vc_Vehicle uninsurableX80 = new Vc_Vehicle("X80 Proto", "M4K3B4NK", "Top", "Uninsurable");
        Vc_Vehicle uninsurableT20 = new Vc_Vehicle("T20", "D3V1L", "Top", "Uninsurable");
        Vc_Vehicle uninsurableOsiris = new Vc_Vehicle("Osiris", "SL33K", "Top", "Uninsurable");

        [TestMethod()]
        public void Pos_VehicleCount()
        {
            Assert.AreEqual(96, test.Vehicles.Count);
        } // Pos_HasName()

        [TestMethod()]
        public void GetVehicleCollectionNames()
        {
            string expectedResult = "No Direct Sunlight Molten Metal Shades of Blue Birds of Paradise Fading Power Pastel Perfection Hip to be Square Stay Declasse Uninsurable End of Empires";
            string result = "";
            foreach (string collection in test.GetVehicleCollectionNames()) { result += $"{collection} "; }
            Assert.AreEqual(expectedResult, result.Trim());
        } // GetVehicleCollectionNames

        [TestMethod()]
        public void GetVehicleCollectionsTest()
        {
            List<Vc_Vehicle> vehicleList = new List<Vc_Vehicle>();
            Dictionary<string, List<Vc_Vehicle>> generatedVehicleCollection = test.GetVehicleCollections();
            foreach (KeyValuePair<string, List<Vc_Vehicle>> kvp in generatedVehicleCollection)
            {
                foreach (Vc_Vehicle vehicle in kvp.Value) { vehicleList.Add(vehicle); }
            }
            Assert.AreEqual(10, generatedVehicleCollection.Count); // Total number of cargo collections
            Assert.AreEqual(32, vehicleList.Count); // Total number of cars in each collection
        } // GetVehicleCollectionsTest

        [TestMethod()]
        public void GetVehiclesInCollectionTest()
        {
            string fakeCollection = "fakecollection";
            string expectedResult = $"Collection name not found: {fakeCollection}";
            Assert.AreEqual(3, test.GetVehiclesInCollection("Uninsurable").Count);
            Assert.AreEqual(2, test.GetVehiclesInCollection("End of Empires").Count);
            try
            {
                test.GetVehiclesInCollection(fakeCollection);
                Assert.Fail("This test should have thrown an exception but did not");
            }
            catch (ArgumentException ex)
            {
                if (ex.Message == expectedResult) { Assert.AreEqual(true, true); }
                else
                { Assert.Fail($"The result didn't match\nExpected: {expectedResult}\nReceived: {ex.Message}"); }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected to get an ArgumentException, instead got the following:\n{ex.ToString()}");
            }
        } // GetVehiclesInCollectionTest

        [TestMethod()]
        public void GetUniqueVehicleNamesTest()
        {
            string expectedResult = "811 Alpha Banshee 900R Bestia GTS Cheetah Coquette BlackFin Coquette Classic Entity XF ETR1 Feltzer FMJ Jester Mamba Massacro Nightshade Omnis Osiris Reaper Roosevelt Valor Sabre Turbo Custom Seven-70 Stirling GT Sultan RS T20 Tampa Tropos Rallye Turismo R Tyrus Verlierer X80 Proto Zentorno Z-Type ";
            string actualResult = "";
            foreach (string vehicle in test.GetUniqueVehicleNames()) { actualResult += $"{vehicle} "; }
            Assert.AreEqual(expectedResult, actualResult);
        } // method GetUniqueVehicleNamesTest

        [TestMethod()]
        public void GetPlatesForVehicleTest()
        {
            string expectedResult = "SL1CK M1DLIFE R3G4L ";
            string actualResult = "";
            foreach (string plate in test.GetPlatesForVehicle("811")) { actualResult += $"{plate} "; }
            Assert.AreEqual(expectedResult, actualResult);
        } // test GetPlatesForVehicleTest

        [TestMethod()]
        public void GetVehiclesByNameTest()
        {
            string expectedResult = "SL1CK M1DLIFE R3G4L ";
            string actualResult = "";
            List<Vc_Vehicle> vehicles = test.GetVehiclesByName("811");
            foreach (Vc_Vehicle vehicle in vehicles) { actualResult += $"{vehicle.Plate} "; }
            Assert.AreEqual(expectedResult, actualResult);
        } // test GetVehiclesByNameTest

        [TestMethod()]
        public void POS_GetVehicleByNameAndPlateTest()
        {
            string expectedResult = "811 M1DLIFE";
            string actualResult = "";
            Vc_Vehicle vehicle = test.GetVehicleByNameAndPlate("811", "M1DLIFE");
            actualResult = $"{vehicle.Name} {vehicle.Plate}";
            Assert.AreEqual(expectedResult, actualResult);
        } // test GetVehicleByNameAndPlateTest

        public void NEG_GetVehicleByNameAndPlateTest()
        {
            try { var vehicle = test.GetVehicleByNameAndPlate("badname", "badplate"); }
            catch (ArgumentException ex) { Assert.AreEqual(true, true); }
            catch (Exception ex) { Assert.Fail($"Expected ArgumentException, instead received the following: \n{ex.Message}"); }
            Assert.Fail("Expected an ArgumentException, but no exception was thrown");
        } // test NEG_GetVehicleByNameAndPlateTest

        [TestMethod()]
        public void GetCompletedCollectionsFromListTest()
        {
            List<string> emptyCollectionList = new List<string>();
            List<string> oneCollectionList = new List<string>();
            List<string> twoCollectionList = new List<string>();

            List<string> emptyStringList = new List<string>();
            string expectedResultOneCollection = "Fading Power";
            string expectedResultTwoCollection = "Fading Power Uninsurable";

            List<Vc_Vehicle> vehicleList = new List<Vc_Vehicle>();

            // Test with a totally empty vehicle list
            emptyCollectionList = test.GetCompletedCollectionsFromList(vehicleList);
            CollectionAssert.AreEqual(emptyStringList, emptyCollectionList);

            // Test with vehicle list that has no vehicles in a collection
            vehicleList.Add(testCarOne);
            vehicleList.Add(testCarTwo);
            emptyCollectionList = test.GetCompletedCollectionsFromList(vehicleList);
            CollectionAssert.AreEqual(emptyStringList, emptyCollectionList);

            // Test with vehicle list that includes cars in different collections
            vehicleList.Add(fadingPowerBlackFin);
            vehicleList.Add(uninsurableX80);
            emptyCollectionList = test.GetCompletedCollectionsFromList(vehicleList);
            CollectionAssert.AreEqual(emptyStringList, emptyCollectionList);

            // Test with vehicle list that includes cars from 1 collection
            vehicleList.Add(fadingPowerNightShade);
            oneCollectionList = test.GetCompletedCollectionsFromList(vehicleList);
            Assert.AreEqual(1, oneCollectionList.Count);
            Assert.AreEqual(expectedResultOneCollection, oneCollectionList[0]);

            // Test with vehicle list that includes cars from 2 collections
            vehicleList.Add(uninsurableT20);
            vehicleList.Add(uninsurableOsiris);
            twoCollectionList = test.GetCompletedCollectionsFromList(vehicleList);
            Assert.AreEqual(2, twoCollectionList.Count);
            Assert.AreEqual(expectedResultTwoCollection, $"{twoCollectionList[0]} {twoCollectionList[1]}");
        }
    } // class Vc_VehiclesTests
} // namespace