using pz_19.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_19.ViewModels
{
    public class AddEditUserViewModel : BindableBase
    {
        private IUserRepository _repository;

        public AddEditUserViewModel(IUserRepository repo)
        {
            _repository = repo;
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        private User _editingUser = null;
        private ValidableUser _user;
        public ValidableUser User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public event Action Done;

        private void OnCanExecuteChanges(object sender, EventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }

        private void CopyUser(User source, ValidableUser target)
        {
            target.UserId = source.UserId;
            if (IsEditMode)
            {
                target.FullName = source.FullName;
                target.PhoneNumber = source.PhoneNumber;
                target.Login = source.Login;
                target.Password = source.Password;
            }
        }

        internal void SetUser(User user)
        {
            _editingUser = user;
            if (User != null)
                User.ErrorsChanged -= OnCanExecuteChanges;

            User = new ValidableUser();
            User.ErrorsChanged += OnCanExecuteChanges;
            CopyUser(user, User);
        }

        internal void OnCancel()
        {
            Done?.Invoke();
        }

        private bool CanSave() => !User.HasErrors;

        private void UpdateUser(ValidableUser source, User target)
        {
            target.FullName = source.FullName;
            target.PhoneNumber = source.PhoneNumber;
            target.Login = source.Login;
            target.Password = source.Password;
        }

        private async void OnSave()
        {
            UpdateUser(User, _editingUser);
            if (IsEditMode)
                await _repository.UpdateUserAsync(_editingUser);
            else
                await _repository.AddUserAsync(_editingUser);
            Done?.Invoke();
        }
    }
}
