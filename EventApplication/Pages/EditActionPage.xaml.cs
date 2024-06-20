using EventApplication.Entities;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using EventApplication.Windows;

namespace EventApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditActionPage.xaml
    /// </summary>
    public partial class EditActionPage : Page
    {
        public EditActionPage()
        {
            InitializeComponent();
            ActionDataGrid.ItemsSource = Core.DB.ActionEvent.ToList();
        }

        private void ActionDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActionEvent selected = ActionDataGrid.SelectedItem as ActionEvent;
            if (selected != null)
            {
                var result = MessageBox.Show("Вы уверены что хотите его изменить?", "Предупреждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    EditActionWindow editWindow = new EditActionWindow(selected);
                    editWindow.Show();
                    ActionDataGrid.ItemsSource = Core.DB.ActionEvent.ToList();
                }
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ActionDataGrid.ItemsSource = Core.DB.ActionEvent.Where(u => u.EventTitle.Contains(SearchTextBox.Text) || u.EventDescription.Contains(SearchTextBox.Text)).ToList();
        }
    }
}
