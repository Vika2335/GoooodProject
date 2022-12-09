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
            db.Users.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Users.Local.ToObservableCollection();
        }

        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            UserWindow UserWindow = new UserWindow(new Employee());
            if (UserWindow.ShowDialog() == true)
            {
                Employee User = UserWindow.User;
                db.Users.Add(User);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? user = usersList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            UserWindow UserWindow = new UserWindow(new Employee
            {
                Id = user.Id,
                Name = user.Name,
                Idper = user.Idper,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                DateBirthday = user.DateBirthday,
                Phone = user.Phone,
                Department = user.Department,
            });

            if (UserWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                user = db.Users.Find(UserWindow.User.Id);
                if (user != null)
                {
                    user.Name = UserWindow.User.Name;
                    user.Idper = UserWindow.User.Idper;
                    user.Surname = UserWindow.User.Surname;
                    user.Patronymic = UserWindow.User.Patronymic;
                    user.DateBirthday = UserWindow.User.DateBirthday;
                    user.Phone = UserWindow.User.Phone;
                    user.Department = UserWindow.User.Department;

                    db.SaveChanges();
                    usersList.Items.Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? user = usersList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;
            db.Users.Remove(user);
            db.SaveChanges();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? user = usersList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            InformationWindow InformationWindow = new InformationWindow(user);
            if (InformationWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                user = db.Users.Find(InformationWindow.User.Id);
                if (user != null)
                {
                    usersList.Items.Refresh();
                }
            }
        }
    }
}