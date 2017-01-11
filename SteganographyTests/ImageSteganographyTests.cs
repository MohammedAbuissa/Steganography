using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steganography;
namespace SteganographyTests
{
    [TestClass]
    public class ImageSteganographyTests
    {
        #region HideTests
        [TestMethod]
        public void Hide_ValidArrayWith0ValueAndFalseMsg_ValueIncBy1()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var content = new bool[1, 1] { { false } };
            var originalMsg = new byte[1, 1] { { 0 } };
            var expectedValue = (byte)(originalMsg[0, 0] + 1);
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
            Assert.AreEqual<byte>(expectedValue, modifiedMsg[0, 0]);
        }

        [TestMethod]
        public void Hide_ValidArrayWith255ValueAndTrueMsg_ValueDecBy1()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var content = new bool[1, 1] { { true } };
            var originalMsg = new byte[1, 1] { { 255 } };
            var expectedValue = (byte)(originalMsg[0, 0] - 1);
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
            Assert.AreEqual(expectedValue, modifiedMsg[0, 0]);
        }
        [TestMethod]
        public void Hide_ValidArrayWithValueEqualToHalfByteAndTrueMsg_ValueChange()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var content = new bool[1, 1] { { true } };
            var originalMsg = new byte[1, 1] { { 127 } };
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
            Assert.AreNotEqual(originalMsg[0, 0], modifiedMsg[0, 0]);
        }

        [TestMethod]
        public void Hide_ValidArrayWithOddValueAndFalseMsg_ValueNotChange()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var content = new bool[1, 1] { { false } };
            var originalMsg = new byte[1, 1] { { 51 } };
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
            Assert.AreEqual(originalMsg[0, 0], modifiedMsg[0, 0]);
        }

        [TestMethod]
        public void Hide_ValidArrayWithEvenValueAndTrueMsg_ValueNotChange()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var content = new bool[1, 1] { { true } };
            var originalMsg = new byte[1, 1] { { 100 } };
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
            Assert.AreEqual(originalMsg[0, 0], modifiedMsg[0, 0]);
        }

        [TestMethod]
        public void Hide_ValidArrayWithOddValueAndTrueMsg_ValueChange()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var content = new bool[1, 1] { { true } };
            var originalMsg = new byte[1, 1] { { 51 } };
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
            Assert.AreNotEqual(originalMsg[0, 0], modifiedMsg[0, 0]);
        }

        [TestMethod]
        public void Hide_ValidArrayWithEvenValueAndFalseMsg_ValueChange()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var content = new bool[1, 1] { { false } };
            var originalMsg = new byte[1, 1] { { 50 } };
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
            Assert.AreNotEqual(originalMsg[0, 0], modifiedMsg[0, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Hide_NullMsg_ArgumentNullException()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var content = new bool[1, 1] { { true } };
            byte[,] originalMsg = null;
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Hide_NullContent_ArgumentNullException()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            bool[,] content = null;
            byte[,] originalMsg = null;
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Hide_ContentAndOriginalMsgNotOfTheSameLength_ArgumentException()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            bool[,] content = new bool[5, 1];
            byte[,] originalMsg = new byte[3, 5];
            //Act
            var modifiedMsg = s.Hide(content, originalMsg);
            //Assert
        }
        #endregion
        #region FindTests
        [TestMethod]
        public void Find_OddValue_False()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var modifiedMsg = new byte[1, 1] { { 255 } };
            var expected = false;
            //Act
            var content = s.Find(modifiedMsg);
            //Assert
            Assert.AreEqual(expected, content[0, 0]);
        }

        [TestMethod]
        public void Find_EvenValue_True()
        {
            //Arrange
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            var modifiedMsg = new byte[1, 1] { { 22} };
            var expected = true;
            //Act
            var content = s.Find(modifiedMsg);
            //Assert
            Assert.AreEqual(expected, content[0, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Find_NullModifiedMsg_ArgumentNullException()
        {
            ISteganography<byte[,], bool[,]> s = new ImageSteganography();
            byte[,] modifiedMsg = null;
            //Act
            var content = s.Find(modifiedMsg);
            //Assert
        }
        #endregion



    }
}
