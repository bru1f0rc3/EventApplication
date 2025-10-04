using EventApplication.Entities;
using System.Windows;

namespace EventApplication.Windows
{
    /// <summary>
    /// Окно для отображения информации о действии/событии.
    /// </summary>
    public partial class InformationActionWindow : Window
    {
        private readonly ActionEvent _action;

        /// <summary>
        /// Инициализирует новый экземпляр окна информации о действии.
        /// </summary>
        /// <param name="selectedAction">Выбранное действие для отображения.</param>
        public InformationActionWindow(ActionEvent selectedAction)
        {
            InitializeComponent();
            _action = selectedAction;
            DataContext = _action;
        }

        /// <summary>
        /// Обрабатывает событие нажатия на кнопку подтверждения прочтения информации.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Вы до конца прочитали всю информацию?",
                "Предупреждение",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
