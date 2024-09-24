using STROYMELL.Classes;
using STROYMELL.DB;
using STROYMELL.Pages.UserPage.HistoryTransactions;
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

namespace STROYMELL.Pages.UserPage.ProfilePageUser
{
    /// <summary>
    /// Логика взаимодействия для ProfilePageUser.xaml
    /// </summary>
    public partial class ProfilePageUser : Page
    {
        string login;
        public ProfilePageUser(string LOGIN)
        {
            InitializeComponent();
            this.login = LOGIN;
            LabelName.Text = "Профиль пользователя: " + Convert.ToString(login);
            var USER = DBConnection.DBCONNECT.Users.FirstOrDefault(name => name.Login == login);
            DateTime registrationDate = Convert.ToDateTime(USER.CreatedAt);
            string formattedDate = registrationDate.ToString("dd.MM.yyyy");
            LabelDate.Text = "Дата регистрации: " + formattedDate;
            LabelBalance.Text = "Баланс: " + USER.Balance;
        }
        private void Replenish_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.frame.Navigate(new ReplenishPageUser.ReplenishPageUser(login));
        }

        private void Conclusion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.frame.Navigate(new ConclusionPageUser.ConclusionPageUser(login));
        }

        private void HistoryOfTranzactions_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.frame.Navigate(new HistoryTransactions.HistoryTransactions(login));
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.frame.Navigate(new EditProfileUser.EditProfileUser());
        }
    }
}
