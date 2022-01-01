using PokemonDetector.Contracts;
using PokemonDetector.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokemonDetector.Features.Login
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            SignUpCommand = new Command(OnSignUp);
            SignInCommand = new Command(OnSignIn);
            ForgotPasswordCommand = new Command(OnForgotPassword);
        }

        #region Properties
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        #endregion

        #region Commands

        public ICommand ForgotPasswordCommand { get; }

        public ICommand SignInCommand { get; }

        public ICommand SignUpCommand { get; }

        #endregion

        private string password;
        private string email;

        private async void OnForgotPassword()
        {
            await Xamarin.Forms.Shell.Current.GoToAsync("//ForgotPasswordPage");
        }

        private async void OnSignIn()
        {
            try
            {
                var authService = DependencyService.Resolve<IAuthenticationService>();
                var token = await authService.SignIn(Email, Password);

                Application.Current.MainPage = new MainShell();
            }
            catch (Exception ex)
            {
                ToastProvider.LongAlert("A problem occured when signing in");
            }
        }

        private async void OnSignUp()
            => await Xamarin.Forms.Shell.Current.GoToAsync("//NewUserPage");

    }
}
