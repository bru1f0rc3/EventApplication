using EventApplication.Entities;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace EventApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для RemoveActionPage.xaml
    /// </summary>
    public partial class RemoveActionPage : Page
    {
        public RemoveActionPage()
        {
            InitializeComponent();
            ActionDataGrid.ItemsSource = Core.DB.ActionEvent.ToList();
        }

        private void ActionDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActionEvent selected = ActionDataGrid.SelectedItem as ActionEvent;
            if (selected != null)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить запись?", "Предупреждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Core.DB.ActionEvent.Remove(selected);
                    Core.DB.SaveChanges();
                    ActionDataGrid.ItemsSource = Core.DB.ActionEvent.ToList();
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ActionDataGrid.ItemsSource = Core.DB.ActionEvent.Where(u => u.EventTitle.Contains(SearchTextBox.Text) || u.EventDescription.Contains(SearchTextBox.Text)).ToList();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
