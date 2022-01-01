using Firebase.Database;
using Firebase.Database.Query;
using MvvmHelpers;
using PokemonDetector.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDetector.Data
{
    public class MockPokemonDataStore : IDataStore<Pokemon>
    {
        public List<Pokemon> items { get; set; } 
        private FirebaseClient firebaseClient = new FirebaseClient("https://xamarin-pokedex-default-rtdb.europe-west1.firebasedatabase.app/");


        public MockPokemonDataStore()
        {
            items = new List<Pokemon>();
        }
        public async Task<bool> AddItemAsync(Pokemon item)
        {
            await firebaseClient.Child("Pokemons").PostAsync( new Pokemon 
            {
                Name = item.Name,
                AttackDamage = item.AttackDamage,
                Type = item.Type,
            });
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string name)
        {
            var oldItem = items.Where((Pokemon arg) => arg.Name == name).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Pokemon> GetItemAsync(string name)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Name == name));
        }

        public async Task<IEnumerable<Pokemon>> GetItemsAsync(bool forceRefresh = false)
        {
            List<Pokemon> pokemons = (
                await firebaseClient
                .Child("Pokemons")
                .OnceAsync<Pokemon>())
                .Select(item => new Pokemon
                {
                    Name = item.Object.Name,
                    AttackDamage = item.Object.AttackDamage,
                    Type = item.Object.Type,
                }).ToList();

            return await Task.FromResult(pokemons);
        }

        public async Task<bool> UpdateItemAsync(Pokemon item)
        {
            var oldItem = items.Where((Pokemon arg) => arg.Name == item.Name).FirstOrDefault();
            int oldIndex = items.IndexOf(oldItem);
            items.Remove(oldItem);
            items.Insert(oldIndex, item);

            return await Task.FromResult(true);
        }
    }
}
