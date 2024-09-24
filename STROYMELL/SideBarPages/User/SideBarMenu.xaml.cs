using STROYMELL.Pages.RegistrationPage.Components;
using STROYMELL.Pages.UserPage.HomePage;
using STROYMELL.Pages.UserPage.AllGames;
using STROYMELL.Pages.UserPage.ProfilePageUser;
using STROYMELL.SideBarPages.Admin;
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

namespace STROYMELL.SideBarPages.User
{
    /// <summary>
    /// Логика взаимодействия для SideBarMenu.xaml
    /// </summary>
    public partial class SideBarMenu : Page
    {
        string login;

        public SideBarMenu(string login)
        {
            InitializeComponent();
            this.login = login;
            Profile.Content = "ПРОФИЛЬ";
        }

        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Balance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.frame.Navigate(new ProfilePageUser(login));
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.frame.Navigate(new HomePage());
        }

        private void AllGames_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.frame.Navigate(new AllGamesUser(login));
        }
    }
}
