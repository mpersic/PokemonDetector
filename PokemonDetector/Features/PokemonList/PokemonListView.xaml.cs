using PokemonDetector.Data;
using PokemonDetector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamFormsFirebaseAuth.Features.Shell;

namespace PokemonDetector.Views
{

    public partial class PokemonListView: ContentPage
    {
        public PokemonListViewModel _viewModel;
        public PokemonListView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PokemonListViewModel();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
