using CoursCSharpObjetPartie1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursTestUnitaire
{
    [TestClass]
    public class CalculatriceTest
    {
        [TestMethod]
        public void AdditionTest()
        {
            //Arrange
            Calculatrice c = new Calculatrice();

            //Act
            double result = c.Addition(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void SoustractionTest()
        {
            //Arrange
            Calculatrice c = new Calculatrice();

            //Act
            double result = c.Soustraction(10, 20);

            //Assert
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        public void CalculeTest()
        {
            //Assert
            Assert.ThrowsException<Exception>(ActCalcule);
        }

        private void ActCalcule()
        {
            Calculatrice c = new Calculatrice();
            c.Calcule(10, 20, c.Addition);
        }
    }
}
