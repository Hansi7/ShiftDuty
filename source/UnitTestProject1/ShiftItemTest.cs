using ShiftDuty.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    
    
    /// <summary>
    ///这是 ShiftItemTest 的测试类，旨在
    ///包含所有 ShiftItemTest 单元测试
    ///</summary>
    [TestClass()]
    public class ShiftItemTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Tag 的测试
        ///</summary>
        [TestMethod()]
        public void TagTest()
        {
            ShiftItem target = new ShiftItem(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.Tag = expected;
            actual = target.Tag;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///RestValue 的测试
        ///</summary>
        [TestMethod()]
        public void RestValueTest()
        {
            ShiftItem target = new ShiftItem(); // TODO: 初始化为适当的值
            double expected = 0F; // TODO: 初始化为适当的值
            double actual;
            target.RestValue = expected;
            actual = target.RestValue;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///RestDate 的测试
        ///</summary>
        [TestMethod()]
        public void RestDateTest()
        {
            ShiftItem target = new ShiftItem(); // TODO: 初始化为适当的值
            DateTime expected = new DateTime(); // TODO: 初始化为适当的值
            DateTime actual;
            target.RestDate = expected;
            actual = target.RestDate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///NID 的测试
        ///</summary>
        [TestMethod()]
        public void NIDTest()
        {
            ShiftItem target = new ShiftItem(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            target.NID = expected;
            actual = target.NID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///Is_Calc 的测试
        ///</summary>
        [TestMethod()]
        public void Is_CalcTest()
        {
            ShiftItem target = new ShiftItem(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.Is_Calc = expected;
            actual = target.Is_Calc;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ID 的测试
        ///</summary>
        [TestMethod()]
        public void IDTest()
        {
            ShiftItem target = new ShiftItem(); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            target.ID = expected;
            actual = target.ID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ShiftItem 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ShiftItemConstructorTest()
        {
            ShiftItem target = new ShiftItem();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }
    }
}
