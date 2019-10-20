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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            var user_name = userNameBox.Text;
            var password = passwordBox.Password;

            using (var context = new ScheduleUpDBEntities())
            {
                var foundUser = context.UserTable.Where(x => x.userName == user_name && x.password == password).ToList();

                if(foundUser.Count == 1)
                {
                    
                    MainWindow mainWindow = new MainWindow(foundUser.FirstOrDefault());
                    mainWindow.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Username or password is wrong but i can't tall which one.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void usernameFocusEvent(object sender, RoutedEventArgs e)
        {
            userNameBox.Text = "";
        }
        private void register_button_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen regScreen = new RegisterScreen();
            regScreen.Show();
            this.Close();
        }
    }
}
