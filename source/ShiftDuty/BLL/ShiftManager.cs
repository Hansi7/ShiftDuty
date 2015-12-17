using ShiftDuty.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ShiftDuty.BLL
{
    public class ShiftManager
    {
        DAL.DAL_SD dal = new DAL.DAL_SD();
        public ShiftManager()
        {

        }

        #region 已经测试
        internal DataTable RestHistoryView()
        {
            return dal.GetRestHistoryView();
        }
        internal List<ShiftItem> UnDoneShiftItem()
        {
            return _toEntityShiftItems(dal.QueryUnCalcShiftItem(DateTime.Now));
        }
        internal DataTable ShiftHistoryView()
        {
            return dal.ShiftHistoryView();
        }
        internal List<People> WhosOnDuty(DateTime dutyDate)
        {
            var dt = dal.QueryWhosOnDuty(dutyDate);
            var nids = from j in _toEntityShiftItems(dt)
                       select j.NID;
            var ps = GetAllPeople();
            var q = from i in ps
                    where nids.Contains(i.NID)
                    select i;

            return q.ToList<People>();

        }
        internal void DutyDone(DateTime dutyDate, People people)
        {
            if (dal.QueryShiftItem(dutyDate, people.NID).Rows.Count > 0 && Is_Calc(dutyDate, people) == false)
            {
                dal.DutyDone(dutyDate, people);
            }
        }
        internal void DutyDone(DateTime dutyDate, int nid)
        {
            if (dal.QueryShiftItem(dutyDate, nid).Rows.Count > 0 && Is_Calc(dutyDate,nid) == false)
            {
                dal.DutyDone(dutyDate, nid);
            }
        }
        internal int AddShiftHistory(DateTime date, People p, double restValue)
        {
            return dal.AddShiftHistory(date, p.NID, restValue);
        }
        internal int AddShiftHistory(DateTime date, int nid, double restValue)
        {
            return dal.AddShiftHistory(date, nid, restValue);
        }
        internal int AddRestHistory(DateTime date, int nid, int restType,double restValue)
        {
            return dal.AddRestHistory(nid, date, restType, restValue);
        }
        /// <summary>
        /// 查询是不是已经计算过调休了。
        /// </summary>
        /// <param name="dutyDate"></param>
        /// <exception cref="参数错误，未找到匹配的值班表项"></exception>
        /// <returns></returns>
        internal bool Is_Calc(DateTime dutyDate, People p)
        {
            try
            {
                var b = dal.QueryIsCalc(dutyDate, p.NID);
                return b;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        internal bool Is_Calc(DateTime dutyDate, int nid)
        {
            try
            {
                var b = dal.QueryIsCalc(dutyDate, nid);
                return b;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public List<People> GetAllPeople()
        {
            var dt = dal.GetAllPeople();
            var list = _toEntityPeoples(dt);
            return list;
        }
        private List<People> _toEntityPeoples(DataTable dt)
        {
            List<People> list = new List<People>();
            foreach (DataRow dr in dt.Rows)
            {
                int id = dr.Field<int>("NID");
                string alias = dr.Field<string>("ALIAS_NAME");
                double dx = dr.Field<double>("DAOXIU_REMAIN");
                var p = new People()
                {
                    NID = id,
                    AliasName = alias,
                    DaoXiuRemain = dx
                };
                list.Add(p);
            }
            return list;
        }
        //休息记录的修改
        //事假修改为倒休=>减少该人员的倒休数量
        //事假修改为（年休假、算加班）=>不减少倒休数量
        /// <summary>
        /// 查看值班历史
        /// </summary>
        /// <param name="dateTime">此日期前后100天</param>
        /// <returns></returns>
        internal List<ShiftItem> GetShiftHistory(DateTime dateTime)
        {
            var dt = dal.GetShiftHistory(dateTime.AddDays(-100), dateTime.AddDays(100));
            return _toEntityShiftItems(dt);
        }
        private List<ShiftItem> _toEntityShiftItems(DataTable dt)
        {
            List<ShiftItem> list = new List<ShiftItem>();
            foreach (DataRow dr in dt.Rows)
            {
                DateTime dtime = dr.Field<DateTime>("SHIFT_DATE");
                int id = dr.Field<int>("ID");
                int nid = dr.Field<int>("NID");
                double rv = dr.Field<double>("REST_VALUE");
                bool iscalc = dr.Field<bool>("IS_CALC");
                string tag = dr.Field<string>("TAG");
                var p = new ShiftItem
                {
                    ID= id,
                    NID = nid,
                    ShiftDate = dtime,
                    RestValue = rv,
                    Is_Calc = iscalc,
                    Tag = tag
                };
                list.Add(p);
            }
            return list;
        }

        internal List<RestItem> GetRestView()
        {
            var dt = dal.GetRestHistoryView(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(60));
            return _toEntityRestItem_Partial(dt);
        }
        private List<RestItem> _toEntityRestItem_Partial(DataTable dt)
        {
            List<RestItem> list = new List<RestItem>();
            foreach (DataRow dr in dt.Rows)
            {
                int id = dr.Field<int>("ID");
                DateTime dtt = dr.Field<DateTime>("REST_DATE");
                string name = dr.Field<string>("ALIAS_NAME");
                string restText = dr.Field<string>("REST_TYPE_TEXT");
                double restValue = dr.Field<double>("REST_VALUE");

                var r = new RestItem() { ID = id, AliasName = name, RestDate = dtt, RestValue = restValue,  RestText = restText};
                list.Add(r);
            }
            return list;
        }


        /// <summary>
        /// 修改值班员
        /// </summary>
        /// <param name="si">原来的值班表项</param>
        /// <param name="nid">新的顶替的值班人的NameID</param>
        internal int ModifyPeopleShiftItem(ShiftItem si, int nid)
        {
            if (Is_Calc(si.ShiftDate, si.NID) == false)
            {
                return dal.ModifyPeopleInShiftItem(si.ID, nid);
            }
            else
            {
                return 0;
            }
        }
        internal int AddNewPeople(People people)
        {
            return dal.addNewPeople(people.AliasName, people.DaoXiuRemain);
        } 
        internal int DelPeople(People people)
        {
            return dal.DelPeople(people.NID);

        }
        internal int DelShiftItem(ShiftItem si)
        {
            if (Is_Calc(si.ShiftDate, si.NID) == false)
            {
                return dal.DelShiftHistoryByID(si.ID);
            }
            else
            {
                return 0;
            }
        }
        internal int ReBackDutyDone(ShiftItem si)
        {
            return dal.Un_DutyDone(si.ShiftDate,si.NID);
        }
        #endregion

       







    }
}
