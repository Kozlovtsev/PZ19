using pz_19.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_19.ViewModels
{
    public class UserListViewModel : BindableBase
    {
        private IUserRepository _repository;

        public UserListViewModel(IUserRepository repository)
        {
            _repository = repository;
            Users = new ObservableCollection<User>();
            LoadUsers();

            AddUserCommand = new RelayCommand(OnAddUser);
            EditUserCommand = new RelayCommand<User>(OnEditUser);
            ClearSearchInputCommand = new RelayCommand(OnClearSearch);
        }

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        private List<User> _userList;
        public async void LoadUsers()
        {
            _userList = await _repository.GetUsersAsync();
            Users = new ObservableCollection<User>(_userList);
        }

        private string _searchInput;
        public string SearchInput
        {
            get => _searchInput;
            set
            {
                SetProperty(ref _searchInput, value);
                FilterUsersByName(_searchInput);
            }
        }

        private void FilterUsersByName(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                Users = new ObservableCollection<User>(_userList);
            }
            else
            {
                Users = new ObservableCollection<User>(
                    _userList.Where(u => u.FullName.ToLower().Contains(searchText.ToLower())));
            }
        }

        public RelayCommand AddUserCommand { get; private set; }
        public RelayCommand<User> EditUserCommand { get; private set; }
        public RelayCommand ClearSearchInputCommand { get; private set; }

        public event Action AddUserRequested = delegate { };
        public event Action<User> EditUserRequested = delegate { };

        private void OnAddUser()
        {
            AddUserRequested?.Invoke();
        }

        private void OnEditUser(User user)
        {
            EditUserRequested?.Invoke(user);
        }

        private void OnClearSearch()
        {
            SearchInput = null;
        }
    }
}
