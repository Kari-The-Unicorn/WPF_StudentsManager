using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF_StudentsManager.DataProvider;
using WPF_StudentsManager.Model;
using WPF_StudentsManager.ViewModel;

namespace WPF_StudentsManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; }

        public MainWindow()
        {
            InitializeComponent();
            // Now any binding in xaml file can bind to the view model that is in data context
            ViewModel = new MainViewModel(new StudentsDataProvider());
            DataContext = ViewModel;
            // Event to load data
            Loaded += MainPage_Loaded;
            Closing += MainWindow_Closing; // state the customers when application is closed
        }

        // Fills list view with students from view model
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadAsync();
        }

        private async void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //_studentsDataProvider.SaveStudentsAsync(studentsListView.Items.OfType<Student>()).Wait();
            await ViewModel.SaveAsync();
        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var student = new Student { FirstName = "Name" };
            studentsListView.Items.Add(student);
            studentsListView.SelectedItem = student;
            MessageBox.Show($"Student with name: {student.FirstName} is added", "Students Manager", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var student = studentsListView.SelectedItem as Student;
            if (student != null)
            {
                studentsListView.Items.Remove(student);
            }
            MessageBox.Show($"Student with name: {student.FirstName} is deleted", "Students Manager", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            //// Move students studentsListGrid to column 2 and back to 0 when clicked again
            //int column = (int)studentsListGrid.GetValue(Grid.ColumnProperty);
            //int newColumn = column == 0 ? 2 : 0;
            //studentsListGrid.SetValue(Grid.ColumnProperty, newColumn);
            //// change arrow icon when clicked to left and back to forward when clicked again (column grid = 0 then forward, column grid = 2 then left)
            //arrowMoveIcon.Source = newColumn == 0 ?
            //    (System.Windows.Media.ImageSource)this.Resources["forward"] :
            //    (System.Windows.Media.ImageSource)this.Resources["left"];
            // That can be also done as below:

            // Move students studentsListGrid to column 2 and back to 0 when clicked again
            int column = Grid.GetColumn(studentsListGrid);
            int newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(studentsListGrid, newColumn);
            // change arrow icon when clicked to left and back to forward when clicked again (column grid = 0 then forward, column grid = 2 then left)
            arrowMoveIcon.Source = newColumn == 0 ?
                (System.Windows.Media.ImageSource)this.Resources["forward"] :
                (System.Windows.Media.ImageSource)this.Resources["left"];
        }
    }
}
