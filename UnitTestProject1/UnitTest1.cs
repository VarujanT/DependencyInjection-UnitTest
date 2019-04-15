using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjection.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscount GetObject()
        {
            return new MinDiscount();
        }

        [TestMethod]
        public void Above_100()
        {
            //Arrange
            IDiscount target = GetObject();
            decimal result_200 = 100;
            decimal result_500 = 250;

            //Act
            decimal result1 = target.ApplyDiscount(200);
            decimal result2 = target.ApplyDiscount(500);

            //Assert
            Assert.AreEqual(result_200, result1, "ERROR VALUE 200");
            Assert.AreEqual(result_500, result2, "ERROR VALUE 500");
        }

        [TestMethod]
        public void Between100_10()
        {
            //Arrange
            IDiscount target = GetObject();
            decimal result_100 = 95;
            decimal result_10 = 5;
            decimal result_50 = 45;

            //Act
            decimal result1 = target.ApplyDiscount(100);
            decimal result2 = target.ApplyDiscount(10);
            decimal result3 = target.ApplyDiscount(50);

            //Assert
            Assert.AreEqual(result_100, result1, "ERROR VALUE 100");
            Assert.AreEqual(result_10, result2, "ERROR VALUE 10");
            Assert.AreEqual(result_50, result3, "ERROR VALUE 50");
        }

        [TestMethod]
        public void Less_10()
        {
            //Arrange
            IDiscount target = GetObject();


            //Act


            //Assert
            Assert.AreEqual(5, target.ApplyDiscount(5), "ERROR VALUE 100");
            Assert.AreEqual(0, target.ApplyDiscount(0), "ERROR VALUE 10");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeVal()
        {
            IDiscount target = GetObject();
            target.ApplyDiscount(-10);
        }
    }
}