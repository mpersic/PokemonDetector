using PokemonDetector.ViewModels;
using System;
using System.Collections.Generic;
using TinyMvvm.IoC;
using Xamarin.Forms;

namespace PokemonDetector.Views
{
    public partial class ImagePickingView :ContentPage
    {
        public ImagePickingViewModel _viewModel;
        public ImagePickingView()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ImagePickingViewModel();

        }
    }
}
