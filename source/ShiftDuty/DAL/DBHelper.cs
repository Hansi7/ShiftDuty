using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace ShiftDuty.DAL
{
    internal class DBHelper
    {
        private static string conStr;//=  @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.accdb";

        static DBHelper()
        {
            conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SDDB.accdb") + "\"";
        }
        //OleDbCommand comm = new OleDbCommand();
        internal static DataTable ExecuteDataTable(OleDbCommand comm)
        {

            using (OleDbConnection conn = new OleDbConnection(conStr))
            {
                comm.Connection = conn;
                DataTable dt = new DataTable();
                OleDbDataAdapter adpt = new OleDbDataAdapter(comm);
                adpt.Fill(dt);
                return dt;
            }
        }

        internal static object ExecuteScalar(OleDbCommand comm)
        {
            using (OleDbConnection conn = new OleDbConnection(conStr))
            {
                comm.Connection = conn;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                return comm.ExecuteScalar();
            }
        }

        internal static int ExecuteNonQuery(OleDbCommand comm)
        {
            using (OleDbConnection conn = new OleDbConnection(conStr))
            {
                comm.Connection = conn;
                conn.Open();
                return comm.ExecuteNonQuery();
            }
        }

        internal static int ExecuteNonQuery(string sql)
        {
            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                return ExecuteNonQuery(comm);
            }
        }
    }
}
