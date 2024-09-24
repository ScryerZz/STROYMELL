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

namespace STROYMELL.SideBarPages.Admin
{
    /// <summary>
    /// Логика взаимодействия для SideBarMenuAdmin.xaml
    /// </summary>
    public partial class SideBarMenuAdmin : Page
    {
        string login;
        public SideBarMenuAdmin(string LOGIN)
        {
            InitializeComponent();
            this.login = LOGIN;
            Profile.Content = "ПРОФИЛЬ";
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
