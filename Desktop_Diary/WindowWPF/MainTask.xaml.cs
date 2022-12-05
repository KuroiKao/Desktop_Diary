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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        private void Button_Click_Deleted(object sender, RoutedEventArgs e)
        {
            TabItem tabSelect = TabF.SelectedItem as TabItem;            
               
            if (TaskListToday.SelectedItem is BaseContext.Task gridSelectToday && tabSelect == TabToday)
            {
                MessageBox.Show($"Запись {gridSelectToday.Header} успешно удалена!");
                SingletonBase.GetInstance().Tasks.Remove(gridSelectToday);
                SingletonBase.GetInstance().SaveChanges();
                Update();
            }
            if (TaskListNextDay.SelectedItem is BaseContext.Task gridSelectNextDay && tabSelect == TabNextDay)
            {
                MessageBox.Show($"Запись {gridSelectNextDay.Header} успешно удалена!");
                SingletonBase.GetInstance().Tasks.Remove(gridSelectNextDay);
                SingletonBase.GetInstance().SaveChanges();
                Update();
            }

            if (TaskListAll.SelectedItem is BaseContext.Task gridSelectAll && tabSelect == TabAll)
            {
                MessageBox.Show($"Запись {gridSelectAll.Header} успешно удалена!");
                SingletonBase.GetInstance().Tasks.Remove(gridSelectAll);
                SingletonBase.GetInstance().SaveChanges();
                Update();
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (SingletonBase.GetInstance().SaveChanges() == 1)
            {                
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
