using System.Windows;
namespace GoooodProject
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public Employee User { get; private set; }
        public UserWindow(Employee user)
        {
            InitializeComponent();
            User = user;
            DataContext = User;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
