using System.Windows;


namespace GoooodProject
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InformationWindow : Window
    {
        ApplicationContext db = new ApplicationContext();

        public Employee User { get; }
        public InformationWindow(Employee user)
        {
            InitializeComponent();
            User = user;
            DataContext = User;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
