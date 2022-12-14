using System.Windows;
namespace GoooodProject
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public Employee Employee { get; private set; }
        public EmployeeWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            DataContext = Employee;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Employee.Name) || !string.IsNullOrEmpty(Employee.Surname) || !string.IsNullOrEmpty(Employee.Patronymic) || !string.IsNullOrEmpty(Employee.Department) || !string.IsNullOrEmpty(Employee.Phone) || !string.IsNullOrEmpty(Employee.DateBirthday))
            {
                DialogResult = true;
            }
        }
    }
}
