using System.ComponentModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace QuizConnect.ViewModels
{
    internal class LoginPageViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public IRelayCommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private async void Login()
        {
            // Implement login logic here
        }
    }
}
