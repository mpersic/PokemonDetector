using PokemonDetector.Contracts;
using PokemonDetector.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokemonDetector.Features.Login
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        public ForgotPasswordViewModel()
        {
            ResetPasswordCommand = new Command(OnResetPassword);
            SignUpCommand = new Command(OnSignUp);
        }

        #region Commands
        public ICommand SignUpCommand { get; }
        public ICommand ResetPasswordCommand { get; }
        #endregion

        #region Properties
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        #endregion

        private string email;

        private async void OnResetPassword(object obj)
        {
            try
            {
                var authService = DependencyService.Resolve<IAuthenticationService>();
                await authService.ResetPassword(Email);

                await Xamarin.Forms.Shell.Current
                    .DisplayAlert("Password Reset", "Password recovery sent, check your email", "OK");

                await Xamarin.Forms.Shell.Current
                    .GoToAsync("//LoginPage");
            }
            catch (Exception ex)
            {
                ToastProvider.LongAlert("A problem occured when sending password recovery");
            }
        }
        private async void OnSignUp()
            => await Xamarin.Forms.Shell.Current.GoToAsync("//NewUserPage");

    }
}
