using CoursCSharpObjetPartie1.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursTestUnitaire
{
    [TestClass]
    public class JeuPenduTest
    {
        private IGenerateur g = Mock.Of<IGenerateur>();

        [TestMethod]
        public void GenererMasqueTest()
        {
            //Arrange
            //FakeGenerateurMot g = new FakeGenerateurMot();
            //IGenerateur g = Mock.Of<IGenerateur>();
            Mock.Get(g).Setup(o => o.Generer()).Returns("bonjour");
            JeuPendu jeu = new JeuPendu(g);
            //Act
            jeu.GenererMasque();
            //Assert
            Assert.AreEqual("*******", jeu.Masque);
        }

        [TestMethod]
        public void TestCharTest_TRUE()
        {
            //Arrange
            Mock.Get(g).Setup(o => o.Generer()).Returns("coucou");
            JeuPendu jeu = new JeuPendu(g);
            //Act
            bool result = jeu.TestChar('c');
            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestCharTest_FALSE()
        {
            //Arrange
            Mock.Get(g).Setup(o => o.Generer()).Returns("coucou");
            JeuPendu jeu = new JeuPendu(g);
            //Act
            bool result = jeu.TestChar('t');
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestNombreEssai_Fixe()
        {
            //Arrange
            Mock.Get(g).Setup(o => o.Generer()).Returns("coucou");
            JeuPendu jeu = new JeuPendu(g);
            //Act
            jeu.TestChar('c');
            //Assert
            Assert.AreEqual(10, jeu.NbreEssai);
        }

        [TestMethod]
        public void TestNombreEssai_Change()
        {
            //Arrange
            Mock.Get(g).Setup(o => o.Generer()).Returns("coucou");
            JeuPendu jeu = new JeuPendu(g);
            //Act
            jeu.TestChar('t');
            jeu.TestChar('a');
            //Assert
            Assert.AreEqual(8, jeu.NbreEssai);
        }

        [TestMethod]
        public void ChangeMasqueTest()
        {
            //Arrange
            Mock.Get(g).Setup(o => o.Generer()).Returns("coucou");
            JeuPendu jeu = new JeuPendu(g);
            //Act
            jeu.GenererMasque();
            jeu.TestChar('u');
            jeu.TestChar('c');
            //Assert
            Assert.AreEqual("c*uc*u", jeu.Masque);
        }

        [TestMethod]
        public void TestWin_TRUE()
        {
            //Arrange
            Mock.Get(g).Setup(o => o.Generer()).Returns("coucou");
            JeuPendu jeu = new JeuPendu(g);
            //Act
            jeu.GenererMasque();
            jeu.TestChar('u');
            jeu.TestChar('c');
            jeu.TestChar('o');
            bool result = jeu.TestWin();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestWin_FALSE()
        {
            //Arrange
            Mock.Get(g).Setup(o => o.Generer()).Returns("coucou");
            JeuPendu jeu = new JeuPendu(g,1);
            //Act
            jeu.GenererMasque();
            jeu.TestChar('t');
            bool result = jeu.TestWin();
            //Assert
            Assert.IsFalse(result);
        }
    }
}
