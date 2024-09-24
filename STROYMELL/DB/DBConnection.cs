using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STROYMELL.DB
{
    internal class DBConnection
    {
        public static casinoEntities DBCONNECT = new casinoEntities();
        public static Users Users;
        public static FundsWithdrawals FundsWithdrawals;
        public static Transactions Transactions;
        public static FundsDeposits FundsDeposits;
    }
}
