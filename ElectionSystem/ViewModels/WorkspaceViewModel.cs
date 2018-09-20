﻿using ElectionSystem.Facades;
using ElectionSystem.Models;

namespace ElectionSystem.ViewModels
{
    public class WorkspaceViewModel : BaseInpc, IPage
    {
        private readonly MainWindowViewModel _mainWindow;
        private readonly CreateUpdateVoterViewModel _createUpdateVoter;
        private readonly ReadVotersViewModel _readVoters;

        private Voter _voter;

        private IWorkspacePageViewModel _currentPage;

        public WorkspaceViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindow = mainWindowViewModel;
            _createUpdateVoter = new CreateUpdateVoterViewModel(new VoterModel(_voter), this);
            _readVoters = new ReadVotersViewModel();
            CurrentPage = _readVoters;
        }

        public IWorkspacePageViewModel CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public string Title { get; }

        public void GotoCreateUpdateVoter(Voter voter = null)
        {
            _createUpdateVoter.Title = "Update Voter";
            if (voter == null) _createUpdateVoter.Title = "Register new Voter";
            _voter = null;
            _voter = voter ?? new Voter();
            CurrentPage = _createUpdateVoter;
        }

        public void GotoReadVoters()
        {
            CurrentPage = _readVoters;
        }

        public void ShowYesNoDialog()
        {

        }

        public void ShowWaitDialog()
        {

        }
        
        public void ShowErrorDialog()
        {

        }

        public void ShowSuccessDialog()
        {

        }

        public void ShowInfoDialog()
        {

        }
    }
}
