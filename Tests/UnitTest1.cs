using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1.Classes;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmpty()
        {
            Util util = new Util();

            Assert.IsTrue(util.CheckEmpty(""));
            Assert.IsFalse(util.CheckEmpty("Ошибка"));
        }
        [TestMethod]
        public void TestEmptyTwo()
        {
            Util util = new Util();

            Assert.IsTrue(util.CheckEmptyTwo("",""));

            Assert.IsFalse(util.CheckEmptyTwo("Ошибка", "Ошибка"));
        }
        [TestMethod]
        public void TestAutoriz()
        {
            AutorizReg autorizreg = new AutorizReg();

            Assert.IsTrue(autorizreg.IsAutoriz("1","1"));
            Assert.IsFalse(autorizreg.IsAutoriz("0","0"));
        }
        [TestMethod]
        public void TestReg()
        {
            AutorizReg autorizreg = new AutorizReg();

            Assert.IsTrue(autorizreg.IsRegistered("0"));
            Assert.IsFalse(autorizreg.IsRegistered("1"));
        }
        [TestMethod]
        public void TestAddFilm()
        {
            AddFilm addfilm = new AddFilm();

            Assert.IsTrue(addfilm.IsAdded("0"));
            Assert.IsFalse(addfilm.IsAdded("11"));
        }
    }
}
