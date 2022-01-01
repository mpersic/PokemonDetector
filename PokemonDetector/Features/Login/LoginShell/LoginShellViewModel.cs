using PokemonDetector.Contracts;
using PokemonDetector.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamFormsFirebaseAuth.Features.Shell
{
    public class LoginShellViewModel : BaseViewModel
    {
        public LoginShellViewModel()
        {
            SignOutCommand = new Command(OnSignOut);
        }

        private void OnSignOut()
        {
            var authService = DependencyService.Resolve<IAuthenticationService>();
            authService.SignOut();

            Xamarin.Forms.Shell.Current.GoToAsync("//LoginPage");
        }

        public ICommand SignOutCommand { get; }
    }
}
