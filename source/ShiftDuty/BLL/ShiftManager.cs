using ShiftDuty.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ShiftDuty.BLL
{
    class ShiftManager
    {
        DAL.DAL_SD dal = new DAL.DAL_SD();
        public ShiftManager()
        {

        }
        /// <summary>
        /// 换班！
        /// </summary>
        /// <param name="dutyDate"></param>
        /// <param name="peopleWillBeOnDuty"></param>
        /// <returns></returns>
        internal int ChangeShift(DateTime dutyDate, Entities.People peopleOnDuty, Entities.People peopleWillBeOnDuty)
        {
            //上班记录修改
            List<People> peoplesOnDuty = WhosOnDuty(dutyDate);
            People OldName = peoplesOnDuty[0];
            if (peoplesOnDuty.Count ==0)
            {
                throw new Exception("换班失败，没有找到"+dutyDate.ToShortDateString()+"的值班员!");
            }
            else
            {
                if (Is_Calc(dutyDate, peopleOnDuty))
                {
                    //原来的名字的倒休数量去掉
                    _addDX(OldName, (-1) * QueryRestValue(dutyDate));
                    //改成现在要改的名字
                    _resetName(dutyDate, peopleWillBeOnDuty);

                    //is_calc置为假
                    _resetIsCalc(dutyDate, false);

                    //要防止读取错误，更改到一半死机等情况。
                    //现在的名字倒休数量加上去
                    _addDX(peopleWillBeOnDuty, QueryRestValue(dutyDate));
                    //is_calc置为真
                    _resetIsCalc(dutyDate, true);

                    //

                    //dutyDone应该写在BLL里面。私有的。
                    DutyDone(dutyDate,peopleWillBeOnDuty);
                    dal.DutyDone();

                }
                else//还没有计算过。直接改
                {
                    _resetName(dutyDate, peopleWillBeOnDuty);
                }
            }
            return 0;
        }

        private void _resetIsCalc(DateTime dutyDate, bool p)
        {
            throw new NotImplementedException();
        }

        private void _resetName(DateTime dutyDate, People people)
        {
            throw new NotImplementedException();
        }

        private void _addDX(People OldName, int p)
        {
            throw new NotImplementedException();
        }

        private int QueryRestValue(DateTime dutyDate)
        {
            throw new NotImplementedException();
        }


        internal DataTable RestHistoryView()
        {
            return dal.RestHistoryView();
        }

        #region 已经测试

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
            if (dal.QueryShiftItem(dutyDate, people).Rows.Count > 0 && Is_Calc(dutyDate, people) == false)
            {
                dal.DutyDone(dutyDate, people);
            }
        }

        internal int AddShiftHistory(DateTime date, People p, double restValue)
        {
            return dal.AddShiftHistory(date, p.NID, restValue);
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
                var b = dal.QueryIsCalc(dutyDate, p);
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


        internal List<ShiftItem> GetShiftHistory(DateTime dateTime)
        {
            var dt = dal.GetShiftHistory(dateTime, DateTime.Now);
            return _toEntityShiftItems(dt);
        }
        private List<ShiftItem> _toEntityShiftItems(DataTable dt)
        {
            List<ShiftItem> list = new List<ShiftItem>();
            foreach (DataRow dr in dt.Rows)
            {
                DateTime dtime = dr.Field<DateTime>("SHIFT_DATE");
                int nid = dr.Field<int>("NID");
                double rv = dr.Field<double>("REST_VALUE");
                bool iscalc = dr.Field<bool>("IS_CALC");
                string tag = dr.Field<string>("TAG");
                var p = new ShiftItem
                {
                    NID = nid,
                    RestDate = dtime,
                    RestValue = rv,
                    Is_Calc = iscalc,
                    Tag = tag
                };
                list.Add(p);
            }
            return list;
        }


        #endregion
    }
}
