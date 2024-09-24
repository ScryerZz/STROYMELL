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
using System.Windows.Threading;

namespace STROYMELL.Pages.UserPage.GameLuckyJet
{
    /// <summary>
    /// Логика взаимодействия для GameLuckyJet.xaml
    /// </summary>
    public partial class GameLuckyJet : Page
    {
        string login;
        private DispatcherTimer timer;
        private double multiplier;
        private bool isRunning;
        private Random random;
        private double crashPoint;
        private double verticalSpeed;
        private bool movingUp;
        double Bet;
        double Balance;
        double WinSumm;
        public GameLuckyJet(string LOGIN)
        {
            InitializeComponent();
            this.login = LOGIN;
            multiplier = 1.0;
            isRunning = false;
            random = new Random();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            verticalSpeed = 3.0;
            movingUp = true;
            var USER = DBConnection.DBCONNECT.Users.FirstOrDefault(name => name.Login == login);
            UserBalance.Text = Convert.ToString(USER.Balance);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var USER = DBConnection.DBCONNECT.Users.FirstOrDefault(name => name.Login == login);
            Balance = Convert.ToDouble(USER.Balance);
            Bet = Convert.ToInt32(BetSumm.Text);
            if (Bet < Balance)
            {
                if (!isRunning)
                {
                    isRunning = true;
                    multiplier = 1.0;
                    crashPoint = random.NextDouble() * 10 + 1;
                    timer.Start();
                    USER.Balance = Math.Round(Balance - Bet, 2);
                    UserBalance.Text = Convert.ToString(USER.Balance);
                }
            }
            else
            {
                MessageBox.Show("НЕДОСТАТОЧНО СРЕДСТВ!");
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                timer.Stop();
                WinSumm = Bet * multiplier;
                MessageBox.Show($"ВЫ ВЫБИЛИ: {multiplier:F2}x!\nВАШ ВЫИГРЫШ: {WinSumm}");
                var USER = DBConnection.DBCONNECT.Users.FirstOrDefault(name => name.Login == login);
                USER.Balance = Math.Round(Balance + (WinSumm), 2);
                DBConnection.DBCONNECT.SaveChanges();
                UserBalance.Text = Convert.ToString(USER.Balance);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            multiplier += 0.1;
            MultiplierLabel.Text = $"{multiplier:F2}x";

            if (multiplier >= crashPoint)
            {
                timer.Stop();
                isRunning = false;
                MessageBox.Show($"CRASH! YOU LOST..\nВЫ ПРОИГРАЛИ: {Bet}");
            }

            var currentMargin = JetHeroImg.Margin;

            if (movingUp)
            {
                JetHeroImg.Margin = new Thickness(currentMargin.Left, currentMargin.Top - verticalSpeed, currentMargin.Right, currentMargin.Bottom);
                if (JetHeroImg.Margin.Top <= 473)
                {
                    movingUp = false;
                }
            }
            else
            {
                JetHeroImg.Margin = new Thickness(currentMargin.Left, currentMargin.Top + verticalSpeed, currentMargin.Right, currentMargin.Bottom);
                if (JetHeroImg.Margin.Top >= 415)
                {
                    movingUp = true;
                }
            }
        }
    }
}
