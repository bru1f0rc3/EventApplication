using System;
using System.Linq;
using System.Text;
using EventApplication.Entities;

namespace EventApplication.Helpers
{
    /// <summary>
    /// Provides centralized validation methods for event data.
    /// </summary>
    public static class ValidationHelper
    {
        private const int MinYear = 2020;
        private const int MaxYear = 3000;
        private const int MinHour = 6;
        private const int MaxHour = 23;
        private const int MaxMinute = 59;
        private const int MaxSecond = 59;
        private const string SpecialCharacters = @"~`!@#$%^&*_=+[{]}\|;:<>/?";

        /// <summary>
        /// Validates all fields of an ActionEvent entity.
        /// </summary>
        /// <param name="action">The action event to validate.</param>
        /// <returns>A StringBuilder containing all validation errors, or empty if validation passes.</returns>
        public static StringBuilder ValidateActionEvent(ActionEvent action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), "Action event cannot be null.");
            }

            StringBuilder errors = new StringBuilder();

            ValidateEventDate(action.EventDate, errors);
            ValidateEventTitle(action.EventTitle, errors);
            ValidateEventDescription(action.EventDescription, errors);
            ValidateEventTime(action.EventTime, errors);

            return errors;
        }

        /// <summary>
        /// Validates the event date to ensure it's within acceptable range.
        /// </summary>
        /// <param name="eventDate">The event date to validate.</param>
        /// <param name="errors">StringBuilder to append errors to.</param>
        private static void ValidateEventDate(DateTime eventDate, StringBuilder errors)
        {
            if (eventDate < new DateTime(MinYear, 1, 1))
            {
                errors.AppendLine($"Нельзя указывать дату ниже {MinYear} года.");
            }
            else if (eventDate > new DateTime(MaxYear, 12, 31))
            {
                errors.AppendLine($"Нельзя указывать дату выше {MaxYear} года.");
            }
        }

        /// <summary>
        /// Validates the event title for special characters.
        /// </summary>
        /// <param name="eventTitle">The event title to validate.</param>
        /// <param name="errors">StringBuilder to append errors to.</param>
        private static void ValidateEventTitle(string eventTitle, StringBuilder errors)
        {
            if (ContainsSpecialCharacters(eventTitle))
            {
                errors.AppendLine("Недопустимые символы в поле Название мероприятия.");
            }
        }

        /// <summary>
        /// Validates the event description for special characters.
        /// </summary>
        /// <param name="eventDescription">The event description to validate.</param>
        /// <param name="errors">StringBuilder to append errors to.</param>
        private static void ValidateEventDescription(string eventDescription, StringBuilder errors)
        {
            if (ContainsSpecialCharacters(eventDescription))
            {
                errors.AppendLine("Недопустимые символы в поле Описание мероприятия.");
            }
        }

        /// <summary>
        /// Validates the event time to ensure it's within acceptable range.
        /// </summary>
        /// <param name="eventTime">The event time to validate.</param>
        /// <param name="errors">StringBuilder to append errors to.</param>
        private static void ValidateEventTime(TimeSpan? eventTime, StringBuilder errors)
        {
            if (eventTime.HasValue)
            {
                TimeSpan minTime = new TimeSpan(MinHour, 0, 0);
                TimeSpan maxTime = new TimeSpan(MaxHour, MaxMinute, MaxSecond);

                if (eventTime.Value < minTime || eventTime.Value > maxTime)
                {
                    errors.AppendLine($"Время события должно быть не раньше {MinHour}:00 и не позже {MaxHour}:{MaxMinute}.");
                }
            }
            else
            {
                errors.AppendLine("Время события не указано.");
            }
        }

        /// <summary>
        /// Checks if the input string contains any special characters.
        /// </summary>
        /// <param name="input">The string to check.</param>
        /// <returns>True if special characters are found; otherwise, false.</returns>
        private static bool ContainsSpecialCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return input.IndexOfAny(SpecialCharacters.ToCharArray()) != -1 && !input.All(char.IsDigit);
        }
    }
}
