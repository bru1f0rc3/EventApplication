using EventApplication.Entities;
using System.Windows;

namespace EventApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для InformationActionWindow.xaml
    /// </summary>
    public partial class InformationActionWindow : Window
    {
        private ActionEvent _action;
        public InformationActionWindow(ActionEvent selected)
        {
            InitializeComponent();
            _action = selected;
            DataContext = _action;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы до конца прочитали всю информацию?", "Предупреждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
