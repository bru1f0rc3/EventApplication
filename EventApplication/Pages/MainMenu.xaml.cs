using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace EventApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void AddActionButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddActionPage());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditActionPage());
        }

        private void RemoveActionButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RemoveActionPage());
        }

        private void PlanActionButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlannedEventPage());
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
