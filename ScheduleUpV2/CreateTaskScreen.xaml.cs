using ScheduleUp.DAL;
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

namespace ScheduleUpV2
{
    /// <summary>
    /// Interaction logic for CreateTaskScreen.xaml
    /// </summary>
    public partial class CreateTaskScreen : Window
    {
        private UserTable parameter;

        public UserTable Parameter
        {
            get;
            set;
        }
        public CreateTaskScreen(UserTable parameter) : this()
        {


            InitializeComponent();

            this.parameter = parameter;


            //fill assignedTo dropdown menu
            using (var context = new ScheduleUpDBEntities())
            {
                List<UserTable> dropdowndata = context.UserTable.ToList();
                AssignedTo.ItemsSource = dropdowndata;
            }
        }

        public CreateTaskScreen()
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ScheduleUpDBEntities())
            {
                UserTable user = AssignedTo.SelectedItem as UserTable;
                var new_task = new TaskTable()
                {
                    TaskID = Guid.NewGuid(),
                    TaskTitle = titleBox.Text,
                    TaskContent = contentBox.Text,
                    TaskCreator = parameter.userID.ToString(),
                    TaskAssignedTo = user.userID.ToString(),
                    TaskStartDate = startDate.SelectedDate.Value.Date,
                    TaskEndDate = endDate.SelectedDate.Value.Date,
                    TaskStatu = "TODO"
                };

                context.TaskTable.Add(new_task);
                context.SaveChanges();

                MessageBox.Show("Task Successfully Created", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void backToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(parameter);
            mainWindow.Show();
            this.Close();
        }
    }
}
