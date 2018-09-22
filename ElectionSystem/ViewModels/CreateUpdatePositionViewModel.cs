using System;
using System.Collections.ObjectModel;
using ElectionSystem.Facades;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class CreateUpdatePositionViewModel : BaseWorkspacePageViewModel, ICreateUpdateViewModel<PositionModel>, IWorkspacePageViewModel, IPage
    {
        private string _title;

        public CreateUpdatePositionViewModel(PositionModel positionModel, WorkspaceViewModel workspaceViewModel)
        {
            Model = positionModel;
            Workspace = workspaceViewModel;
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private ObservableCollection<Election> _elections;

        public ObservableCollection<Election> Elections
        {
            get => _elections;
            set
            {
                _elections = value;
                OnPropertyChanged();
            }
        }

        public void UpdateElections()
        {
            Elections = new ObservableCollection<Election>(DbContext.Elections);
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public WorkspaceViewModel Workspace { get; }
        public PositionModel Model { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public void Cancel()
        {
            Workspace.GotoReadPositions();
        }

        public void Save()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Save Position",
                Message = "Are you sure yo want to save this position?",
                YesVisibility = Visibility.Visible,
                YesCommand = new DelegateCommand(ContinueSave),
                NoVisibility = Visibility.Visible,
                NoCommand = new DelegateCommand(HideDialog),
                OkVisibility = Visibility.Collapsed
            };
        }

        private void HideDialog()
        {
            Workspace.Dialog = null;
        }

        private void ContinueSave()
        {
            try
            {
                if (DbContext.Positions.AsQueryable().Any(position => position.Id == Model.Position.Id))
                    DbContext.Entry(Model.Position).State = EntityState.Modified;
                else
                    DbContext.Positions.Add(Model.Position);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            HideDialog();
            Workspace.GotoReadPositions();
        }
    }
}
