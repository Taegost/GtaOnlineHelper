using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTA_Online_Helper.Businesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTA_Online_Helper.Businesses.Tests
{
    [TestClass()]
    public class BusinessTests
    {
        Businesses fullBusinessList = new Businesses();

        #region Current Unit Price testing
        [TestMethod()]
        public void CurrentUnitPriceNoModifiers()
        {
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            Assert.AreEqual(testBusiness.BaseUnitPrice, testBusiness.CurrentUnitPrice);
        } // test CurrentUnitPriceNoModifiers

        [TestMethod()]
        public void CurrentUnitPriceOneModifier()
        {
            int expectedResult = 6000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.CurrentUnitPrice);
        } // CurrentUnitPriceOneModifier

        [TestMethod()]
        public void CurrentUnitPriceTwoModifiers()
        {
            int expectedResult = 7000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.CurrentUnitPrice);
        } // CurrentUnitPriceTwoModifiers

        [TestMethod()]
        public void CurrentUnitPriceThreeModifiers()
        {
            int expectedResult = 7000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            testBusiness.Upgrades[2].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.CurrentUnitPrice);
        } // CurrentUnitPriceTwoModifiers
        #endregion // Current Unit Price testing

        #region Current Minutes Per Unit Testing
        [TestMethod()]
        public void CurrentMinutesPerUnitNoModifiers()
        {
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            Assert.AreEqual(testBusiness.BaseMinutesPerUnit, testBusiness.CurrentMinutesPerUnit);
        } // test CurrentUnitPriceNoModifiers

        [TestMethod()]
        public void CurrentMinutesPerUnitOneModifier()
        {
            double expectedResult = 8.5;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.CurrentMinutesPerUnit);
        } // CurrentUnitPriceOneModifier

        [TestMethod()]
        public void CurrentMinutesPerUnitTwoModifiers()
        {
            double expectedResult = 7;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.CurrentMinutesPerUnit);
        } // CurrentUnitPriceTwoModifiers

        [TestMethod()]
        public void CurrentMinutesPerUnitThreeModifiers()
        {
            double expectedResult = 7;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            testBusiness.Upgrades[2].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.CurrentMinutesPerUnit);
        } // CurrentUnitPriceTwoModifiers
        #endregion // Current Minutes Per Unit Testing

        #region Current Daily Upkeep Testing
        [TestMethod()]
        public void CurrentDailyUpkeepNoModifiers()
        {
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            Assert.AreEqual(testBusiness.BaseDailyUpkeep, testBusiness.CurrentDailyUpkeep);
        } // test CurrentDailyUpkeepNoModifiers

        [TestMethod()]
        public void CurrentDailyUpkeepOneModifier()
        {
            int expectedResult = 6300;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.CurrentDailyUpkeep);
        } // CurrentDailyUpkeepOneModifier

        [TestMethod()]
        public void CurrentDailyUpkeepTwoModifiers()
        {
            int expectedResult = 8625;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.CurrentDailyUpkeep);
        } // CurrentDailyUpkeepTwoModifiers

        [TestMethod()]
        public void CurrentDailyUpkeepThreeModifiers()
        {
            int expectedResult = 9400;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            testBusiness.Upgrades[2].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.CurrentDailyUpkeep);
        } // CurrentDailyUpkeepThreeModifiers
        #endregion // Current Daily Upkeep Testing

        #region Vehicle Thresholds
        [TestMethod()]
        public void TwoVehicleThresholdValueTestNoModifier()
        {
            double expectedResult = 130000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            Assert.AreEqual(expectedResult, testBusiness.GetTwoVehicleLocalThresholdValue());
        } // test TwoVehicleThresholdValueTestNoModifier

        [TestMethod()]
        public void TwoVehicleThresholdValueTestOneModifier()
        {
            double expectedResult = 156000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.GetTwoVehicleLocalThresholdValue());
        } // test TwoVehicleThresholdValueTestNoModifier

        [TestMethod()]
        public void TwoVehicleThresholdValueTestTwoModifier()
        {
            double expectedResult = 182000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.GetTwoVehicleLocalThresholdValue());
        } // test TwoVehicleThresholdValueTestNoModifier

        [TestMethod()]
        public void TwoVehicleThresholdValueTestThreeModifier()
        {
            double expectedResult = 182000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            testBusiness.Upgrades[2].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.GetTwoVehicleLocalThresholdValue());
        } // test TwoVehicleThresholdValueTestNoModifier

        public void ThreeVehicleThresholdValueTestNoModifier()
        {
            double expectedResult = 255000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            Assert.AreEqual(expectedResult, testBusiness.GetThreeVehicleLocalThresholdValue());
        } // test ThreeVehicleThresholdValueTestNoModifier

        public void ThreeVehicleThresholdValueTestThreeModifier()
        {
            double expectedResult = 357000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            testBusiness.Upgrades[2].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.GetThreeVehicleLocalThresholdValue());
        } // test ThreeVehicleThresholdValueTestThreeModifier

        public void FourVehicleThresholdValueTestNoModifier()
        {
            double expectedResult = 255000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            Assert.AreEqual(expectedResult, testBusiness.GetFourVehicleLocalThresholdValue());
        } // test FourVehicleThresholdValueTestNoModifier

        public void FourVehicleThresholdValueTestThreeModifier()
        {
            double expectedResult = 357000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;
            testBusiness.Upgrades[2].Active = true;
            Assert.AreEqual(expectedResult, testBusiness.GetFourVehicleLocalThresholdValue());
        } // test FourVehicleThresholdValueTestThreeModifier
        #endregion // Vehicle Thresholds

        [TestMethod()]
        public void GetLosSantosSellPriceTest()
        {
            double expectedResult = 273000;
            Business testBusiness = fullBusinessList.FullBusinessList[0];
            testBusiness.Upgrades[0].Active = true;
            testBusiness.Upgrades[1].Active = true;

            Assert.AreEqual(expectedResult, testBusiness.GetLosSantosSellPrice(testBusiness.GetTwoVehicleLocalThresholdValue()));
        }
    } // class BusinessTests
}