﻿using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using EventApplication.Entities;

namespace EventApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditActionWindow.xaml
    /// </summary>
    public partial class EditActionWindow : Window
    {
        private ActionEvent _action;
        public EditActionWindow(ActionEvent selected)
        {
            InitializeComponent();
            _action = selected;
            DataContext = _action;
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
                    Core.DB.SaveChanges();
                    MessageBox.Show("Успешно изменено!");
                    DialogResult = true;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                    DialogResult = false;
                }
            }
        }

        public StringBuilder FieldCh()
        {
            StringBuilder error = new StringBuilder();
            ActionEvent _action = (ActionEvent)DataContext;

            if (_action != null)
            {
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
            }
            else
            {
                error.AppendLine("Объект события не найден.");
            }

            return error;
        }

        public bool ContainsAnySpecialCharacters(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            string specialCharacters = @"~`!@#$%^&*_=+[{]}\|;:<>/?";
            return input.Any(ch => specialCharacters.Contains(ch));
        }
    }
}
