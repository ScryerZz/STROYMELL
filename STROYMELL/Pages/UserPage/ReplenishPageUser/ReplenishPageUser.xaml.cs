using STROYMELL.DB;
using STROYMELL.Pages.UserPage.ProfilePageUser;
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

namespace STROYMELL.Pages.UserPage.ReplenishPageUser
{
    /// <summary>
    /// Логика взаимодействия для ReplenishPageUser.xaml
    /// </summary>
    public partial class ReplenishPageUser : Page
    {
        string login;
        public ReplenishPageUser(string LOGIN)
        {
            InitializeComponent();
            this.login = LOGIN;
        }

        private void GoBackbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Replenich_Click(object sender, RoutedEventArgs e)
        {
            if (SBPCheckBox.IsChecked == true)
            {
                if (Convert.ToInt32(SummTxt.Text) < 100)
                {
                    minsumm.Foreground = Brushes.Red;
                    SummTxt.BorderBrush = Brushes.Red;
                }
                else
                {
                    var tempUser = DBConnection.DBCONNECT.Users.FirstOrDefault(user => user.Login == login);
                    int plusbal = (int)tempUser.Balance;
                    tempUser.Balance = plusbal + Convert.ToInt32(SummTxt.Text);
                    DBConnection.DBCONNECT.SaveChanges();
                    var tempTransaction = new Transactions() { ID_User = tempUser.ID_User, CreatedAt = DateTime.Today };
                    DBConnection.DBCONNECT.Transactions.Add(tempTransaction);

                    var tempReplenishment = new FundsDeposits()
                    {
                        ID_Transaction = tempTransaction.ID_Transaction,
                        TypeTransaction = "Пополнение",
                        Amount = Convert.ToInt32(SummTxt.Text)
                    };
                    DBConnection.DBCONNECT.FundsDeposits.Add(tempReplenishment);
                    DBConnection.DBCONNECT.SaveChanges();

                    MainWindow.Instance.frame.Navigate(new ProfilePageUser.ProfilePageUser(login));
                }
            }
            else
            {
                MessageBox.Show("Выберите способ оплаты!!");
            }
        }

        private void SummTxt_SelectionChanged(object sender, RoutedEventArgs e)
        {
            minsumm.Foreground = Brushes.Gray;
            SummTxt.BorderBrush = Brushes.Gray;
        }
    }
}
