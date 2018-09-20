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
        DelegateCommand SearchCommand { get; }
        string SearchTerm { get; set; }

        void Create();
        void Read();
        void Update();
        void Delete();
        void Search();
    }
}