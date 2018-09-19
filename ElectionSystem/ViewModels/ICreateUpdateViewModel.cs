namespace ElectionSystem.ViewModels
{
    public interface ICreateUpdateViewModel<T>
    {
        T Model { get; }
        DelegateCommand SaveCommand { get; }
        DelegateCommand CancelCommand { get; }

        void Save();
        void Cancel();
    }
}
