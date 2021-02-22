using System.Windows;

namespace AsyncKata1
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var worker = new WorkerLibrary.Worker();
            var mainWindowViewModel = new MainWindowViewModel(worker);

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainWindowViewModel;

            mainWindow.Show();
        }
    }
}
