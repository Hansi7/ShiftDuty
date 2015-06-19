using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShiftDuty.Entities
{
    public class ShiftItem
    {
        public int NID { get; set; }
        public string AliasName { get; set; }
        public DateTime RestDate { get; set; }
        public string Tag { get; set; }

    }
}
