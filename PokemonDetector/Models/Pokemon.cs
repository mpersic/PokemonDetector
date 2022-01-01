using PokemonDetector.ViewModels;
using System;
namespace PokemonDetector.Models
{
    public class Pokemon: BaseViewModel
    {
        public string Name { get; set; }
        public string AttackDamage { get; set; }
        public string Type { get; set; }
    }
}
