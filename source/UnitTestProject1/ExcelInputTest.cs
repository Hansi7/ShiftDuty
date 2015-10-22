using ShiftDuty.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using ShiftDuty.Entities;
using System.Collections.Generic;

namespace UnitTestProject1
{
    
    
    /// <summary>
    ///这是 ExcelInputTest 的测试类，旨在
    ///包含所有 ExcelInputTest 单元测试
    ///</summary>
    [TestClass()]
    public class ExcelInputTest
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
        ///ToDataTable 的测试
        ///</summary>
        [TestMethod()]
        public void ToDataTableTest()
        {
            string path = string.Empty; // TODO: 初始化为适当的值
            DataTable expected = null; // TODO: 初始化为适当的值
            DataTable actual;
            actual = ExcelInput.ToDataTable(path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ImportOndutyList 的测试
        ///</summary>
        [TestMethod()]
        public void ImportOndutyListTest()
        {
            string excelFile = string.Empty; // TODO: 初始化为适当的值
            List<People> peoples = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ExcelInput.ImportOndutyList(excelFile, peoples);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ExcelToDataTable 的测试
        ///</summary>
        [TestMethod()]
        public void ExcelToDataTableTest()
        {
            string path = string.Empty; // TODO: 初始化为适当的值
            DataTable expected = null; // TODO: 初始化为适当的值
            DataTable actual;
            actual = ExcelInput.ExcelToDataTable(path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
