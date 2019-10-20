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
using ScheduleUp.DAL;
namespace ScheduleUpV2
{
    /// <summary>
    /// Interaction logic for RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        public RegisterScreen()
        {
            InitializeComponent();
        }

        private void createAccountButton_Click(object sender, RoutedEventArgs e)
        {
            UserTable new_user = new UserTable
            {
                userID = Guid.NewGuid(),
                userName = r_usernameBox.Text,
                name = r_nameBox.Text,
                surname = r_surnameBox.Text,
                email = r_emailBox.Text,
                password = r_passwordBox.Password,
            };

            using (var context = new ScheduleUpDBEntities())
            {

                if (new_user.name == string.Empty || new_user.surname == string.Empty || new_user.password == string.Empty || new_user.userName == string.Empty)
                    MessageBox.Show("Username, name, surname, password can not be null", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    var accountExist = context.UserTable.Where(x => x.userName == new_user.userName).ToList();
                    if (accountExist.Count != 0)
                        MessageBox.Show("the username has already been taken", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                    {
                        context.UserTable.Add(new_user);
                        context.SaveChanges();
                        MessageBox.Show("Account Successfully Created", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

                        LoginScreen loginWindow = new LoginScreen();
                        loginWindow.Show();
                        this.Close();
                    }
                }
            }
            
        }
    }
}
