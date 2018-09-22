using System.Windows;

namespace ElectionSystem.ViewModels
{
    public class DialogViewModel : BaseInpc
    {
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private DelegateCommand _yesCommand;

        public DelegateCommand YesCommand
        {
            get => _yesCommand;
            set
            {
                _yesCommand = value;
                OnPropertyChanged();
            }
        }

        private DelegateCommand _noCommand;

        public DelegateCommand NoCommand
        {
            get => _noCommand;
            set
            {
                _noCommand = value;
                OnPropertyChanged();
            }
        }

        private DelegateCommand _okCommand;

        public DelegateCommand OkCommand
        {
            get => _okCommand;
            set
            {
                _okCommand = value;
                OnPropertyChanged();
            }
        }

        private Visibility _yesVisibility;

        public Visibility YesVisibility
        {
            get => _yesVisibility;
            set
            {
                _yesVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _noVisibility;

        public Visibility NoVisibility
        {
            get => _noVisibility;
            set
            {
                _noVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _okVisibility;

        public Visibility OkVisibility
        {
            get => _okVisibility;
            set
            {
                _okVisibility = value;
                OnPropertyChanged();
            }
        }
    }
}
