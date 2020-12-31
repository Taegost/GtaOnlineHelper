using System;
using System.Collections.Generic;
using System.Text;

namespace GTA_Online_Helper.Shared
{
    public class BusinessUpgrade
    {
        public string Name { get; private set; }
        public int DailyUpkeepCost { get; private set; }
        public double UnitPerMinuteIncrease { get; private set; }
        public int UpgradePriceIncrease { get; private set; }
        public bool Active { get; set; } = false;

        public BusinessUpgrade(string name, int dailyUpkeepCost, int upgradePriceIncrease, double unitPerMinuteIncrease)
        {
            Name = name;
            DailyUpkeepCost = dailyUpkeepCost;
            UpgradePriceIncrease = upgradePriceIncrease;
            UnitPerMinuteIncrease = unitPerMinuteIncrease;
        } // constructor
    } // class BusinessUpgrade
}
