using System;
using System.Collections.Generic;
using System.Text;

namespace GTA_Online_Helper.Shared
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

        public int GetTwoVehicleLocalThresholdValue()
        {
            return (int)((double)MaxCapacity / 4 + 1) * CurrentUnitPrice;
        } // method GetTwoVehicleLocalThresholdValue

        public int GetThreeVehicleLocalThresholdValue()
        {
            return (int)((double)MaxCapacity / 4 * 2 + 1) * CurrentUnitPrice;
        } // method GetThreeVehicleLocalThresholdValue

        public int GetFourVehicleLocalThresholdValue()
        {
            return (int)((double)MaxCapacity / 4 * 3 + 1) * CurrentUnitPrice;
        } // method GetFourVehicleLocalThresholdValue

        public int GetLosSantosSellPrice(int price)
        {
            return (int)((double)price * 1.5);
        } // GetLosSantosSellPrice

        public int GetTwoVehicleLosSantosThresholdValue()
        {
            return GetLosSantosSellPrice((int)((double)MaxCapacity / 4 + 1) * CurrentUnitPrice);
        } // method GetTwoVehicleLosSantosThresholdValue

        public int GetThreeVehicleLosSantosThresholdValue()
        {
            return GetLosSantosSellPrice((int)((double)MaxCapacity / 4 * 2 + 1) * CurrentUnitPrice);
        } // method GetThreeVehicleLosSantosThresholdValue

        public int GetFourVehicleLosSantosThresholdValue()
        {
            return GetLosSantosSellPrice((int)((double)MaxCapacity / 4 * 3 + 1) * CurrentUnitPrice);
        } // method GetFourVehicleLosSantosThresholdValue
    } // class Business
}
