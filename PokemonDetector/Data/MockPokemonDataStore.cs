using PokemonDetector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDetector.Data
{
    public class MockPokemonDataStore : IDataStore<Pokemon>
    {
        public readonly List<Pokemon> items;

        public MockPokemonDataStore()
        {
            items = new List<Pokemon>()
            {
                new Pokemon{ Name = "Name: Pikatchu", AttackDamage = "Attack Damage: 9000",  Type = "Type: Electric"},
                new Pokemon{ Name = "Name: Pikatchu", AttackDamage = "Attack Damage: 9000",  Type = "Type: Electric"},
                new Pokemon{ Name = "Name: Pikatchu", AttackDamage = "Attack Damage: 9000",  Type = "Type: Electric"},
                new Pokemon{ Name = "Name: Pikatchu", AttackDamage = "Attack Damage: 9000",  Type = "Type: Electric"},
                new Pokemon{ Name = "Name: Pikatchu", AttackDamage = "Attack Damage: 9000",  Type = "Type: Electric"}
            };
        }
        public async Task<bool> AddItemAsync(Pokemon item)
        {
            items.Add(item);

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
            return await Task.FromResult(items);
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
