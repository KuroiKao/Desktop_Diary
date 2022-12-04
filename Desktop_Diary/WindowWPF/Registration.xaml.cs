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
using System.Windows.Shapes;
using Desktop_Diary.BaseContext;
using Microsoft.EntityFrameworkCore;

namespace Desktop_Diary.WindowWPF
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            string name = TextName.Text;
            string log = TextLogin.Text;
            string pass = PassBox.Password;
            string pass2 = PassBox2.Password;

            static bool CheckPass(string pass, string pass2) =>
            pass.Length >= 5
            && pass == pass2;
            static bool CheckLogin(string log) =>
            log.Length >= 4
            && log.Any(char.IsLetter);
            User authUser = null;
            authUser = SingletonBase.GetInstance().Users.SingleOrDefault(x => x.Login == log);
            if (name != null)
            {
                user.Name = TextName.Text;
            }
            else
            {
                MessageBox.Show("Некорректное имя!");
            }

            if (log != null)
            {
                if (CheckLogin(log) == false)
                {
                    MessageBox.Show("Некорректный логин!");
                }
                else
                {
                    user.Login = TextLogin.Text;
                }
            }

            if ((pass != null) && (pass2 != null))
            {
                if ((CheckPass(pass, pass2) == false) && (pass == pass2))
                {
                    PassBox.Background = Brushes.DarkRed;
                    PassBox2.Background = Brushes.DarkRed;
                    MessageBox.Show("Пароли не совпадают!");
                }
                else
                {
                    user.Password = PassBox.Password;
                    PassBox.Background = Brushes.Transparent;
                }
            }
            SingletonBase.GetInstance().Users.Add(user);
            SingletonBase.GetInstance().SaveChanges();
            Close();
        }
    }
}
