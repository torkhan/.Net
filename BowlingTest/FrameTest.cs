using Bowling.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTest
{
    [TestClass]
    public class FrameTest
    {
        IGenerator generator = Mock.Of<IGenerator>();
        [TestMethod]
        public void SimpleFrameFirstRoll()
        {
            Mock.Get(generator).Setup(o => o.GetRandomPins(10)).Returns(7);
            Frame frame = new Frame(generator);

            frame.Roll();

            Assert.AreEqual(7, frame.Score);
        }

        

        [TestMethod]
        public void SimpleFrameSecondRoll()
        {
            //Arrange
            IFrame frame = Mock.Of<IFrame>();
            List<Roll> rolls = new List<Roll>() { new Roll(4) };

            Mock.Get(generator).Setup(o => o.GetRandomPins(6)).Returns(5);
            Mock.Get(frame).Setup(f => f.Rolls).Returns(rolls);
            Mock.Get(frame).Setup(f => f.Score).Returns(4);
            Mock.Get(frame).Setup(f => f.Generator).Returns(generator);

            //Act
            frame.Roll();

            //Assert
            Assert.AreEqual(9, frame.Score);
        }

        [TestMethod]
        public void SimpleFrameSecondRollAfterStrike()
        {

        }

        [TestMethod]
        public void LastFrameFirstRoll()
        {

        }

        [TestMethod]
        public void LastFrameFirstSecondRoll()
        {

        }

        [TestMethod]
        public void LastFrameThirdRoll()
        {

        }
    }
}
