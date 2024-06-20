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
            Core.DB.SaveChanges();
            MessageBox.Show("Успешно изменено!");
            Thread.Sleep(1000);
            Close();
        }
    }
}
