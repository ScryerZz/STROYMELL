using STROYMELL.Classes;
using STROYMELL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STROYMELL.Pages.UserPage.HistoryTransactions
{
    /// <summary>
    /// Логика взаимодействия для HistoryTransactions.xaml
    /// </summary>
    public partial class HistoryTransactions : Page
    {
        string login;
        public HistoryTransactions(string LOGIN)
        {
            InitializeComponent();
            this.login = LOGIN;
            LoadTransactionHistory();
        }
        private void GoBackbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LoadTransactionHistory()
        {
            int userId = DBConnection.DBCONNECT.Users.FirstOrDefault(user => user.Login == login).ID_User;
            var transactionHistoryRaw = (from transaction in DBConnection.DBCONNECT.Transactions
                                         where transaction.ID_User == userId
                                         join withdrawal in DBConnection.DBCONNECT.FundsWithdrawals on transaction.ID_Transaction equals withdrawal.ID_Transaction into withdrawals
                                         from withdrawal in withdrawals.DefaultIfEmpty()
                                         join replenishment in DBConnection.DBCONNECT.FundsDeposits on transaction.ID_Transaction equals replenishment.ID_Transaction into replenishments
                                         from replenishment in replenishments.DefaultIfEmpty()
                                         select new
                                         {
                                             ID_Transaction = transaction.ID_Transaction,
                                             Name_Transaction = withdrawal != null ? withdrawal.TypeTransaction : (replenishment != null ? replenishment.TypeTransaction : "Неизвестная транзакция"),
                                             Sum_of_transaction = withdrawal != null ? withdrawal.Amount : (replenishment != null ? replenishment.Amount : 0),
                                             Date = transaction.CreatedAt,
                                         }).ToList();

            var transactionHistory = transactionHistoryRaw.Select(th => new Classes.HistoryTransactions
            {
                ID_Transaction = th.ID_Transaction,
                Name_Transaction = th.Name_Transaction,
                Withdrawal_Amount = Convert.ToDecimal(th.Sum_of_transaction),
                Date = Convert.ToDateTime(th.Date),
            }).ToList();

            ListHistoryGames.ItemsSource = transactionHistory;
        }
    }
}
