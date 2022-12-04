using Desktop_Diary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Desktop_Diary.ViewModel
{
    class TaskListView
    {
        private ICommand m_RowClickCommand;
        ICommand m_RowRemoveCommand;
        ObservableCollection<Element> _list;

        public TaskListView()
        {

        }
        public Element SelectedData { get; set; }
        public ICommand RowClickCommand
        {
            get
            {
                if (m_RowClickCommand == null)
                {
                    m_RowClickCommand = new DelegateCommand(CanClickRow, ClickRow);
                }
                return m_RowClickCommand;
            }
        }

        private void ClickRow(object parameter)
        {
            var set = this.SelectedData;
            if (set != null)
            {
                MessageBox.Show(set.Header, "Header");
            }
        }
        public ObservableCollection<Element> TaskList
        {
            get
            {
                if (_list == null)
                {
                    _list = new ObservableCollection<Element>();
                    _list.Add(new Element() { Header = "Task 1", Description = "Test task1", Datecompl = DateTime.Parse("5/12/2022") });
                    _list.Add(new Element() { Header = "Task 2", Description = "Test task2", Datecompl = DateTime.Parse("5/12/2022") });
                    _list.Add(new Element() { Header = "Task 3", Description = "Test task3", Datecompl = DateTime.Parse("5/12/2022") });
                    _list.Add(new Element() { Header = "Task 4", Description = "Test task4", Datecompl = DateTime.Parse("5/12/2022") });
                }
                return _list;
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                if (m_RowRemoveCommand == null)
                {
                    m_RowRemoveCommand = new DelegateCommand(CanRemoveRow, RemoveRow);
                }
                return m_RowRemoveCommand;
            }
        }
        private void RemoveRow(object parameter)
        {
            int index = TaskList.IndexOf(parameter as Element);
            if (index > -1 && index < TaskList.Count)
            {
                TaskList.RemoveAt(index);
            }
        }

        private bool CanClickRow(object parameter)
        {
            return true;
        }
        private bool CanRemoveRow(object parameter)
        {
            return true;
        }
    }
}
