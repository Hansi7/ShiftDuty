using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShiftDuty.Entities
{
    public class ShiftItem
    {
        public int ID { get; set; }
        public int NID { get; set; }
        public DateTime ShiftDate { get; set; }
        public double RestValue { get; set; }
        public bool Is_Calc { get; set; }
        public string Tag { get; set; }
    }
}
