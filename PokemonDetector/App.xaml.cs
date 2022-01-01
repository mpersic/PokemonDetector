using PokemonDetector.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokemonDetector.Features.Login;
using PokemonDetector.Features.Shell;

namespace PokemonDetector
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Bootstrapper.Init(this);

            MainPage = new LoginShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
