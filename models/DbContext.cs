using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using System.Threading.Tasks;

namespace AIp_Finance_Management__personal_.Models
{
     public class DbContext
    {
        static LiteDatabase _instance;
        public static void Init(string fileNme)
        {
            _instance = new LiteDatabase(fileNme);
        }
        public static LiteDatabase GetInstance()
        {
            return _instance;
        }
    }
}
