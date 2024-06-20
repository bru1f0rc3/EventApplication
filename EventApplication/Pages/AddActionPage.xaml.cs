using System;
using System.IO;
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
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string filePath = Path.Combine(appDataPath, "file.txt");

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
                catch (Exception ex)
                {
                    MessageBox.Show("Обратитесь к администратору (Посмотрит лог)");
                    using (StreamWriter sr = new StreamWriter(filePath))
                        { sr.WriteLine(ex.Message); }
                }
            }
        }

        public StringBuilder FieldCh()
        {
            StringBuilder error = new StringBuilder();
            ActionEvent action = (ActionEvent)DataContext;

            if (action.EventDate < new DateTime(2020, 1, 1))
                error.AppendLine("Нельзя указывать дату ниже 2020 года.");
            else if (action.EventDate > new DateTime(3000, 12, 31))
                error.AppendLine("Нельзя указывать дату выше 3000 года.");
            if (ContainsAnySpecialCharacters(action.EventTitle))
                error.AppendLine("Недопустимые символы в поле Название мероприятия.");
            if (ContainsAnySpecialCharacters(action.EventDescription))
                error.AppendLine("Недопустимые символы в поле Описание мероприятия.");

            if (action.EventTime.HasValue)
            {
                if (action.EventTime.Value < new TimeSpan(6, 0, 0) || action.EventTime.Value > new TimeSpan(23, 59, 59))
                    error.AppendLine("Время события должно быть не раньше 6:00 и не позже 23:59.");
            }
            else
            {
                error.AppendLine("Время события не указано.");
            }

            return error;
        }

        public bool ContainsAnySpecialCharacters(string input)
        {
            string specialCharacters = @"~`!@#$%^&*_=+[{]}\|;:<>/?";
            return input.IndexOfAny(specialCharacters.ToCharArray()) != -1 && !input.All(char.IsDigit);
        }
    }
}
