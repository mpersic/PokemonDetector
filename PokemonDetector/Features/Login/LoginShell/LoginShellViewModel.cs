using PokemonDetector.Contracts;
using PokemonDetector.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokemonDetector.Features.Shell
{
    public class LoginShellViewModel : BaseViewModel
    {
        public LoginShellViewModel()
        {
            SignOutCommand = new Command(OnSignOut);
        }

        #region Commands
        public ICommand SignOutCommand { get; }
        #endregion

        private void OnSignOut()
        {
            var authService = DependencyService.Resolve<IAuthenticationService>();
            authService.SignOut();

            Xamarin.Forms.Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
