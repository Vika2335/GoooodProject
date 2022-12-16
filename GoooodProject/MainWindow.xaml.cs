using System.Windows;
using Microsoft.EntityFrameworkCore;
using GoooodProject;

namespace Goooodproject
{
    
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        // при загрузке окна
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Employee.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Employee.Local.ToObservableCollection();
        }

        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow EmployeeWindow = new EmployeeWindow(new Employee());
            if (EmployeeWindow.ShowDialog() == true)
            {
                Employee Employee = EmployeeWindow.Employee;
                db.Employee.Add(Employee);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeesList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;

            EmployeeWindow EmployeeWindow = new EmployeeWindow(new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Idper = employee.Idper,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                DateBirthday = employee.DateBirthday,
                Phone = employee.Phone,
                Department = employee.Department,
            });

            if (EmployeeWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                employee = db.Employee.Find(EmployeeWindow.Employee.Id);
                if (employee != null)
                {
                    employee.Name = EmployeeWindow.Employee.Name;
                    employee.Idper = EmployeeWindow.Employee.Idper;
                    employee.Surname = EmployeeWindow.Employee.Surname;
                    employee.Patronymic = EmployeeWindow.Employee.Patronymic;
                    employee.DateBirthday = EmployeeWindow.Employee.DateBirthday;
                    employee.Phone = EmployeeWindow.Employee.Phone;
                    employee.Department = EmployeeWindow.Employee.Department;

                    db.SaveChanges();
                    employeesList.Items.Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeesList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;
            db.Employee.Remove(employee);
            db.SaveChanges();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeesList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;

            InformationWindow InformationWindow = new InformationWindow(employee);
            if (InformationWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                employee = db.Employee.Find(InformationWindow.Employee.Id);
                if (employee != null)
                {
                    employeesList.Items.Refresh();
                }
            }
        }

        private void MenuItem_JSON_Click(object sender, RoutedEventArgs e)
        {
            JSON data = new JSON(db.Employee);
            MessageBox.Show("Вы сохранили отчет в JSON!", "Du bist gooood!");
        }

        private void MenuItem_Excel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Excel data = new Excel(db.Employee);
                MessageBox.Show("Вы сохранили отчет в Excel!", "Du bist gooood!");
            }
            catch
            {
                MessageBox.Show("Сохранить не удалось:(", "Error");
            }
        }
    }
}