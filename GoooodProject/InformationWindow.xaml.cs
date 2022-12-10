using System.Windows;


namespace GoooodProject
{
    public partial class InformationWindow : Window
    {
        ApplicationContext db = new ApplicationContext();

        public Employee Employee { get; }
        public InformationWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            DataContext = Employee;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
