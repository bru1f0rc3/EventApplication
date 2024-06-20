using EventApplication.Entities;
using EventApplication.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace EventApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlannedEventPage.xaml
    /// </summary>
    public partial class PlannedEventPage : Page
    {
        public PlannedEventPage()
        {
            InitializeComponent();
            var today = DateTime.Now.Date;
            var weekAgo = today.AddDays(7);

            ActionDataGrid.ItemsSource = Core.DB.ActionEvent
                .Where(u => u.EventDate >= today && u.EventDate <= weekAgo)
                .ToList();
        }

        private void ActionDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActionEvent selected = ActionDataGrid.SelectedItem as ActionEvent;
            InformationActionWindow information = new InformationActionWindow(selected);
            information.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var today = DateTime.Now.Date;
            var weekAgo = today.AddDays(7);
            if (!string.IsNullOrEmpty(SearchTextBox.Text))
            {
                ActionDataGrid.ItemsSource = Core.DB.ActionEvent
                    .Where(u => (u.EventTitle.Contains(SearchTextBox.Text) || u.EventDescription.Contains(SearchTextBox.Text))
                                && u.EventDate >= today && u.EventDate <= weekAgo)
                    .ToList();
            }
            else
            {
                ActionDataGrid.ItemsSource = Core.DB.ActionEvent
                    .Where(u => u.EventDate >= today && u.EventDate <= weekAgo)
                    .ToList();
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
