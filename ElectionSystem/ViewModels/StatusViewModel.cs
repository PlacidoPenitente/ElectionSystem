using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class StatusViewModel : BaseWorkspacePageViewModel, IWorkspacePageViewModel
    {
        public WorkspaceViewModel Workspace { get; }

        private TotalVote _selected;

        public TotalVote Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TotalVote> _totalVotes;

        public ObservableCollection<TotalVote> Collection
        {
            get => _totalVotes;
            set
            {
                _totalVotes = value;
                OnPropertyChanged();
            }
        }

        public StatusViewModel()
        {
            SearchCommand = new DelegateCommand(Load);
        }

        public DelegateCommand SearchCommand { get; set; }

        public void Load()
        {
            var unique = new List<int>(DbContext.Votes.Include("Ballot").Include("Candidacy").Select(x => x.Candidacy.Id).Distinct());
            var list = new ObservableCollection<Vote>();
            foreach (var i in unique)
            {
                list.Add(DbContext.Votes.Include("Candidacy").First(x=>x.Candidacy.Id == i));
            }
            var temp = new ObservableCollection<TotalVote>();
            foreach (var vote in list)
            {
                vote.Candidacy = DbContext.Candidacies.Include("Candidate").Include("Party").Include("Position")
                    .Single(x => x.Id == vote.Candidacy.Id);
                vote.Candidacy.Position = DbContext.Positions.Include("Election")
                    .Single(x => x.Id == vote.Candidacy.Position.Id);
                temp.Add(new TotalVote
                {
                    Candidacy = vote.Candidacy,
                    Total = DbContext.Votes.Count(x => x.Candidacy.Id == vote.Candidacy.Id)
                });
            }

            Collection = temp;
        }

    }
}
