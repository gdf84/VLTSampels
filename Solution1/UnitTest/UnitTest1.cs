using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Div_CorrectTest()
        {
            int a = 4;
            int b = 2;
            int expected = 2;

            ViewModel e = new ViewModel();
            var actual = e.Div(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Div_NegativeValues()
        {
            int a = -4;
            int b = -2;
            int expected = 2;

            ViewModel e = new ViewModel();
            var actual = e.Div(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Div_ByZero()
        {
            int a = -4;
            int b = 0;
            //bool expected = true;
            bool actual = false;

            try
            {
                ViewModel e = new ViewModel();
                e.Div(a, b);
            }
            catch
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Function_test() {
            Mock<ViewModel> mock = new Mock<ViewModel>();

            mock.Setup(x => x.Div(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(2);

            //mock.Setup(x=>x.Function(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            //    .

            var result = mock.Object.Function(1, 1, 1);

            Assert.AreEqual(3, result);

        }
    }
}
