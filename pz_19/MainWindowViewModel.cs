using pz_19.Services;
using pz_19.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_19
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly AddEditUserViewModel _addEditUserViewModel;
        private readonly UserListViewModel _userListViewModel;

        public MainWindowViewModel(IUserRepository userRepository, IRequestRepository requestRepository)
        {
            _userListViewModel = new UserListViewModel(userRepository);     
            _addEditUserViewModel = new AddEditUserViewModel(userRepository);

            // Подписки на события
            _userListViewModel.AddUserRequested += NavigateToAddUser;   
            _userListViewModel.EditUserRequested += NavigateToEditUser;

            NavigationCommand = new RelayCommand<string>(OnNavigation);

            CurrentViewModel = _userListViewModel;
        }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public RelayCommand<string> NavigationCommand { get; private set; }

        private void OnNavigation(string destination)
        {
            switch (destination)
            {
                case "users":
                    CurrentViewModel = _userListViewModel;
                    break;
                case "requests":
                default:
                    CurrentViewModel = _userListViewModel;
                    break;
            }
        }

        private void NavigateToAddUser()
        {
            _addEditUserViewModel.IsEditMode = false;
            _addEditUserViewModel.SetUser(new User { UserId = Guid.NewGuid().GetHashCode() });
            _addEditUserViewModel.Done += NavigateBackToUsers;
            CurrentViewModel = _addEditUserViewModel;
        }

        private void NavigateToEditUser(User user)
        {
            _addEditUserViewModel.IsEditMode = true;
            _addEditUserViewModel.SetUser(user);
            _addEditUserViewModel.Done += NavigateBackToUsers;
            CurrentViewModel = _addEditUserViewModel;
        }


        private void NavigateBackToUsers()
        {
            _addEditUserViewModel.Done -= NavigateBackToUsers;
            CurrentViewModel = _userListViewModel;
        }

    }
}
