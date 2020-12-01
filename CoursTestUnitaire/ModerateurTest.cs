using CorrectionForum.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursTestUnitaire
{
    [TestClass]
    public class ModerateurTest
    {
        private Forum forum = new Forum("test");
        [TestMethod]
        public void TestSupprimerNouvelle_FALSE()
        {
            //Arrange
            forum.Moderateur = new Moderateur("test", "test", 30, "ihab@utopios.net", forum);
            //Act
            bool result = forum.Moderateur.SupprimerNouvelle(3);

            //Assert

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestSupprimerNouvelle_TRUE()
        {
            //Arrange
         
            forum.Moderateur = new Moderateur("test", "test", 30, "ihab@utopios.net", forum);
            forum.Moderateur.AjouterNouvelle("ttt", "rrrr");
            //Act
            bool result = forum.Moderateur.SupprimerNouvelle(1);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestSupprimerNouvelle_TRUE_2()
        {
            //Arrange
            forum.Moderateur = new Moderateur("test", "test", 30, "ihab@utopios.net", forum);

            //Act
            forum.Moderateur.AjouterNouvelle("ttt", "rrrr");
            forum.Moderateur.AjouterNouvelle("ttt", "rrrr");
            forum.Moderateur.SupprimerNouvelle(1);

            //Assert
            Assert.AreEqual(1,forum.Nouvelles.Count);
        }

        [TestMethod]
        public void TestAjouterAbonne()
        {
            //Arrange
            forum.Moderateur = new Moderateur("test", "test", 30, "ihab@utopios.net", forum);
            Abonne a = new Abonne("tt", "ttt", 30, "ttt@ttt.fr", forum);
            //Act
            forum.Moderateur.AjouterAbonne(a);

            //Assert
            Assert.AreEqual(1, forum.Abonnes.Count);
        }

        [TestMethod]
        public void TestBannirAbonne_TRUE()
        {
            //Arrange
            forum.Moderateur = new Moderateur("test", "test", 30, "ihab@utopios.net", forum);
            Abonne a = new Abonne("tt", "ttt", 30, "ttt@ttt.fr", forum);
            forum.Moderateur.AjouterAbonne(a);
            //Act
            bool result = forum.Moderateur.BannirAbonne("ttt@ttt.fr");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestBannirAbonne_FALSE()
        {
            //Arrange
            forum.Moderateur = new Moderateur("test", "test", 30, "ihab@utopios.net", forum);
            //Act
            bool result = forum.Moderateur.BannirAbonne("ttt@ttt.fr");
            Assert.IsFalse(result);
        }
    }
}
