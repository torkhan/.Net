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
            Mock.Get(generator).Setup(o => o.GetRandomPins(10)).Returns(8);
            Frame frame = new Frame(generator);

            frame.Roll();

            Assert.AreEqual(8, frame.Score);
        }

        

        [TestMethod]
        public void SimpleFrameSecondRoll()
        {
            //Arrange
            //IFrame frame = Mock.Of<IFrame>();
            List<Roll> rolls = new List<Roll>() { new Roll(4) };

            Mock.Get(generator).Setup(o => o.GetRandomPins(6)).Returns(5);
            //Mock.Get(frame).Setup(f => f.Rolls).Returns(rolls);
            //Mock.Get(frame).Setup(f => f.Score).Returns(4);
            //Mock.Get(frame).Setup(f => f.Generator).Returns(generator);
            Frame frame = new Frame(generator);
            frame.Rolls = rolls;
            frame.Score = 4;
            //Act
            frame.Roll();

            //Assert
            Assert.AreEqual(9, frame.Score);
        }

        [TestMethod]
        public void SimpleFrameSecondRollAfterStrike()
        {
            //Arrange
            //IFrame frame = Mock.Of<IFrame>();
            List<Roll> rolls = new List<Roll>() { new Roll(10) };
            Mock.Get(generator).Setup(o => o.GetRandomPins(0)).Returns(0);
            //Mock.Get(frame).Setup(f => f.Rolls).Returns(rolls);
            //Mock.Get(frame).Setup(f =>f.Generator).Returns(generator);
            Frame frame = new Frame(generator);
            frame.Rolls = rolls;
            
            //Act
            Action resultRoll = () => frame.Roll();
            //Assert
            Assert.ThrowsException<Exception>(resultRoll);
        }

        

        [TestMethod]
        public void LastFrameSecondRoll()
        {
            //Arrange
            //IFrame frame = Mock.Of<IFrame>();
            List<Roll> rolls = new List<Roll>() { new Roll(10) };
            //Mock.Get(frame).Setup(f => f.LastFrame).Returns(true);
            //Mock.Get(frame).Setup(f => f.Rolls).Returns(rolls);
            Mock.Get(generator).Setup(g => g.GetRandomPins(10)).Returns(4);
            //Mock.Get(frame).Setup(f => f.Generator).Returns(generator);
            Frame frame = new Frame(generator);
            frame.Rolls = rolls;
            frame.Score = 10;
            frame.LastFrame = true;
            //Act
            frame.Roll();
            //Assert
            Assert.AreEqual(14, frame.Score);
        }

        [TestMethod]
        public void LastFrameThirdRoll_1()
        {
            //Arrange
            //IFrame frame = Mock.Of<IFrame>();
            List<Roll> rolls = new List<Roll>() { new Roll(10), new Roll(10) };
            //Mock.Get(frame).Setup(f => f.LastFrame).Returns(true);
            //Mock.Get(frame).Setup(f => f.Rolls).Returns(rolls);
            Mock.Get(generator).Setup(g => g.GetRandomPins(10)).Returns(4);
            //Mock.Get(frame).Setup(f => f.Generator).Returns(generator);
            Frame frame = new Frame(generator);
            frame.Rolls = rolls;
            frame.Score = 20;
            frame.LastFrame = true;
            //Act
            frame.Roll();
            //Assert
            Assert.AreEqual(24, frame.Score);
        }

        [TestMethod]
        public void LastFrameThirdRoll_2()
        {
            //Arrange
            //IFrame frame = Mock.Of<IFrame>();
            List<Roll> rolls = new List<Roll>() { new Roll(7), new Roll(3) };
            //Mock.Get(frame).Setup(f => f.LastFrame).Returns(true);
            //Mock.Get(frame).Setup(f => f.Rolls).Returns(rolls);
            Mock.Get(generator).Setup(g => g.GetRandomPins(10)).Returns(4);
            //Mock.Get(frame).Setup(f => f.Generator).Returns(generator);
            Frame frame = new Frame(generator);
            frame.Rolls = rolls;
            frame.Score = 10;
            frame.LastFrame = true;
            //Act
            frame.Roll();
            //Assert
            Assert.AreEqual(14, frame.Score);
        }

        [TestMethod]
        public void LastFrameThirdRoll_3()
        {
            //Arrange
            //IFrame frame = Mock.Of<IFrame>();
            List<Roll> rolls = new List<Roll>() { new Roll(10), new Roll(4) };
            //Mock.Get(frame).Setup(f => f.LastFrame).Returns(true);
            //Mock.Get(frame).Setup(f => f.Rolls).Returns(rolls);
            Mock.Get(generator).Setup(g => g.GetRandomPins(6)).Returns(4);
            //Mock.Get(frame).Setup(f => f.Generator).Returns(generator);
            Frame frame = new Frame(generator);
            frame.Rolls = rolls;
            frame.Score = 14;
            frame.LastFrame = true;
            //Act
            frame.Roll();
            //Assert
            Assert.AreEqual(18, frame.Score);
        }

        [TestMethod]
        public void LastFrameThirdRoll_Exception()
        {
            //Arrange
            //IFrame frame = Mock.Of<IFrame>();
            List<Roll> rolls = new List<Roll>() { new Roll(6), new Roll(3) };
            //Mock.Get(frame).Setup(f => f.LastFrame).Returns(true);
            //Mock.Get(frame).Setup(f => f.Rolls).Returns(rolls);
            Mock.Get(generator).Setup(g => g.GetRandomPins(6)).Returns(4);
            //Mock.Get(frame).Setup(f => f.Generator).Returns(generator);
            Frame frame = new Frame(generator);
            frame.Rolls = rolls;
            frame.Score = 9;
            frame.LastFrame = true;
            //Act
            Action  resultRoll = () => frame.Roll();
            //Assert
            Assert.ThrowsException<Exception>(resultRoll);
        }
    }
}
