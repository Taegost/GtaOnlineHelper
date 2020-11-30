using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GTA_Online_Helper.Businesses
{
    public class Businesses
    {
        public List<Business> FullBusinessList { get; set; } = new List<Business>();

        public Businesses()
        {
            LoadBusinesses();
        } // constructor

        private void LoadBusinesses()
        {
            using (StreamReader reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Data_Files", "Business_Data.json")))
            {
                dynamic loadedBusinesses = JsonConvert.DeserializeObject(reader.ReadToEnd());
                // If loadedvehicles is null, we need to throw an exception ***
                foreach (var business in loadedBusinesses)
                {
                    string name = business.Name;

                    List<BusinessUpgrade> upgrades = new List<BusinessUpgrade>();

                    BusinessTypes type = business.Value["businessType"];
                    int maxCapacity = business.Value["maxCapacity"];
                    int baseMinutesPerUnit = business.Value["baseMinutesPerUnit"];
                    int baseUnitPrice = business.Value["baseUnitPrice"];
                    int baseDailyUpkeep = business.Value["baseDailyUpkeep"];

                    foreach (var upgrade in business.Value["upgrades"])
                    {
                        string upgradeName = upgrade["name"];
                        int dailyUpkeepCost = upgrade["dailyUpkeepCost"];
                        int upgradePriceIncrease = upgrade["upgradePriceIncrease"];
                        double unitPerMinuteIncrease = upgrade["unitPerMinuteIncrease"];
                        upgrades.Add(new BusinessUpgrade(upgradeName, dailyUpkeepCost, upgradePriceIncrease, unitPerMinuteIncrease));
                    } // foreach (var upgrade in sub["upgrades"])
                    FullBusinessList.Add(new Business(name, type, maxCapacity, baseMinutesPerUnit, baseUnitPrice, baseDailyUpkeep, upgrades));
                } // foreach (var business in loadedBusinesses)
            } // using
        } // method LoadBusinesses

        public List<string> GetAllBusinessNames()
        {
            List<string> returnValue = new List<string>();
            foreach (Business business in FullBusinessList)
            {
                returnValue.Add(business.Name);
            }
            return returnValue;
        } // method GetAllBusinessNames
    } // class Businesses
}
