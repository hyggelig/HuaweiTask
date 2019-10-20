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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleUpV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            ScheduleUpDBEntities context = new ScheduleUpDBEntities();

            List<TaskTable> it = new List<TaskTable>();
            var TaskList = context.TaskTable.Where(x => x.TaskAssignedTo == "26C741D5-1758-4CA7-B802-85BFAF64B587").ToList();
            foreach (var task in TaskList)
            {
                it.Add(task);
            }

            dg.ItemsSource = it;

            //CreateDynamicWPFGrid();



            //TaskTable new_task = new TaskTable()
            //{
            //    TaskID = Guid.NewGuid(),
            //    TaskTitle = "giriş ekranı oluşturma",
            //    TaskContent = "açılış ekranının giriş ekranı olması ve kullanıcı girişi yapılması",
            //    TaskAssignedTo = "26C741D5-1758-4CA7-B802-85BFAF64B587",
            //    TaskCreator = "26C741D5-1758-4CA7-B802-85BFAF64B587",
            //    TaskStartDate = new DateTime(1995,10,19),
            //    TaskEndDate = new DateTime(1995,10,20)
            //};

            //context.TaskTable.Add(new_task);
            //context.SaveChanges();
        }

        private void CreateDynamicWPFGrid()
        {
            // Create the Grid
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = 300;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            // Create Columns

            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();

            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);

            // Create Rows

            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(30);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(30);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(30);

            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);
            DynamicGrid.RowDefinitions.Add(gridRow3);

            // Add first column header

            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Author Name";
            txtBlock1.FontSize = 14;
            txtBlock1.FontWeight = FontWeights.Bold;
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);

            // Add second column header

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.Text = "Age";
            txtBlock2.FontSize = 14;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock2.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 1);

            // Add third column header

            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.Text = "Book";
            txtBlock3.FontSize = 14;
            txtBlock3.FontWeight = FontWeights.Bold;
            txtBlock3.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock3.VerticalAlignment = VerticalAlignment.Top;

            Grid.SetRow(txtBlock3, 0);
            Grid.SetColumn(txtBlock3, 2);

            //// Add column headers to the Grid

            DynamicGrid.Children.Add(txtBlock1);
            DynamicGrid.Children.Add(txtBlock2);
            DynamicGrid.Children.Add(txtBlock3);

            // Create first Row

            TextBlock authorText = new TextBlock();
            authorText.Text = "Mahesh Chand";
            authorText.FontSize = 12;
            authorText.FontWeight = FontWeights.Bold;

            Grid.SetRow(authorText, 1);
            Grid.SetColumn(authorText, 0);

            TextBlock ageText = new TextBlock();
            ageText.Text = "33";
            ageText.FontSize = 12;
            ageText.FontWeight = FontWeights.Bold;

            Grid.SetRow(ageText, 1);
            Grid.SetColumn(ageText, 1);

            TextBlock bookText = new TextBlock();
            bookText.Text = "GDI+ Programming";
            bookText.FontSize = 12;
            bookText.FontWeight = FontWeights.Bold;

            Grid.SetRow(bookText, 1);
            Grid.SetColumn(bookText, 2);

            // Add first row to Grid

            DynamicGrid.Children.Add(authorText);
            DynamicGrid.Children.Add(ageText);
            DynamicGrid.Children.Add(bookText);

            // Create second row

            authorText = new TextBlock();
            authorText.Text = "Mike Gold";
            authorText.FontSize = 12;
            authorText.FontWeight = FontWeights.Bold;

            Grid.SetRow(authorText, 2);
            Grid.SetColumn(authorText, 0);

            ageText = new TextBlock();
            ageText.Text = "35";
            ageText.FontSize = 12;
            ageText.FontWeight = FontWeights.Bold;

            Grid.SetRow(ageText, 2);
            Grid.SetColumn(ageText, 1);

            bookText = new TextBlock();
            bookText.Text = "Programming C#";
            bookText.FontSize = 12;
            bookText.FontWeight = FontWeights.Bold;

            Grid.SetRow(bookText, 2);
            Grid.SetColumn(bookText, 2);

            // Add second row to Grid

            DynamicGrid.Children.Add(authorText);
            DynamicGrid.Children.Add(ageText);
            DynamicGrid.Children.Add(bookText);

            // Display grid into a Window

            //todoMainGrid.Children.Add(DynamicGrid);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            TaskTable customer = (TaskTable)dg.SelectedItem;
        }
    }
}
