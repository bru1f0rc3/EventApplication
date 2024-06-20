using System.Windows;
using EventApplication.Pages;

namespace EventApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainMenus.Navigate(new MainMenu());
        }
    }
}
