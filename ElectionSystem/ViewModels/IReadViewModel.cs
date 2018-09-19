using System.Collections.ObjectModel;

namespace ElectionSystem.ViewModels
{
    public interface IReadViewModel<T>
    {
        ObservableCollection<T> Collection { get; set; }
        T Selected { get; set; }
        DelegateCommand CreateCommand { get; }
        DelegateCommand ReadCommand { get; }
        DelegateCommand UpdateCommand { get; }
        DelegateCommand DeleteCommand { get; }

        void Read();
        void Create();
        void Update();
        void Delete();
    }
}