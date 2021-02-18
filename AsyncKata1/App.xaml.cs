using System.Windows;

namespace AsyncKata1
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindowViewModel = new MainWindowViewModel();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainWindowViewModel;

            mainWindow.Show();
        }
    }
}
