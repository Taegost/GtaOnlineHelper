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
    } // class BusinessTests
}