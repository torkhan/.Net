using CoursCSharpObjetPartie1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cours_TestUnitaire
{
    [TestClass]
    public class CalculatriceTest
    {
        [TestMethod]
        public void SoustractionTest()
        {
            //Arrange
            Calculatrice c = new Calculatrice();

            //Act
            double resultat = c.Soustraction(30, 10);

            //Assert
            Assert.AreEqual(20, resultat);
        }
        [TestMethod]
        public void AdditionTest()
        {
            //Arrange
            Calculatrice c = new Calculatrice();

            //Act
            double resultat = c.Addition(30, 10);

            //Assert
            Assert.AreEqual(40, resultat);
        }

    }
}
