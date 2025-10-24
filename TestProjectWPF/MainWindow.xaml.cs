using System.Windows;
using TestProject.Model;
using TestProject.ViewModel;

namespace TestProjectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var model = new TaskManager();
            var vm = new TaskManagerViewModel(model);
            DataContext = vm;
        }
    }
}