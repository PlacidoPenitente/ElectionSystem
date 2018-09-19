using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class BaseWorkspacePageViewModel : BaseInpc
    {
        public ApplicationDbContext DbContext { get; }

        public BaseWorkspacePageViewModel()
        {
            DbContext = new ApplicationDbContext();
        }
    }
}
