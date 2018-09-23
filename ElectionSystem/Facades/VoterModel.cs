using ElectionSystem.Models;
using System;

namespace ElectionSystem.Facades
{
    public sealed class VoterModel : BaseInpc
    {
        public Voter Voter { get; set; }
        public string Username
        {
            get => Voter.Username;
            set
            {
                Voter.Username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => Voter.Password;
            set
            {
                Voter.Password = value;
                OnPropertyChanged();
            }
        }

        public AccountType AccountType
        {
            get => Voter.AccountType;
            set
            {
                Voter.AccountType = value;
                OnPropertyChanged();
            }
        }

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

        public DateTime? Birthdate
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
