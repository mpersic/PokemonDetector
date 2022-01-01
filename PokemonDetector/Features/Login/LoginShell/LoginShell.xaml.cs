namespace PokemonDetector.Features.Shell
{
    public partial class LoginShell
    {
        public LoginShell()
        {
            InitializeComponent();

            BindingContext = new LoginShellViewModel();
        }
    }
}
