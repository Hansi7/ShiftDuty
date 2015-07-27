using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShiftDuty.Entities
{
    public class RestItem
    {
        public int NID { get; set; }
        public string AliasName { get; set; }
        public DateTime RestDate { get; set; }
        public int RestType { get; set; }
    }
}
