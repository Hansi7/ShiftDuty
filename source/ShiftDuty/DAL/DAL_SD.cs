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
            var sql = "select * from PNames";
            return DBHelper.ExecuteDataTable(new System.Data.OleDb.OleDbCommand(sql));
        }

        internal DataTable GetShiftHistory(DateTime start, DateTime end, string aliasName)
        {
            var sql = "select * from ShiftHistory where ALIAS_NAME = @n and  Rest_Date between @s and @e";

            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@n", OleDbType.VarWChar).Value = aliasName;
                comm.Parameters.Add("@s", OleDbType.DBDate).Value = start;
                comm.Parameters.Add("@e", OleDbType.DBDate).Value = end;
                return DBHelper.ExecuteDataTable(comm);
            }
        }


        #region Rest
        internal DataTable GetRestHistoryView(DateTime start, DateTime end)
        {
            var sql = "select * from RestHistoryView where Rest_Date between @s and @e";

            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@s", OleDbType.DBDate).Value = start;
                comm.Parameters.Add("@e", OleDbType.DBDate).Value = end;
                return DBHelper.ExecuteDataTable(comm);
            }
        }
        internal DataTable GetRestHistoryView()
        {
            using (OleDbCommand comm = new OleDbCommand("select * from RestHistoryView"))
            {
                return DBHelper.ExecuteDataTable(comm);
            }
        }
        #endregion

        #region Shift
        internal DataTable ShiftHistoryView()
        {
            using (OleDbCommand comm = new OleDbCommand("select * from ShiftHistoryView"))
            {
                return DBHelper.ExecuteDataTable(comm);
            }
        }
        internal DataTable GetShiftHistory(DateTime start, DateTime end)
        {
            var sql = "select * from ShiftHistory where SHIFT_DATE between @s and @e order by shift_date";

            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@s", OleDbType.DBDate).Value = start;
                comm.Parameters.Add("@e", OleDbType.DBDate).Value = end;
                return DBHelper.ExecuteDataTable(comm);
            }

        }

        #endregion

        internal DataTable GetHolidays(DateTime start, DateTime end)
        {
            var sql = "select * from HolidaysList";
            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                return DBHelper.ExecuteDataTable(comm);
            }
        }


        /// <summary>
        /// 符合性
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal DataTable QueryShiftItem(DateTime date, int nid)
        {
            var q = "select * from shiftHistory where shift_date = @d and NID = " + nid;
            using (OleDbCommand comm = new OleDbCommand(q))
            {
                comm.Parameters.Add("@d", OleDbType.DBDate).Value = date;
                return DBHelper.ExecuteDataTable(comm);
            }
        }
        /// <summary>
        /// 可以有多个人结果
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        internal DataTable QueryWhosOnDuty(DateTime dat)
        {
            var querySql = "select * from ShiftHistory where shift_date = @dat";
            using (OleDbCommand comm = new OleDbCommand(querySql))
            {
                comm.Parameters.Add("@dat", OleDbType.DBDate).Value = dat;
                return DBHelper.ExecuteDataTable(comm);
            }
        }
        #endregion


        #region 插入操作
        /// <summary>
        /// 插入休息的信息。已经测试。
        /// </summary>
        /// <param name="nid"></param>
        /// <param name="restDate"></param>
        /// <param name="rest_type"></param>
        /// <returns></returns>
        internal int AddRestHistory(int nid, DateTime restDate, int rest_type,double rest_value)
        {
            var sql = "insert into RestHistory(NID,REST_DATE,REST_TYPE_VALUE,REST_VALUE) values(@nid,@date,@value,@restV)";
            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@nid", OleDbType.Integer).Value = nid;
                comm.Parameters.Add("@date", OleDbType.DBDate).Value = restDate;
                comm.Parameters.Add("@value", OleDbType.Integer).Value = rest_type;
                comm.Parameters.Add("@restV", OleDbType.Double).Value = rest_value;
                return DBHelper.ExecuteNonQuery(comm);
            }
        }
        /// <summary>
        /// 插入新的排班表，已经测试,插入之后为没有计算过倒休的状态。
        /// </summary>
        /// <param name="date"></param>
        /// <param name="nid"></param>
        /// <param name="rest_value"></param>
        /// <returns></returns>
        internal int AddShiftHistory(DateTime date, int nid, double rest_value)
        {
            var sql = "insert into ShiftHistory(SHIFT_DATE,NID,REST_VALUE,IS_CALC) values(@date,@nid,@value,false)";
            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@date", OleDbType.DBDate).Value = date;
                comm.Parameters.Add("@nid", OleDbType.Integer).Value = nid;
                comm.Parameters.Add("@value", OleDbType.Double).Value = rest_value;
                return DBHelper.ExecuteNonQuery(comm);
            }
        }
        #endregion

        #region 修改操作

        //上班历史生效.记录一个倒休给对应的人
        //改值班历史的IS_Calc为真，且改pnames表里的剩余倒休
        /// <summary>
        /// 上班历史表给人加调休数量了，每天早上执行。sql语句已经测试OK
        /// </summary>
        /// <returns></returns>
        //internal int DutyDone()
        //{

        //    var dataUnDone = QueryUnCalcShiftItem();
        //    if (dataUnDone.Rows.Count > 0)
        //    {
        //        foreach (DataRow item in dataUnDone.Rows)
        //        {
        //            //Console.WriteLine((item.Field<DateTime>("SHIFT_Date")));

        //            string sqlUPdate = "update ShiftHistory set IS_CALC=True where ID = " + item.Field<uint>("ID");
        //            DBHelper.ExecuteNonQuery(sqlUPdate);

        //            string sqlUPdateDaoxiu = "update pnames set daoxiu_remain = daoxiu_remain + " + item.Field<double>("REST_VALUE") + " where nid = " + item.Field<uint>("nid");
        //            DBHelper.ExecuteNonQuery(sqlUPdateDaoxiu);
        //        }
        //    }

        //    //查找表中IS_Calc为否的，并且日期是过去的日期的项目。
        //    //var sql= "update set IS_CALC="

        //    //改为真。改调休数量。改真不成功，回退。

        //    return 0;
        //}

        internal int DutyDone(DateTime dt, Entities.People p)
        {
            return DutyDone(dt, p.NID);
        }

        internal int DutyDone(DateTime dt, int nid)
        {
            var dtable = QueryShiftItem(dt, nid);
            if (dtable.Rows.Count > 0)
            {
                string sqlUPdate = "update ShiftHistory set IS_CALC=True where shift_date = @d and IS_CALC = False  and nid = " + nid;
                OleDbCommand comm = new OleDbCommand(sqlUPdate);
                comm.Parameters.Add("@d", OleDbType.DBDate).Value = dt;
                DBHelper.ExecuteNonQuery(comm);

                var q = from DataRow a in dtable.Rows
                        where a.Field<int>("NID") == nid
                        select a;

                if (q.Count() == 1)
                {
                    q.ToString();
                }

                string sqlUPdateDaoxiu = "update pnames set daoxiu_remain = daoxiu_remain + " + dtable.Rows[0].Field<double>("REST_VALUE") + " where nid = " + nid;
                DBHelper.ExecuteNonQuery(sqlUPdateDaoxiu);
            }
            return 0;
        }


        internal int Un_DutyDone(DateTime dt, int nid)
        {
            var dtable = QueryShiftItem(dt, nid);
            if (dtable.Rows.Count > 0)
            {
                string sqlUPdate = "update ShiftHistory set IS_CALC=False where shift_date = @d and IS_CALC = True  and nid = " + nid;
                OleDbCommand comm = new OleDbCommand(sqlUPdate);
                comm.Parameters.Add("@d", OleDbType.DBDate).Value = dt;
                DBHelper.ExecuteNonQuery(comm);

                var q = from DataRow a in dtable.Rows
                        where a.Field<int>("NID") == nid
                        select a;

                if (q.Count() == 1)
                {
                    q.ToString();
                }

                string sqlUPdateDaoxiu = "update pnames set daoxiu_remain = daoxiu_remain - " + dtable.Rows[0].Field<double>("REST_VALUE") + " where nid = " + nid;
                DBHelper.ExecuteNonQuery(sqlUPdateDaoxiu);
            }
            return 0;
        }


        /// <summary>
        /// 查找还没有计算倒休的值班项目
        /// </summary>
        /// <param name="date">此日期之前的</param>
        /// <returns></returns>
        internal DataTable QueryUnCalcShiftItem(DateTime date)
        {
            var querySql = "select * from ShiftHistory where shift_date < @yesterday and is_Calc = False";
            using (OleDbCommand comm = new OleDbCommand(querySql))
            {
                comm.Parameters.Add("@yesterday", OleDbType.DBDate).Value = date;
                return DBHelper.ExecuteDataTable(comm);
            }
        }

        /// <summary>
        /// 查询某日期值班员的NID
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal List<int> QueryWhosOnDutyNID(DateTime date)
        {
            var querySql = "select nid from ShiftHistory where shift_date = @d";
            using (OleDbCommand comm = new OleDbCommand(querySql))
            {
                comm.Parameters.Add("@d", OleDbType.DBDate).Value = date;
                var dt = DBHelper.ExecuteDataTable(comm);
                List<int> list = new List<int>();
                foreach (DataRow item in dt.Rows)
                {
                    list.Add(item.Field<int>("NID"));
                }
                return list;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dutyDate"></param>
        /// <param name="p"></param>
        /// <exception cref="查询参数错误：没有此人在此日期的值班记录"></exception>
        /// <returns></returns>
        internal bool QueryIsCalc(DateTime dutyDate, int nid)
        {
            var sql = "select is_calc from ShiftHistory where nid = @nid and shift_date = @yesterday";
            using (OleDbCommand comm = new OleDbCommand(sql))
            {
                comm.Parameters.Add("@nid", OleDbType.UnsignedInt).Value = nid;
                comm.Parameters.Add("@yesterday", OleDbType.DBDate).Value = dutyDate;
                var obj = DBHelper.ExecuteScalar(comm);

                if (obj != null)
                {
                    return (bool)obj;
                }
                else
                {
                    throw new Exception("没有此人在此日期的值班记录");
                }
            }
            //throw new NotImplementedException();
        }

        #endregion

        #region 删除

        internal int DelShiftHistoryByID(int id)
        {
            using (OleDbCommand comm = new OleDbCommand("delete from ShiftHistory where id = @id"))
            {
                comm.Parameters.Add("@id", OleDbType.Integer).Value = id;
                return DBHelper.ExecuteNonQuery(comm);
            }
        }

        internal int DelRestHistoryByID(int id)
        {
            using (OleDbCommand comm = new OleDbCommand("delete from resthistory where id =  @id"))
            {
                comm.Parameters.Add("@id", OleDbType.Integer).Value = id;
                return DBHelper.ExecuteNonQuery(comm);
            }
        }


        #endregion

        #region 清空数据库

        public int ClearAll(int psw)
        {
            if (psw==123456)
            {
                DBHelper.ExecuteNonQuery("delete from PNames");
                DBHelper.ExecuteNonQuery("delete from ShiftHistory");
                DBHelper.ExecuteNonQuery("delete from restHistory");

                //DBHelper.ExecuteNonQuery("alter table PNames alter column NID counter(1,1)");
                //DBHelper.ExecuteNonQuery("alter table ShiftHistory alter column ID counter(1,1)");
                //DBHelper.ExecuteNonQuery("alter table restHistory alter column ID counter(1,1)");
                return 1;
            }
            else
            {
                return 0;
            }
            
        }
        /// <summary>
        /// 添加名单
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        internal int addNewPeople(string p1, double p2)
        {
            using (OleDbCommand comm = new OleDbCommand("insert into PNames (Alias_Name, DaoXiu_Remain) values(@p1,@p2)"))
            {
                comm.Parameters.Add("@p1", OleDbType.VarWChar).Value = p1;
                comm.Parameters.Add("@p2", OleDbType.Double).Value = p2;
                return DBHelper.ExecuteNonQuery(comm);
            }
        }
        #endregion



        internal int DelPeople(int p)
        {
             return DBHelper.ExecuteNonQuery("delete from Pnames where nid = " + p.ToString());
        }
        //没有测试
        /// <summary>
        /// 修改值班表
        /// </summary>
        /// <param name="p">值班表的ID</param>
        /// <param name="nid">新的值班人的ID</param>
        /// <returns></returns>
        internal int ModifyPeopleInShiftItem(int p, int nid)
        {
            using (OleDbCommand comm = new OleDbCommand("update ShiftHistory set nid = @nid where id = @p"))
            {
                comm.Parameters.Add("@nid", OleDbType.Integer).Value = nid;
                comm.Parameters.Add("@p", OleDbType.Integer).Value = p;
                return DBHelper.ExecuteNonQuery(comm);
            }
        }
    }
}
