using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GTA_Online_Helper.Tests
{
    [TestClass()]
    public class Vc_VehicleTests
    {
        string goodName = "Good Name";
        string goodPlate = "Good Plate";
        string goodRange = "Good Range";
        string goodCollection = "Good Collection";
        [TestMethod()]
        public void Positive_Tests()
        {
            var test = new Vc_Vehicle(goodName, goodPlate, goodCollection);
            Assert.AreEqual(goodName, test.Name);
            Assert.AreEqual(goodPlate, test.Plate);
            Assert.AreEqual(true, test.InCollection());
            Assert.AreEqual(goodCollection, test.Collection);
        } // Pos_HasName()

        [TestMethod()]
        public void Neg_NoName()
        {
            try 
            { 
                var test = new Vc_Vehicle("", goodPlate, goodCollection);
                Assert.Fail("Expected the blank name to throw an exception, but it did not");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Name must have a value", ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected the blank name to throw an Argument exception and it threw the following exception: {nameof(ex)}\n{ex.Message}");
            }
        } // Neg_NoName()

        [TestMethod()]
        public void Neg_NullName()
        {
            try
            {
                var test = new Vc_Vehicle(null, goodPlate, goodCollection);
                Assert.Fail("Expected the blank name to throw an exception, but it did not");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Name must have a value", ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected the blank name to throw an Argument exception and it threw the following exception: {nameof(ex)}\n{ex.Message}");
            }
        } // Neg_NullName()

        [TestMethod()]
        public void Neg_NoPlate()
        {
            try
            {
                var test = new Vc_Vehicle(goodName, "", goodRange, goodCollection);
                Assert.Fail("Expected the blank plate to throw an exception, but it did not");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Plate must have a value", ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected the plate name to throw an Argument exception and it threw the following exception: {nameof(ex)}\n{ex.Message}");
            }
        } // Neg_NoPlate()

        [TestMethod()]
        public void Neg_NullPlate()
        {
            try
            {
                var test = new Vc_Vehicle(goodName, null, goodRange, goodCollection);
                Assert.Fail("Expected the blank plate to throw an exception, but it did not");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Plate must have a value", ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected the blank plate to throw an Argument exception and it threw the following exception: {nameof(ex)}\n{ex.Message}");
            }
        } // Neg_NullPlate()

        [TestMethod()]
        public void Pos_CollectionTest()
        {
            var test = new Vc_Vehicle(goodName, goodPlate, goodRange, goodCollection);
            Assert.AreEqual(true, test.InCollection());
            Assert.AreEqual(goodCollection, test.Collection);
        } // Pos_CollectionTest

        [TestMethod()]
        public void Neg_CollectionTest()
        {
            var test = new Vc_Vehicle(goodName, goodPlate, goodRange);
            Assert.AreEqual(false, test.InCollection());
            Assert.AreEqual("", test.Collection);
            var test2 = new Vc_Vehicle(goodName, goodPlate, goodRange, null);
            Assert.AreEqual(false, test.InCollection());
            Assert.AreEqual("", test.Collection);
        } // Neg_CollectionTest
    } // class
} // namespace