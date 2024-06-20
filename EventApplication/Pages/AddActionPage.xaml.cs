using System;
using System.Windows;
using System.Windows.Controls;
using EventApplication.Entities;

namespace EventApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddActionPage.xaml
    /// </summary>
    public partial class AddActionPage : Page
    {
        private ActionEvent _action;

        public AddActionPage()
        {
            InitializeComponent();
            _action = new ActionEvent();
            _action.EventDate = DateTime.Now;
            DataContext = _action;

        }

        private void GoBackButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_action.EventId == 0)
                {
                    Core.DB.ActionEvent.Add(_action);
                    Core.DB.SaveChanges();
                    MessageBox.Show("Успешно добавилось");
                }
            }
            catch
            {
                MessageBox.Show("Обратитесь к администратору");
            }
        }
    }
}
