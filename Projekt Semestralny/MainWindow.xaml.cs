using System.Windows;
using ProjektSemestralny.ViewModels;

namespace ProjektSemestralny
{
    public partial class MainWindow : Window
    {
        private readonly CustomerViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new CustomerViewModel(new DatabaseContext());
            DataContext = _viewModel;
        }

        private void TestConnection_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.TestSqlConnection();
        }
    }
}
