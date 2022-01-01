
using Xamarin.Forms;

namespace PokemonDetector.Features.Login
{
    public partial class NewUserPage : ContentPage
    {
        public NewUserPage()
        {
            InitializeComponent();

            BindingContext = new NewUserViewModel();
        }
    }
}
