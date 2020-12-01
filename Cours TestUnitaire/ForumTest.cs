using CorrectionForum.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cours_TestUnitaire
{
    [TestClass]
    public class ForumTest
    {
        private Forum forum = new Forum("test");
        [TestMethod]
        public void TestAjouterNouvelle()
        {
            //Arrange
            forum.Abonnes = new List<Abonne>();
            
           //Act

                

        }
    }
}
