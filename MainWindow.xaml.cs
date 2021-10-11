using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_StudentsManager
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

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Student added", "Students Manager", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

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
