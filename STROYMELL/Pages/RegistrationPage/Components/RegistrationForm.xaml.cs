using STROYMELL.DB;
using STROYMELL.Pages.UserPage.HomePage;
using STROYMELL.SideBarPages;
using STROYMELL.SideBarPages.Admin;
using STROYMELL.SideBarPages.User;
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

namespace STROYMELL.Pages.RegistrationPage.Components
{
    /// <summary>
    /// Логика взаимодействия для RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Page
    {
        public string LOGIN { get; set; }
        public RegistrationForm()
        {
            InitializeComponent();
        }
        private void ButtonNav_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignInForm());
        }

        private void CheckBoxAdmin_Checked(object sender, RoutedEventArgs e)
        {
            LabelKeyAdmin.Visibility = Visibility.Visible;
            KeyAdminTxtBox.Visibility = Visibility.Visible;
        }
        private void CheckBoxAdmin_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelKeyAdmin.Visibility = Visibility.Hidden;
            KeyAdminTxtBox.Visibility = Visibility.Hidden;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string LoginUser = LoginTxtBox.Text;
            var USER = DBConnection.DBCONNECT.Users.FirstOrDefault(name => name.Login == LoginUser);
            if (USER != null)
            {
                MessageBox.Show("ТАКОЙ ЛОГИН НЕ СУЩЕСТВУЕТ!");
            }
            else if (LoginUser == "" || PasswordTxtBox.Text == "")
            {
                MessageBox.Show("ЗАПОЛНИТЕ ВСЕ ПОЛЯ!");
            }
            else if (CheckBoxAdmin.IsChecked == true)
            {
                if (KeyAdminTxtBox.Text == "322")
                {
                    DateTime today = DateTime.Today;
                    string dd = today.Day.ToString();
                    string mm = today.Month.ToString();
                    string yy = today.Year.ToString();
                    var tempAdmin = new Users() { Login = LoginTxtBox.Text, Password = PasswordTxtBox.Text, ID_Role = 1, Balance = 0, CreatedAt = Convert.ToDateTime(yy + "." + mm + "." + dd) };
                    DBConnection.DBCONNECT.Users.Add(tempAdmin);
                    DBConnection.DBCONNECT.SaveChanges();
                    LOGIN = LoginTxtBox.Text;
                    MainWindow.Instance.FrameSideBar.Navigate(new SideBarMenuAdmin(LOGIN));
                    MainWindow.Instance.frame.Navigate(new HomePage());
                    return;
                }
                else
                {
                    MessageBox.Show("НЕВЕРНЫЙ КЛЮЧ!");
                }
            }
            else if (CheckBoxAdmin.IsChecked != true)
            {

                DateTime today = DateTime.Today;
                string dd = today.Day.ToString();
                string mm = today.Month.ToString();
                string yy = today.Year.ToString();
                var tempUser = new Users() { Login = LoginTxtBox.Text, Password = PasswordTxtBox.Text, ID_Role = 2, Balance = 0, CreatedAt = Convert.ToDateTime(yy + "." + mm + "." + dd) };
                DBConnection.DBCONNECT.Users.Add(tempUser);
                DBConnection.DBCONNECT.SaveChanges();
                LOGIN = LoginTxtBox.Text;
                MainWindow.Instance.FrameSideBar.Navigate(new SideBarMenu(LOGIN));
                MainWindow.Instance.frame.Navigate(new HomePage());
                return;
            }
        }
    }
}
