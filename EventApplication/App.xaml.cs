using System.Windows;
using EventApplication.Entities;

namespace EventApplication
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (!Core.DB.Database.Exists())
                Core.DB.Database.Create();
        }
    }
}
