using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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
using Microsoft.EntityFrameworkCore;

namespace Desktop_Diary.WindowWPF
{
    /// <summary>
    /// Логика взаимодействия для MainTask.xaml
    /// </summary>

    public partial class MainTask : Window
    {
        private readonly UserIdNow _userID = new(default);

        public MainTask(UserIdNow userID)
        {
            InitializeComponent();
            _userID = userID;
            
        }
        void Update()
        {
            TaskListToday.ItemsSource = SingletonBase.GetInstance().Tasks.Where(x => x.DateCompletion == DateTime.Today && x.UserId == _userID.UserID).ToList();
            TaskListNextDay.ItemsSource = SingletonBase.GetInstance().Tasks.Where(x => x.DateCompletion == DateTime.Today.AddDays(1) && x.UserId == _userID.UserID).ToList();
            TaskListAll.ItemsSource = SingletonBase.GetInstance().Tasks.Where(x => x.UserId == _userID.UserID).ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
        
        //private void Button_Click_Deleted(object sender, RoutedEventArgs e)
        //{
        //    if (TabToday.IsFocused == true)
        //    {
        //        if (TaskListToday.SelectedItem is BaseContext.Task task)
        //        {
        //            MessageBox.Show($"{task.Header}{task.Description}");
        //        }
        //    }
        //    if (TabNextDay.Focus() == true)
        //    {
        //        if (TaskListNextDay.SelectedItem is BaseContext.Task task1)
        //        {
        //            MessageBox.Show($"{task1.Header}{task1.Description}");
        //        }
        //    }
        //    if (TabAll.Focus() == true)
        //    {
        //        if (TaskListAll.SelectedItem is BaseContext.Task task3)
        //        {
        //            MessageBox.Show($"{task3.Header}{task3.Description}");
        //        }
                
        //    }
        //}

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (SingletonBase.GetInstance().SaveChanges() == 1)
            {
                MessageBox.Show("Сохранено");
                Update();
            }            
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            AddTask addTask = new AddTask(_userID);
            if (addTask.ShowDialog() == true)
                Update();
        }        
    }
}
