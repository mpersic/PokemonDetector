using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PokemonDetector.Features.Login
{
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();

            BindingContext = new ForgotPasswordViewModel();
        }
    }
}
