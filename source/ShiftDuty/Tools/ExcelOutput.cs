using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace ShiftDuty.Tools
{
    public static class ExcelOutput
    {
        public static void ListViewToExcel(System.Windows.Forms.ListView listview, string filenamewithpath, string sheetName)
        {

            FileInfo f = new FileInfo(filenamewithpath);
            if (f.Exists)
            {
                f.Delete();
                f = new FileInfo(filenamewithpath);
            }

            using (ExcelPackage ep = new ExcelPackage(f))
            {
                ExcelWorksheet osheet = ep.Workbook.Worksheets.Add(sheetName);

                for (int i = 0; i < listview.Columns.Count; i++)
                {
                    osheet.Cells[1, i + 1].Value = listview.Columns[i].Text;
                }
                for (int i = 0; i < listview.Items.Count; i++)
                {
                    for (int j = 0; j < listview.Columns.Count; j++)
                    {
                        osheet.Cells[i + 2, j + 1].Value = listview.Items[i].SubItems[j].Text;
                    }
                }

                for (int i = 1; i <= osheet.Dimension.End.Column; i++)
                {
                    osheet.Column(i).AutoFit(8.43);
                    //osheet.Column(i).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                }


                ep.Save();
            }
        }
        public static void ListViewToExcel_RestHistory(System.Windows.Forms.ListView listview, string filenamewithpath, string sheetName)
        {

            FileInfo f = new FileInfo(filenamewithpath);
            if (f.Exists)
            {
                f.Delete();
                f = new FileInfo(filenamewithpath);
            }

            using (ExcelPackage ep = new ExcelPackage(f))
            {
                ExcelWorksheet osheet = ep.Workbook.Worksheets.Add(sheetName);
                
                for (int i = 0; i < listview.Columns.Count; i++)
                {
                    osheet.Cells[1, i + 1].Value = listview.Columns[i].Text;
                    osheet.Column(i+1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                }
                //osheet.Column(4).Style.Numberformat.Format = "G/通用格式";
                osheet.Column(2).Style.Numberformat.Format = "yyyy-MM-dd";
                for (int i = 0; i < listview.Items.Count; i++)
                {
                    for (int j = 0; j < listview.Columns.Count; j++)
                    {
                        if (j == 1)//第二列
                        {
                            //osheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "yyyy/MM/dd";
                            osheet.Cells[i + 2, j + 1].Value = DateTime.Parse(listview.Items[i].SubItems[j].Text);
                        }
                        if (j == 3)//第四列
                        {
                            osheet.Cells[i + 2, j + 1].Value = double.Parse(listview.Items[i].SubItems[j].Text);
                        }
                        else //其他列
                        {
                            osheet.Cells[i + 2, j + 1].Value = listview.Items[i].SubItems[j].Text;
                        }
                        
                    }
                }

                for (int i = 1; i <= osheet.Dimension.End.Column; i++)
                {
                    osheet.Column(i).AutoFit(8.43);
                    //osheet.Column(i).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                }


                ep.Save();
            }
        }
        public static void DataTableToExcel(DataTable dt, string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (ExcelPackage ep = new ExcelPackage(new FileInfo(fileName)))
                {
                    var st = ep.Workbook.Worksheets.Add(Path.GetFileNameWithoutExtension(fileName));
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        st.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            st.Cells[i + 2, j + 1].Value = dt.Rows[i][j].ToString();
                        }
                    }
                    for (int i = 0; i < st.Dimension.End.Column; i++)
                    {
                        st.Column(i + 1).AutoFit();
                    }
                    ep.Save();
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }
        /// <summary>
        /// Excel文件修改
        /// </summary>
        /// <param name="newfile">新文件</param>
        /// <param name="template">模板文件</param>
        /// <param name="kvpRangeAndData">要修改的数据字典，key为单元格地址，Value为单元格的数据</param>
        public static void ModifyExcel(FileInfo newfile, FileInfo template, Dictionary<string, object> kvpRangeAndData)
        {
            using (ExcelPackage ep = new ExcelPackage(newfile, template))
            {
                var wb = ep.Workbook;
                foreach (var item in kvpRangeAndData)
                {
                    wb.Worksheets[1].Cells[item.Key].Value = item.Value;
                }
                ep.Save();
            }
        }
        #region Sample For ModifyExcel
        //FileInfo ff = new FileInfo(@"E:\日检表\广播智能监测系统日检表.xlsx");
        //var nf = new FileInfo(@"e:\日检表\广播智能监测系统日检表" + DateTime.Now.ToShortDateString() + ".xlsx");
        //Dictionary<string, string> dic = new Dictionary<string, string>();
        //dic.Add("C2", DateTime.Now.ToString("yyyy年MM月dd日"));
        //dic.Add("H2", "申健");
        //ModifyExcel(nf, ff, dic); 
        #endregion
        /// <summary>
        /// 续写文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="kvpRangeAndData"></param>
        public static void ModifyExcel(FileInfo file, Dictionary<string, object> kvpRangeAndData)
        {
            using (ExcelPackage ep = new ExcelPackage(file))
            {
                var wb = ep.Workbook;
                foreach (var item in kvpRangeAndData)
                {
                    wb.Worksheets[1].Cells[item.Key].Value = item.Value;
                }
                ep.Save();
            }
        }

        /// <summary>
        /// 生产排版表
        /// </summary>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <param name="fn">文件名</param>
        /// <param name="peoples">备选名单,可以为null</param>
        /// <returns></returns>
        public static int Gen(DateTime start, DateTime end, string fn, List<Entities.People> peoples)
        {
            try
            {
                using (ExcelPackage ep = new ExcelPackage())
                {
                    var wb = ep.Workbook;
                    var s1 = wb.Worksheets.Add(start.ToString("MM月dd日")+"-"+end.ToString("MM月dd日")+"值班表");

                    var heads = new string[]{"值班日期","星期","值班员","倒休值","备注"};
                    var widths = new double[] { 20, 8, 23, 10,30 };

                    for (int i = 1; i <= heads.Length; i++)
                    {
                        s1.Cells[1, i].Value = heads[i-1];
                        s1.Cells[1, i].Style.Font.Bold = true;
                        s1.Column(i).AutoFit(widths[i - 1]);
                        
                        s1.Column(i).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }
                    s1.Column(1).Style.Numberformat.Format = "yyyy-MM-dd";

                    List<DateTime> list = new List<DateTime>();
                    var DayNames = new string[]{"日","一","二","三","四","五","六"};
                    var length = (int)(end - start).TotalDays;

                    for (int i = 0; i < length; i++)
                    {
                        int weekday = int.Parse((start.AddDays(i).DayOfWeek.ToString("d")));
                        s1.Cells[2 + i, 1].Value = start.AddDays(i);
                        s1.Cells[2 + i, 2].Value = DayNames[weekday];

                        if (weekday==0 || weekday == 6)
	                    {
                            s1.Cells[2 + i, 4].Value = 1.5;
                        }
                        else
                        {
                            s1.Cells[2 + i, 4].Value = 0.5;
                        }

                        var dicholidays = Holidays(start);

                        if (dicholidays.ContainsKey(start.AddDays(i)))
                        {
                            s1.Cells[2 + i, 5].Value = dicholidays[start.AddDays(i)];
                        }
                    }

                    if (peoples !=null || peoples.Count !=0)
                    {
                        for (int i = 0; i < peoples.Count; i++)
                        {
                            s1.Cells[2 + i, 3].Value = peoples[i].AliasName;
                        }
                    }

                    for (int i = 1; i <= heads.Length; i++)
                    {
                        s1.Column(i).Style.Font.Size = 16;
                        s1.Column(i).Style.Font.Name = "仿宋";

                        for (int j = 0; j <= length ; j++)
                        {
                            s1.Cells[j + 1, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                    }

                    //s1.Tables.Add(new ExcelAddressBase(s1.Dimension.Address), "t1");
                    //s2.Tables.Add(new ExcelAddressBase(s2.Dimension.Address), "t2");
                    //s3.Tables.Add(new ExcelAddressBase(s3.Dimension.Address), "t3");

                    ep.SaveAs(new FileInfo(fn));
                    return 1;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public static Dictionary<DateTime,string> Holidays(DateTime start)
        {
            Dictionary<DateTime, string> list = new Dictionary<DateTime, string>();
            string[] holidays = new string[]{   
            "1/1",//元旦
            "2/1",//春节==
            "4/4",//清明
            "4/5",//清明
            "4/6",//清明
            "5/1",//劳动
            "6/1",//端午==
            "9/1",//中秋==
            "10/1",//国庆
            "10/2",//国庆
            "10/3"};
            string[] descs = new string[]{
            "元旦?",
            "注意春节日期?",
            "清明节?",
            "清明节?",
            "清明节?",
            "劳动?",
            "注意端午节日期?",
            "注意中秋节日期?",
            "国庆?",
            "国庆?",
            "国庆?"};

            if (holidays.Length!=descs.Length)
            {
                throw new Exception("参数错误");
            }

            for (int i = 0; i < holidays.Length; i++)
            {
                list.Add(DateTime.Parse(start.Year.ToString() + "/" + holidays[i]), descs[i]);
            }
            return list;
        }

    }
}
