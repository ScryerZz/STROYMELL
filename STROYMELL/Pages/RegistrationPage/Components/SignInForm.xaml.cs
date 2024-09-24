using STROYMELL.DB;
using STROYMELL.SideBarPages;
using STROYMELL.SideBarPages.Admin;
using STROYMELL.Pages;
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
using STROYMELL.Pages.UserPage.HomePage;
using STROYMELL.SideBarPages.User;

namespace STROYMELL.Pages.RegistrationPage.Components
{
    /// <summary>
    /// Логика взаимодействия для SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Page
    {
        public SignInForm()
        {
            InitializeComponent();
        }
        private void ButtonNav_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationForm());
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string LoginUser = LoginTxtBox.Text;
            var USER = DBConnection.DBCONNECT.Users.FirstOrDefault(name => name.Login == LoginUser);

            if (USER == null)
            {
                MessageBox.Show("ТАКОЙ ЛОГИН НЕ СУЩЕСТВУЕТ!");
            }
            else if (USER.Password != PasswordTxtBox.Text)
            {
                MessageBox.Show("НЕВЕРНЫЙ ПАРОЛЬ!");
            }
            else
            {
                MessageBox.Show("ВХОД ВЫПОЛНЕН УСПЕШНО!");
                if (Convert.ToString(USER.Roles.ID_Role) == "1")
                {
                    MainWindow.Instance.FrameSideBar.Navigate(new SideBarMenuAdmin(USER.Login));
                    MainWindow.Instance.frame.Navigate(new HomePage());
                }
                else
                {
                    MainWindow.Instance.FrameSideBar.Navigate(new SideBarMenu(USER.Login));
                    MainWindow.Instance.frame.Navigate(new HomePage());
                }
            }
        }
    }
}
