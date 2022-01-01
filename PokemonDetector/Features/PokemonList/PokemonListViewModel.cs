using MvvmHelpers;
using PokemonDetector.Contracts;
using PokemonDetector.Data;
using PokemonDetector.Models;
using PokemonDetector.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TinyMvvm;
using Xamarin.Forms;
using PokemonDetector.Features.Shell;
using PokemonDetector.Features.Login;

namespace PokemonDetector.ViewModels
{
    public class PokemonListViewModel : BaseViewModel
    {
        public PokemonListViewModel()
        {
            Pokemons = new ObservableRangeCollection<Pokemon>();
            DataStore = new MockPokemonDataStore();
            LoadItemsCommand = new Command(async () => await LoadItems());
            SignOutCommand = new Command(OnSignOut);
        }

        public Command LoadItemsCommand { get; }
        public Command SignOutCommand { get; }
        public ObservableRangeCollection<Pokemon> Pokemons { get; set; }
        public IDataStore<Pokemon> DataStore { get; }

        public async void OnAppearing()
        {
            await LoadItems();
        }

        public async Task LoadItems()
        {
            IsBusy = true;

            try
            {
                Pokemons.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Pokemons.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                ToastProvider.LongAlert("Something went wrong when loading Pokemon");
            }
            finally
            {
                IsBusy = false;
            }

        }
        private void OnSignOut()
        {
            try
            {
                var authService = DependencyService.Resolve<IAuthenticationService>();
                authService.SignOut();
                Application.Current.MainPage = new LoginShell();
            }
            catch (Exception ex)
            {
                ToastProvider.LongAlert("Something went wrong when signing out!");
            }
        }

    }
}
