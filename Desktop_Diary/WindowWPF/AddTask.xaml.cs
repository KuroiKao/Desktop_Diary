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
using Desktop_Diary.Model;

namespace Desktop_Diary.WindowWPF
{
    /// <summary>
    /// Логика взаимодействия для AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        private readonly UserIdNow _userID = new(default);
        public AddTask(UserIdNow userID)
        {
            InitializeComponent();
            _userID = userID;            
        }
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            BaseContext.Task task = new BaseContext.Task();
            string head = TextHeader.Text;
            string descrip = TextDescription.Text;
            DateTime datecomp = DataPick.SelectedDate.Value.Date;
            task.Header = head;
            task.Description = descrip;
            task.DateCompletion = datecomp;
            task.DateCreation = DateTime.Now;
            task.UserId = _userID.UserID;
            SingletonBase.GetInstance().Tasks.Add(task);
            SingletonBase.GetInstance().SaveChanges();
            DialogResult = true;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
