using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace ShiftDuty.DAL
{
    internal class DAL_SD
    {
        #region 基础查询

        /// <summary>
        /// 查找所有的休息类型
        /// </summary>
        /// <returns></returns>
        internal DataTable GetRestType()
        {
            var sql = "select * from RestType";
            return DBHelper.ExecuteDataTable(new System.Data.OleDb.OleDbCommand(sql));
        }
        internal DataTable GetAllPeople()
        {
            var sql = "selct * from PNames";
            return DBHelper.ExecuteDataTable(new System.Data.OleDb.OleDbCommand(sql));
        }
        internal DataTable GetShiftHistory(DateTime start,DateTime end)
        {
            var sql = "select * from RestHistoryView where Rest_Date between @s and @e";

            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@s",OleDbType.DBDate).Value = start;
                comm.Parameters.Add("@e", OleDbType.DBDate).Value = end;
                return DBHelper.ExecuteDataTable(comm);
            }

        }
        internal DataTable GetShiftHistory(DateTime start,DateTime end,string aliasName)
        {
            var sql = "select * from RestHistoryView where ALIAS_NAME = @n and  Rest_Date between @s and @e";

            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@n", OleDbType.VarWChar).Value = aliasName;
                comm.Parameters.Add("@s", OleDbType.DBDate).Value = start;
                comm.Parameters.Add("@e", OleDbType.DBDate).Value = end;
                return DBHelper.ExecuteDataTable(comm);
            }
        }
        internal DataTable GetHolidays(DateTime start,DateTime end)
        {
            var sql = "select * from HolidaysList";
            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                return DBHelper.ExecuteDataTable(comm);
            }
        }

        #endregion


        #region 插入操作

        internal int AddRestHistory(long nid,DateTime restDate,int rest_type_value)
        {
            var sql = "insert into RestHistory(NID,REST_DATE,REST_TYPE_VALUE) values(@nid,@date,@value)";
            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@nid", OleDbType.UnsignedInt).Value = nid;
                comm.Parameters.Add("@date", OleDbType.DBDate).Value = restDate;
                comm.Parameters.Add("@value", OleDbType.Integer).Value = rest_type_value;
                return DBHelper.ExecuteNonQuery(comm);
            }
        }
        internal int AddShiftHistory(DateTime date, long nid, int rest_value)
        {
            var sql = "insert into ShiftHistory(SHIFT_DATE,NID,REST_VALUE,IS_CALC) values(@date,@nid,@value,false)";
            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@date", OleDbType.DBDate).Value = date;
                comm.Parameters.Add("@nid", OleDbType.UnsignedInt).Value = nid;
                comm.Parameters.Add("@value", OleDbType.Integer).Value = rest_value;
                return DBHelper.ExecuteNonQuery(comm);
            }
        }


        #endregion

        #region 修改操作

        //上班历史生效.记录一个倒休给对应的人
        //改值班历史的IS_Calc为真，且改pnames表里的剩余倒休
        /// <summary>
        /// 上班历史表给人加调休数量了，每天早上执行。
        /// </summary>
        /// <returns></returns>
        internal int DutyDone()
        { 
            
            var dataUnDone = QueryUnDone();
            if (dataUnDone.Rows.Count>0)
            {
                foreach (DataRow item in dataUnDone.Rows)
                {
                    Console.WriteLine(item.Field<string>("SHIFT_Date"));
                }
            }

            //查找表中IS_Calc为否的，并且日期是过去的日期的项目。
            //var sql= "update set IS_CALC="
            
            //改为真。改调休数量。改真不成功，回退。

            return 0;
        }

        internal DataTable QueryUnDone()
        {
            var querySql = "select * from ShiftHistory where shift_date < @yesterday and is_Calc = False";
            using (OleDbCommand comm = new OleDbCommand(querySql))
            {
                comm.Parameters.Add("@yesterday", OleDbType.DBDate).Value = DateTime.Now.AddDays(-1);
                return DBHelper.ExecuteDataTable(comm);
            }
        }





        //上班记录修改
        //原来的名字的倒休数量去掉，改成现在要改的名字，is_calc置为假。要防止读取错误，更改到一半死机等情况。
        //现在的名字倒休数量加上去，is_calc置为真




        //休息记录的修改
        //事假修改为倒休=>减少该人员的倒休数量
		//事假修改为（年休假、算加班）=>不减少倒休数量

        #endregion

    }
}
