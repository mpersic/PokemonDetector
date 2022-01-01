using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PokemonDetector.Features.Login
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }
    }
}
