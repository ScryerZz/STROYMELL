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

namespace STROYMELL.Pages.UserPage.AllGames
{
    /// <summary>
    /// Логика взаимодействия для AllGamesUser.xaml
    /// </summary>
    public partial class AllGamesUser : Page
    {
        string login;
        public AllGamesUser(string LOGIN)
        {
            InitializeComponent();
            this.login = LOGIN;
        }

        private void Game1Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.frame.Navigate(new GameLuckyJet.GameLuckyJet(login));
        }
    }
}
