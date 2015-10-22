using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OfficeOpenXml;

namespace ShiftDuty.Tools
{
    public static class ExcelInput
    {
        public static DataTable ToDataTable(string path)
        {
            var dtb = new DataTable();
            using (ExcelPackage ep = new ExcelPackage(new System.IO.FileInfo(path)))
            {
                var s1 = ep.Workbook.Worksheets[1];
                
                for (int i = 1; i <= s1.Dimension.End.Column; i++)
                {
                    dtb.Columns.Add(s1.Cells[1, i].Value.ToString());
                }
                var M = s1.Cells[2, 1, s1.Dimension.End.Row, s1.Dimension.End.Column].Value;

                object[,] MO = (M as object[,]);
                for (int ro = 0; ro < MO.GetLength(0); ro++)
			    {
                    List<object> l = new List<object>();
                    for (int co = 0; co < MO.GetLength(1); co++)
                    {
                        if (MO[ro, co]!=null)
	                    {
                            l.Add(MO[ro, co]);
	                    }
                        else
                        {
                            l.Add("");
                        }
                    }
                    dtb.Rows.Add(l.ToArray());
			    }
            }
            return dtb;
        }

        /// <summary>
        /// 解决了一个富文本的问题的导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string path)
        {
            var dtb = new DataTable();
            using (ExcelPackage ep = new ExcelPackage(new System.IO.FileInfo(path)))
            {
                var s1 = ep.Workbook.Worksheets[1];

                for (int i = 1; i <= s1.Dimension.End.Column; i++)
                {
                    dtb.Columns.Add(s1.Cells[1, i].Value.ToString());
                }

                for (int i = 2; i <= s1.Dimension.End.Row; i++)
                {
                    List<string> singleRow = new List<string>();
                    for (int j = 1; j <= s1.Dimension.End.Column; j++)
                    {
                        if (s1.Cells[i, j].IsRichText)
                        {
                            singleRow.Add(s1.Cells[i, j].RichText.Text.Trim());
                        }
                        else if (s1.Cells[i, j].Value == null)
                        {
                            singleRow.Add(string.Empty);
                        }
                        else
                        {
                            singleRow.Add(s1.Cells[i, j].Value.ToString().Trim());
                        }
                    }
                    dtb.Rows.Add(singleRow.ToArray());
                }
            }
            return dtb;
        }

        
        public static int ImportOndutyList(string excelFile,List<Entities.People> peoples)
        {
            var manager = new BLL.ShiftManager();
            using (ExcelPackage ep = new ExcelPackage(new System.IO.FileInfo(excelFile)))
            {

                int c = 0;
                var s1 = ep.Workbook.Worksheets[1];

                for (int i = 2; i <= s1.Dimension.End.Row; i++)
                {
                    DateTime dt = DateTime.FromOADate((double)s1.Cells[i, 1].Value);

                    if (s1.Cells[i, 2].Value == null)
                    {
                        continue;
                    }
                    //第3列
                    string name = s1.Cells[i, 3].RichText.Text;
                    name = name.Replace(" ","");
                    if (name.Trim() == "")
                    {
                        continue;
                    }
                    int peopleIndex = -1;
                    for (int j = 0; j < peoples.Count; j++)
                    {
                        if (peoples[j].AliasName == name)
                        {
                            peopleIndex = j;
                            break;
                        }
                    }


                    double val = (double)s1.Cells[i,4].Value;

                    if (peopleIndex!=-1)
                    {
                        manager.AddShiftHistory(dt, peoples[peopleIndex], val);
                        c++;
                    }
                }
                return c;
            }
        }
        


    }
}
