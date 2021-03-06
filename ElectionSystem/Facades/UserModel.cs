﻿using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class UserModel : BaseInpc
    {
        public User User { get; set; }

        public string Username
        {
            get => User.Username;
            set
            {
                User.Username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => User.Password;
            set
            {
                User.Password = value;
                OnPropertyChanged();
            }
        }

        public AccountType AccountType
        {
            get => User.AccountType;
            set
            {
                User.AccountType = value;
                OnPropertyChanged();
            }
        }
    }
}
