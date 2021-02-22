using System.ComponentModel;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
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

        private void StartStopCommandExecute(object obj)
        {
            WorkOngoing = true;
            StatusMessage = "Work ongoing";
            m_Worker.DoWork();
            StatusMessage = "Work done!";
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
