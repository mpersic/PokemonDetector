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
        public PokemonListViewModel(IDataStore<Pokemon> dataStore)
        {
            Pokemons = new ObservableRangeCollection<Pokemon>();
            this.DataStore = dataStore;
            LoadItemsCommand = new Command(async () => await LoadItems());
            SignOutCommand = new Command(OnSignOut);
        }

        #region Commands

        public Command LoadItemsCommand { get; }
        public Command SignOutCommand { get; }
        #endregion
        public ObservableRangeCollection<Pokemon> Pokemons { get; set; }
        public IDataStore<Pokemon> DataStore { get; }

        public async void OnAppearing()
        {
            await LoadItems();
        }

        public async Task LoadItems()
        {
            IsBusy = true;

            //await AddItems();          

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

        private async Task AddItems()
        {
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Abra", Category = "Category: Psi", ImageName = "abra.png", Type = "Type: Psychic" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Aerodactyl", Category = "Category: Fossil", ImageName = "aerodactyl.png", Type = "Type: Rock, Flying" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Arbok", Category = "Category: Cobra", ImageName = "arbok.png", Type = "Type: Poison" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Blastoise", Category = "Category: Shellfish", ImageName = "blastoise.png", Type = "Type: Water" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Bulbasaur", Category = "Category: Seed", ImageName = "bulbasaur.png", Type = "Type: Grass, Poison" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Caterpie", Category = "Category: Worm", ImageName = "caterpie.png", Type = "Type: Bug" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Chansey", Category = "Category: Egg", ImageName = "chansey.png", Type = "Type: Normal" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Charizard", Category = "Category: Flame", ImageName = "charizard.png", Type = "Type: Fire, Flying" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Charmander", Category = "Category: Lizard", ImageName = "charmander.png", Type = "Type: Fire" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Diglett", Category = "Category: Mole", ImageName = "diglett.png", Type = "Type: Ground" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Dodrio", Category = "Category: Tripple Bird", ImageName = "dodrio.png", Type = "Type: Normal, Flying" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Doduo", Category = "Category: Twin Bird", ImageName = "doduo.png", Type = "Type: Normal, Flying" });


            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Dragonair", Category = "Category: Dragon", ImageName = "dragonair.png", Type = "Type: Dragon" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Dragonite", Category = "Category: Dragon", ImageName = "dragonite.png", Type = "Type: Dragon, Flying" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Dratini", Category = "Category: Dragon", ImageName = "dratini.png", Type = "Type: Dragon" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Dugtrio", Category = "Category: Mole", ImageName = "dugtrio.png", Type = "Type: Ground" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Eevee", Category = "Category: Evolution", ImageName = "eevee.png", Type = "Type: Normal" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Ekans", Category = "Category: Snake", ImageName = "ekans.png", Type = "Type: Poison" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Electrode", Category = "Category: Ball", ImageName = "electrode.png", Type = "Type: Electric" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Fearow", Category = "Category: Beak", ImageName = "fearow.png", Type = "Type: Normal, Flying" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Flareon", Category = "Category: Flame", ImageName = "flareon.png", Type = "Type: Fire" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Gastly", Category = "Category: Gas", ImageName = "gastly.png", Type = "Type: Ghost, Poison" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Gengar", Category = "Category: Shadow", ImageName = "gengar.png", Type = "Type: Ghost, Poison" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Geodude", Category = "Category: Rock", ImageName = "geodude.png", Type = "Type: Rock, Ground" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Gloom", Category = "Category: Weed", ImageName = "gloom.png", Type = "Type: Grass, Poison" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Golduck", Category = "Category: Duck", ImageName = "golduck.png", Type = "Type: Water" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Gyarados", Category = "Category: Atrocious", ImageName = "gyarados.png", Type = "Type: Water, Flying" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Hitmonchan", Category = "Category: Punching", ImageName = "hitmonchan.png", Type = "Type: Fighting" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Hitmoonlee", Category = "Category: Kicking", ImageName = "hitmonlee.png", Type = "Type: Fighting" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Hypno", Category = "Category: Hypnosis", ImageName = "hypno.png", Type = "Type: Psychic" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Ivysaur", Category = "Category: Seed", ImageName = "ivysaur.png", Type = "Type: Grass, Poison" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Jigglypuff", Category = "Category: Baloon", ImageName = "jigglypuff.png", Type = "Type: Normal, Fairy" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Jolteon", Category = "Category: Lighting", ImageName = "jolteon.png", Type = "Type: Electric" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Kadabra", Category = "Category: Psi", ImageName = "kadabra.png", Type = "Type: Psychic" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Kangaskhan", Category = "Category: Parent", ImageName = "kangaskhan.png", Type = "Type: Normal" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Lapras", Category = "Category: Transport", ImageName = "lapras.png", Type = "Type: Water, Ice" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Machoke", Category = "Category: Superpower", ImageName = "machoke.png", Type = "Type: Fighting" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Magikarp", Category = "Category: Fish", ImageName = "magikarp.png", Type = "Type: Water" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Magnemite", Category = "Category: Magnet", ImageName = "magnemite.png", Type = "Type: Electric, Steel" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Magneton", Category = "Category: Magnet", ImageName = "magneton.png", Type = "Type: Electric, Steel" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Muk", Category = "Category: Sludge", ImageName = "muk.png", Type = "Type: Poison" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Ninetales", Category = "Category: Fox", ImageName = "ninetales.png", Type = "Type: Fire" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Onix", Category = "Category: Rock Snake", ImageName = "onix.png", Type = "Type: Rock, Ground" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Pidgey", Category = "Category: Tiny Bird", ImageName = "pidgey.png", Type = "Type: Normal, Flying" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Pikachu", Category = "Category: Mouse", ImageName = "pikachu.png", Type = "Type: Electric" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Poliwrath", Category = "Category: Tadpole", ImageName = "poliwrath.png", Type = "Type: Water, Fighting" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Raichu", Category = "Category: Mouse", ImageName = "raichu.png", Type = "Type: Electric" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Snorlax", Category = "Category: Sleeping", ImageName = "snorlax.png", Type = "Type: Normal" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Squirtle", Category = "Category: Tiny Turtle", ImageName = "squirtle.png", Type = "Type: Water" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Venomoth", Category = "Category: Poison Moth", ImageName = "venomoth.png", Type = "Type: Bug, Poison" });
            await DataStore.AddItemAsync(new Pokemon { Name = "Name: Zapdos", Category = "Category: Electric", ImageName = "zapdos.png", Type = "Type: Electric, Flying" });
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
