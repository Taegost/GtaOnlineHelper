using System;
using System.Collections.Generic;
using System.Text;

namespace GTA_Online_Helper.Businesses
{
    public class Business
    {
        public string Name { get; protected set; }
        public BusinessTypes BusinessType { get; protected set; }
        public int MaxCapacity { get; protected set; }
        public double BaseMinutesPerUnit { get; protected set; }
        public double CurrentMinutesPerUnit 
        { 
            get
            {
                double modifier = 0.0;
                foreach (BusinessUpgrade upgrade in Upgrades) { if (upgrade.Active) { modifier += upgrade.UnitPerMinuteIncrease; } }
                return BaseMinutesPerUnit - modifier;
            } // get
        } // CurrentMinutesPerUnit
        public int BaseUnitPrice { get; protected set; }
        public int CurrentUnitPrice 
        { 
            get
            {
                int modifier = 0;
                foreach (BusinessUpgrade upgrade in Upgrades) { if (upgrade.Active) { modifier += upgrade.UpgradePriceIncrease; } }
                int returnValue = BaseUnitPrice + modifier;
                return returnValue;
            } // get
        } // CurrentUnitPrice
        public int BaseDailyUpkeep { get; protected set; }
        public int CurrentDailyUpkeep 
        { 
            get
            {
                int modifier = 0;
                foreach (BusinessUpgrade upgrade in Upgrades) { if (upgrade.Active) { modifier += upgrade.DailyUpkeepCost; } }
                return BaseDailyUpkeep + modifier;
            } // get
        } // CurrentDailyUpkeep
        public List<BusinessUpgrade> Upgrades { get; protected set; }

        public Business(string name, BusinessTypes type, int maxCapacity, double baseMinutesPerUnit, int baseUnitPrice, int baseDailyUpkeep, List<BusinessUpgrade> upgrades)
        {
            Name = name;
            BusinessType = type;
            MaxCapacity = maxCapacity;
            BaseMinutesPerUnit = baseMinutesPerUnit;
            BaseUnitPrice = baseUnitPrice;
            BaseDailyUpkeep = baseDailyUpkeep;
            Upgrades = upgrades;
        } // constructor
    } // class Business
}
