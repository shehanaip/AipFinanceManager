using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using System.Threading.Tasks;

namespace AIp_Finance_Management__personal_.Models
{
    public class IncomeCategory
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public static implicit operator int(IncomeCategory v)
        {
            throw new NotImplementedException();
        }
    }
}
