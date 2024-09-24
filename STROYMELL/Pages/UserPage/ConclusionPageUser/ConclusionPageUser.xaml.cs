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

namespace STROYMELL.Pages.UserPage.ConclusionPageUser
{
    /// <summary>
    /// Логика взаимодействия для ConclusionPageUser.xaml
    /// </summary>
    public partial class ConclusionPageUser : Page
    {
        string login;
        public ConclusionPageUser(string LOGIN)
        {
            InitializeComponent();
            this.login = LOGIN;
            var USER = DBConnection.DBCONNECT.Users.FirstOrDefault(name => name.Login == login);
            Balance.Text = "БАЛАНС: " + USER.Balance;
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
                    int minusbal = (int)tempUser.Balance;
                    if ((minusbal - Convert.ToInt32(SummTxt.Text)) >= 0)
                    {
                        tempUser.Balance = minusbal - Convert.ToInt32(SummTxt.Text);
                        DBConnection.DBCONNECT.SaveChanges(); // Сохраняем изменения в клиенте

                        var tempTransaction = new Transactions()
                        {
                            ID_User = tempUser.ID_User,
                            CreatedAt = DateTime.Today
                        };
                        DBConnection.DBCONNECT.Transactions.Add(tempTransaction);
                        DBConnection.DBCONNECT.SaveChanges(); // Сохраняем изменения, чтобы получить Id_Transaction

                        // Теперь создаем вывод, используя правильный Id_Transaction
                        var tempWithdrawal = new FundsWithdrawals()
                        {
                            ID_Transaction = tempTransaction.ID_Transaction, // Используем Id_Transaction после сохранения
                            TypeTransaction = "Вывод",
                            Amount = Convert.ToDouble(SummTxt.Text)// Убедитесь, что тип совпадает
                        };
                        DBConnection.DBCONNECT.FundsWithdrawals.Add(tempWithdrawal);

                        // Сохраняем изменения
                        DBConnection.DBCONNECT.SaveChanges();

                        // Переход к странице профиля
                        MainWindow.Instance.frame.Navigate(new ProfilePageUser.ProfilePageUser(login));
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно средств для оплаты!!");
                    }
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
