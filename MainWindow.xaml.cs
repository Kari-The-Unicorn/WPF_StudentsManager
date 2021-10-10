using System.Windows;

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

        }
    }
}
