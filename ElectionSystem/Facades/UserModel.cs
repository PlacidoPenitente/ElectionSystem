using ElectionSystem.Models;

namespace ElectionSystem.Facades
{
    public sealed class UserModel : BaseInpc
    {
        private readonly User _user;

        public UserModel(User user)
        {
            _user = user;
        }

        public int Id { get => _user.Id; }

        public string Username
        {
            get => _user.Username;
            set
            {
                _user.Username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _user.Password;
            set
            {
                _user.Password = value;
                OnPropertyChanged();
            }
        }

        public AccountType AccountType
        {
            get => _user.AccountType;
            set
            {
                _user.AccountType = value;
                OnPropertyChanged();
            }
        }
    }
}
