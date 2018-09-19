namespace ElectionSystem.ViewModels
{
    public interface ICreateUpdateViewModel<T>
    {
        T Model { get; }

        void Save();
        void Cancel();
    }
}
