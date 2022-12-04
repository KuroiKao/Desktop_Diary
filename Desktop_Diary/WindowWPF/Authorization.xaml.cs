using Desktop_Diary.BaseContext;
using Desktop_Diary.Model;
using Microsoft.EntityFrameworkCore;
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

namespace Desktop_Diary.WindowWPF
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private UserIdNow _userID = new(default);
        public Authorization()
        {
            InitializeComponent();
            
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            string log = textBoxLogin.Text.ToLower().Trim();
            string pass = PassBox.Password.Trim();

            User authUser = null;
            authUser = SingletonBase.GetInstance().Users.SingleOrDefault(x => x.Login == log && x.Password == pass);            
            var userNow = SingletonBase.GetInstance().Users.SingleOrDefault(x => x.Login == log).UserId;
            _userID.UserID = userNow;

            if (authUser != null)
            {
                MessageBox.Show($"Добро пожаловать!");
                MainTask mainDiary = new MainTask(_userID);
                mainDiary.Show();
                Close();
                PassBox.Background = Brushes.Transparent;
                PassBox.ToolTip = null;
            }
            else
            {
                PassBox.ToolTip = "Некорректный ввод!";
                PassBox.Background = Brushes.DarkRed;
            }
        }

        private void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
    }
}
