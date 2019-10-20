using ScheduleUp.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ScheduleUpV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TaskTable> todoTaskTable = new List<TaskTable>();
        List<TaskTable> inpTaskTable = new List<TaskTable>();
        List<TaskTable> doneTaskTable = new List<TaskTable>();

        private UserTable parameter;

        public UserTable Parameter
        {
            get;
            set;
        }
        public MainWindow(UserTable parameter) : this()
        {
            InitializeComponent();
            this.parameter = parameter;

            signedAsLabel.Content = "Signed As : " + parameter.userName;

            ScheduleUpDBEntities context = new ScheduleUpDBEntities();

            TaskTable tb = new TaskTable() //test data ekleme
            {
                TaskID = Guid.NewGuid(),
                TaskContent = "intest",
                TaskAssignedTo = "26C741D5-1758-4CA7-B802-85BFAF64B587",
                TaskCreator = "26C741D5-1758-4CA7-B802-85BFAF64B587",
                TaskEndDate = new DateTime(1995, 10, 20),
                TaskStartDate = new DateTime(1995, 10, 21),
                TaskTitle = "test",
                TaskStatu = "Todo"
            };
            context.TaskTable.Add(tb);
            context.SaveChanges();

            var TotalTaskList = context.TaskTable.Where(x => x.TaskAssignedTo == parameter.userID.ToString()).ToList();

            #region Task Tablolarını Doldurur
            var todoTaskList = TotalTaskList.Where(x => x.TaskStatu.ToUpper() == "TODO" || x.TaskStatu.ToUpper() == "INPROGRESS").ToList();
            foreach (var todoTask in todoTaskList)
            {
                todoTaskTable.Add(todoTask);
            }

            todogrid.ItemsSource = todoTaskTable;




            var doneTaskList = TotalTaskList.Where(x => x.TaskStatu.ToUpper() == "DONE").ToList();
            foreach (var doneTask in doneTaskList)
            {
                doneTaskTable.Add(doneTask);
            }
            donegrid.ItemsSource = doneTaskTable;
            #endregion
        }

        public MainWindow()
        {
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            TaskTable selectedTask = (TaskTable)todogrid.SelectedItem;
            if (selectedTask != null)
            {
                using (var context = new ScheduleUpDBEntities())
                {
                    context.Entry(selectedTask).State = EntityState.Deleted;
                    context.SaveChanges();
                }

                todoTaskTable.Remove(selectedTask);
                todogrid.ItemsSource = null;
                todogrid.ItemsSource = todoTaskTable;
            }
            else
            {
                var message = "You didn't pick any task";
                if ((TaskTable)donegrid.SelectedItem != null)
                    message = "Can not delete task in \"DONE\" status. Please change task status as \"ToDo\" or \"InProgress\" and try deleting again.";

                MessageBox.Show(message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void todo_button_Click(object sender, RoutedEventArgs e)
        {
            TaskTable selectedTask = (TaskTable)todogrid.SelectedItem;

            if (selectedTask == null)
            {
                selectedTask = (TaskTable)donegrid.SelectedItem;
                doneTaskTable.Remove(selectedTask);
                donegrid.ItemsSource = null;
                donegrid.ItemsSource = doneTaskTable;
            }
            else
            {
                todoTaskTable.Remove(selectedTask);
            }

            if (selectedTask != null)
            {
                if (selectedTask.TaskStatu.ToUpper() == "TODO")
                {
                    var message = "Selected Task Statu Already \"ToDo\"";
                    MessageBox.Show(message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    using (var context = new ScheduleUpDBEntities())
                    {
                        var updateTask = context.TaskTable.Where(x => x.TaskID == selectedTask.TaskID).FirstOrDefault();
                        updateTask.TaskStatu = "ToDo";
                        context.SaveChanges();

                        todoTaskTable.Add(updateTask);
                        todogrid.ItemsSource = null;
                        todogrid.ItemsSource = todoTaskTable;
                    }
                }

            }
            else
            {
                var message = "You didn't pick any task";
                MessageBox.Show(message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void inprogress_button_Click(object sender, RoutedEventArgs e)
        {
            TaskTable selectedTask = (TaskTable)todogrid.SelectedItem;

            if (selectedTask == null)
            {
                selectedTask = (TaskTable)donegrid.SelectedItem;
                doneTaskTable.Remove(selectedTask);
                donegrid.ItemsSource = null;
                donegrid.ItemsSource = doneTaskTable;
            }
            else
            {
                todoTaskTable.Remove(selectedTask);
            }
            if (selectedTask != null)
            {
                if (selectedTask.TaskStatu.ToUpper() == "INPROGRESS")
                {
                    var message = "Selected Task Statu Already \"InProgress\"";
                    MessageBox.Show(message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    using (var context = new ScheduleUpDBEntities())
                    {
                        var updateTask = context.TaskTable.Where(x => x.TaskID == selectedTask.TaskID).FirstOrDefault();
                        updateTask.TaskStatu = "InProgress";
                        context.SaveChanges();
                        todoTaskTable.Add(updateTask);
                        todogrid.ItemsSource = null;
                        todogrid.ItemsSource = todoTaskTable;
                    }
                }

            }
            else
            {
                var message = "You didn't pick any task";
                MessageBox.Show(message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void done_button_Click(object sender, RoutedEventArgs e)
        {
            TaskTable selectedTask = (TaskTable)todogrid.SelectedItem;
            todoTaskTable.Remove(selectedTask);

            if (selectedTask != null)
            {
                using (var context = new ScheduleUpDBEntities())
                {
                    var updateTask = context.TaskTable.Where(x => x.TaskID == selectedTask.TaskID).FirstOrDefault();
                    updateTask.TaskStatu = "Done";
                    context.SaveChanges();
                    doneTaskTable.Add(updateTask);
                }
                todogrid.ItemsSource = null;
                todogrid.ItemsSource = todoTaskTable;

                donegrid.ItemsSource = null;
                donegrid.ItemsSource = doneTaskTable;
            }
            else
            {
                var message = "Nothing Selected From Active Tasks Table";
                MessageBox.Show(message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //text box'a tıklandıgında placeholder'ın kaybolmasını sağlar.
        private void filterFocusEvent(object sender, RoutedEventArgs e)
        {
            filterBox.Text = "";
        }

        //Grid içerisindeki dataları girilen anahtar kelimeye göre filteler.
        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            var filterWord = filterBox.Text;

            string[] tokens = filterWord.Split(' '); // girilen ilk kelime için filtreleme
            if (filterWord != string.Empty)
            {
                var todoTaskTableNew = new List<TaskTable>();
                foreach (var item in todoTaskTable)
                {
                    if ((item as TaskTable).TaskTitle.ToUpper().Contains(tokens[0].ToUpper()) || (item as TaskTable).TaskContent.ToUpper().Contains(filterWord.ToUpper()))
                    {
                        todoTaskTableNew.Add((TaskTable)item);
                    }
                }
                todogrid.ItemsSource = null;
                todogrid.ItemsSource = todoTaskTableNew;
            }
            else
            {
                todogrid.ItemsSource = null;
                todogrid.ItemsSource = todoTaskTable;
            }


        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
        }

        private void TaskCreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTaskScreen createTaskScreen = new CreateTaskScreen(parameter);
            createTaskScreen.Show();
            this.Close();
        }
    }
}
