using System.Collections.ObjectModel;

namespace ElectionSystem.ViewModels
{
    public interface IReadViewModel<T>
    {
        ObservableCollection<T> Collection { get; set; }
        T Selected { get; set; }

        void Load();
        void AddNew();
        void Update();
        void Delete();
    }
}