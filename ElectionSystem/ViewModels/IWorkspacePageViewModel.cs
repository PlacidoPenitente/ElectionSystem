namespace ElectionSystem.ViewModels
{
    public interface IWorkspacePageViewModel
    {
        string Title { get; }
        WorkspaceViewModel Workspace { get; }
    }
}