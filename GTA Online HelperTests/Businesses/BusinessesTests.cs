using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTA_Online_Helper.Businesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTA_Online_Helper.Businesses.Tests
{
    [TestClass()]
    public class BusinessesTests
    {
        Businesses test = new Businesses();

        [TestMethod()]
        public void GetAllBusinessNamesTest()
        {
            string expectedResult = "Gunrunning Bunker Cocaine Lockup Methamphetamine Lab Counterfeit Cash Factory Weed Farm Document Forgery ";
            string actualResult = "";
            List<string> returnValue = test.GetAllBusinessNames();
            foreach (string business in returnValue) { actualResult += $"{business} "; }
            Assert.AreEqual(expectedResult, actualResult);
        } // test GetAllBusinessNamesTest
    }
}