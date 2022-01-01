using PokemonDetector.Contracts;
using PokemonDetector.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokemonDetector.Features.Login
{
    public class NewUserViewModel : BaseViewModel
    {
        private string password;
        private string email;
        private string username;

        public NewUserViewModel()
        {
            SignUpCommand = new Command(OnSignUp);
            GoToSignInCommand = new Command(GoToSignIn);
        }

        private async void OnSignUp()
        {
            try
            {
                var authService = DependencyService.Resolve<IAuthenticationService>();
                if (await authService.CreateUser(Username, Email, Password))
                {
                    await Xamarin.Forms.Shell.Current.GoToAsync("//MainShell");
                }
                else
                {
                    Console.WriteLine("A problem occurs when creating a user");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Xamarin.Forms.Shell.Current
                    .DisplayAlert("Create User", "An error occurs", "OK");
            }
        }

        private async void GoToSignIn()
        {
                await Xamarin.Forms.Shell.Current.GoToAsync("//LoginPage");
        }

        #region Properties
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

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

        public ICommand SignUpCommand { get; }
        public ICommand GoToSignInCommand { get; }
    }
}
