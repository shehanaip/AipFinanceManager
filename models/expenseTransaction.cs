using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIp_Finance_Management__personal_.Models
{
    internal class expenseTransaction
    {
        public int Id
        {
            get;
            set;
        }
        public int TransactionCode
        {
            get;
            set;
        }
        public string PaymenTo
        {
            get;
            set;
        }
        public int Description
        {
            get;
            set;
        }
        [BsonRef("accounts")]
        public int Account
        {
            get;
            set;
        }
        [BsonRef("expense_categories")]
        public int Category
        {
            get;
            set;
        }
        public double Amount
        {
            get;
            set;
        }
        public int TransactionCost
        {
            get;
            set;
        }
        public int Date
        {
            get;
            set;
        }
    }
}
