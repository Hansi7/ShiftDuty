using ShiftDuty.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using ShiftDuty.Entities;
using System.Data;

namespace UnitTestProject1
{
    
    
    /// <summary>
    ///这是 ExcelOutputTest 的测试类，旨在
    ///包含所有 ExcelOutputTest 单元测试
    ///</summary>
    [TestClass()]
    public class ExcelOutputTest
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
        ///ModifyExcel 的测试
        ///</summary>
        [TestMethod()]
        public void ModifyExcelTest()
        {
            FileInfo file = null; // TODO: 初始化为适当的值
            Dictionary<string, object> kvpRangeAndData = null; // TODO: 初始化为适当的值
            ExcelOutput.ModifyExcel(file, kvpRangeAndData);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///ModifyExcel 的测试
        ///</summary>
        [TestMethod()]
        public void ModifyExcelTest1()
        {
            FileInfo newfile = null; // TODO: 初始化为适当的值
            FileInfo template = null; // TODO: 初始化为适当的值
            Dictionary<string, object> kvpRangeAndData = null; // TODO: 初始化为适当的值
            ExcelOutput.ModifyExcel(newfile, template, kvpRangeAndData);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///ListViewToExcel 的测试
        ///</summary>
        [TestMethod()]
        public void ListViewToExcelTest()
        {
            ListView listview = null; // TODO: 初始化为适当的值
            string filenamewithpath = string.Empty; // TODO: 初始化为适当的值
            string sheetName = string.Empty; // TODO: 初始化为适当的值
            ExcelOutput.ListViewToExcel(listview, filenamewithpath, sheetName);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///Holidays 的测试
        ///</summary>
        [TestMethod()]
        public void HolidaysTest()
        {
            DateTime start = new DateTime(); // TODO: 初始化为适当的值
            Dictionary<DateTime, string> expected = null; // TODO: 初始化为适当的值
            Dictionary<DateTime, string> actual;
            actual = ExcelOutput.Holidays(start);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///Gen 的测试
        ///</summary>
        [TestMethod()]
        public void GenTest()
        {
            DateTime start = new DateTime(); // TODO: 初始化为适当的值
            DateTime end = new DateTime(); // TODO: 初始化为适当的值
            string fn = string.Empty; // TODO: 初始化为适当的值
            List<People> peoples = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = ExcelOutput.Gen(start, end, fn, peoples);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DataTableToExcel 的测试
        ///</summary>
        [TestMethod()]
        public void DataTableToExcelTest()
        {
            DataTable dt = null; // TODO: 初始化为适当的值
            string fileName = string.Empty; // TODO: 初始化为适当的值
            ExcelOutput.DataTableToExcel(dt, fileName);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }
    }
}
