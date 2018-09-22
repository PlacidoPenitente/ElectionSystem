using System;
using System.Collections.ObjectModel;
using ElectionSystem.Facades;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class CreateUpdateCandidacyViewModel : BaseWorkspacePageViewModel, ICreateUpdateViewModel<CandidacyModel>, IWorkspacePageViewModel, IPage
    {
        private string _title;

        public CreateUpdateCandidacyViewModel(CandidacyModel candidacyModel, WorkspaceViewModel workspaceViewModel)
        {
            Model = candidacyModel;
            Workspace = workspaceViewModel;
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private ObservableCollection<Voter> _candidates;

        public ObservableCollection<Voter> Candidates
        {
            get => _candidates;
            set
            {
                _candidates = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Party> _parties;

        public ObservableCollection<Party> Parties
        {
            get => _parties;
            set
            {
                _parties = value;
                OnPropertyChanged();
            }
        }

        private Election _election;

        public Election Election
        {
            get => _election;
            set
            {
                _election = value;
                Positions = new ObservableCollection<Position>(DbContext.Positions.Include("Election").Where(position => position.Election.Id == value.Id));
                OnPropertyChanged();
            }
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

        private ObservableCollection<Position> _positions;

        public ObservableCollection<Position> Positions
        {
            get => _positions;
            set
            {
                _positions = value;
                OnPropertyChanged();
            }
        }

        public void UpdateValues()
        {
            Candidates = new ObservableCollection<Voter>(DbContext.Voters);
            Parties = new ObservableCollection<Party>(DbContext.Parties);
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
        public CandidacyModel Model { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public void Cancel()
        {
            Workspace.GotoReadCandidacies();
        }

        public void Save()
        {
            Workspace.Dialog = new DialogViewModel
            {
                Title = "Save Candidacy",
                Message = "Are you sure yo want to save this candidacy?",
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
                if (DbContext.Candidacies.AsQueryable().Any(candidacy => candidacy.Id == Model.Candidacy.Id))
                    DbContext.Entry(Model.Candidacy).State = EntityState.Modified;
                else
                    DbContext.Candidacies.Add(Model.Candidacy);
                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            HideDialog();
            Workspace.GotoReadCandidacies();
        }
    }
}
