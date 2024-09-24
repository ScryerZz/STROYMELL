using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STROYMELL.Classes
{
    internal class HistoryTransactions
    {
        public int ID_Transaction { get; set; } // ID транзакции
        public string Name_Transaction { get; set; } // Имя операции
        public decimal Withdrawal_Amount { get; set; } // Сумма вывода
        public DateTime Date { get; set; } // Дата
    }
}
