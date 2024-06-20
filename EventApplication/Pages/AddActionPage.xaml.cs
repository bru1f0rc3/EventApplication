using System;
using System.Linq;
using System.Text;
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
            StringBuilder errors = FieldCh();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
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

        public StringBuilder FieldCh()
        {
            StringBuilder error = new StringBuilder();
            ActionEvent action = (ActionEvent)DataContext;

            if (_action.EventDate < new DateTime(2020, 1, 1))
                error.AppendLine("Нельзя указывать дату ниже 2020 года.");
            else if (_action.EventDate > new DateTime(3000, 12, 31))
                error.AppendLine("Нельзя указывать дату выше 3000 года.");
            if (ContainsAnySpecialCharacters(_action.EventTitle))
                error.AppendLine("Недопустимые символы в поле Название мероприятия.");
            if (ContainsAnySpecialCharacters(_action.EventDescription))
                error.AppendLine("Недопустимые символы в поле Описание мероприятия.");
            if (_action.EventTime.HasValue && (_action.EventTime.Value < new TimeSpan(6, 0, 0) || _action.EventTime.Value > new TimeSpan(23, 59, 59)))
                error.AppendLine("Время события должно быть не раньше 6:00 и не позже 23:59.");

            return error;
        }

        public bool ContainsAnySpecialCharacters(string input)
        {
            string specialCharacters = @"~`!@#$%^&*_=+[{]}\|;:<>/?";
            return input.IndexOfAny(specialCharacters.ToCharArray()) != -1 && !input.All(char.IsDigit);
        }
    }
}
