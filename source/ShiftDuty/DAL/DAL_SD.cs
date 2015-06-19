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

    }
}
