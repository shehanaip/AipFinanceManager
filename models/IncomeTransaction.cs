using LiteDB;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIp_Finance_Management__personal_.Models
{
    internal class IncomeTransaction
    {
        public int Id
        {
            get;
            set;
        }
        public string TransactionCode
        {
            get;
            set;
        }
        public string PaymentFrom
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        [BsonRef("accounts")]
        public Account Account
        {
            get;
            set;
        }
        [BsonRef("income_categories")]
        public IncomeCategory Category
        {
            get;
            set;
        }
        public double Amount
        {
            get;
            set;
        }
       
        public DateTime Date { get; set; }


      
    }

    
}
