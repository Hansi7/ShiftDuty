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
        List<People> GetAllPeople()
        {
            List<People> list = new List<People>();
            var dt = dal.GetAllPeople();

            foreach (DataRow dr in dt.Rows)
            {
                People p = new People()
                {
                    NID = dr.Field<long>("NID"),
                    AliasName = dr.Field<string>("ALIAS_NAME"),
                    RestRemain = dr.Field<Single>("DAOXIU_REMAIN")
                };
                list.Add(p);
            }
            return list;
        }

    }
}
