using System.ComponentModel;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using WorkerLibrary;

namespace AsyncKata1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool m_WorkOngoing;
        private string m_StatusMessage;
        private IWorker m_Worker;

        public MainWindowViewModel(IWorker worker)
        {
            m_Worker = worker;
            StartStopCommand = new RelayCommand(StartStopCommandExecute);
        }

        public ICommand StartStopCommand { get; }

        public bool WorkOngoing
        {
            get => m_WorkOngoing;
            set
            {
                m_WorkOngoing = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get => m_StatusMessage;
            set
            {
                m_StatusMessage = value;
                OnPropertyChanged();
            }
        }


        private CancellationTokenSource m_Cancel;

        private async void StartStopCommandExecute(object obj)
        {
            if (WorkOngoing)
            {
                // Make sure cancel hasn't already been requested
                if (m_Cancel is null || m_Cancel.IsCancellationRequested)
                {
                    return;
                }

                m_Cancel.Cancel(); // Cancel the DoWork() Task
                return;
            }

            WorkOngoing = true;
            m_Cancel = new CancellationTokenSource();
            StatusMessage = "Work ongoing";
            StatusMessage = await m_Worker.DoWork(m_Cancel.Token);
            m_Cancel?.Dispose();
            WorkOngoing = false;
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
