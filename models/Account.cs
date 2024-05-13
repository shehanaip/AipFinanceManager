using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace AIp_Finance_Management__personal_.Models
{
    public class Account
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

        public static implicit operator int(Account v)
        {
            throw new NotImplementedException();
        }
    }
}
