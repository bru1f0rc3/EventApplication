using EventApplication.Entities;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using EventApplication.Windows;
using System;

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
            LoadData();
        }

        private void LoadData()
        {
            var today = DateTime.Now.Date;
            ActionDataGrid.ItemsSource = Core.DB.ActionEvent.Where(u => u.EventDate >= today).ToList();
            ActionDataGrid.Items.Refresh();
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
                    editWindow.ShowDialog();

                    if (editWindow.DialogResult == true)
                    {
                        LoadData();
                    }
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
