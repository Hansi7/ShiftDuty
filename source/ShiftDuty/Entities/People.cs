using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShiftDuty.Entities
{
    public class People
    {
        public int NID { get; set; }
        public string AliasName { get; set; }
        public double DaoXiuRemain { get; set; }
        public override bool Equals(object obj)
        {
            People oP = obj as People;
            if (this.NID==oP.NID && this.AliasName == oP.AliasName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return this.NID.GetHashCode() + this.AliasName.GetHashCode();
        }
    }
}
