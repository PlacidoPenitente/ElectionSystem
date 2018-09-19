using ElectionSystem.Models;
using System;

namespace ElectionSystem.Facades
{
    public sealed class VoterModel : BaseInpc
    {
        public VoterModel(Voter voter)
        {
            Voter = voter;
        }

        public Voter Voter { get; }

        public string FirstName
        {
            get => Voter.FirstName;
            set
            {
                Voter.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get => Voter.MiddleName;
            set
            {
                Voter.MiddleName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => Voter.LastName;
            set
            {
                Voter.LastName = value;
                OnPropertyChanged();
            }
        }

        public DateTime Birthdate
        {
            get => Voter.Birthdate;
            set
            {
                Voter.Birthdate = value;
                OnPropertyChanged();
            }
        }

        public Gender Gender
        {
            get => Voter.Gender;
            set
            {
                Voter.Gender = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => Voter.Address;
            set
            {
                Voter.Address = value;
                OnPropertyChanged();
            }
        }

        public string Photo
        {
            get => Voter.Photo;
            set
            {
                Voter.Photo = value;
                OnPropertyChanged();
            }
        }
    }
}
