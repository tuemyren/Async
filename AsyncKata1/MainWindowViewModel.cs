using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AsyncKata1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool m_WorkOngoing;
        private string m_StatusMessage;

        public MainWindowViewModel()
        {
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
            WorkOngoing = !WorkOngoing;

            StatusMessage = WorkOngoing ? "Work ongoing" : "Work done";
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
