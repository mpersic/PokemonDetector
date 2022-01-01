using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace PokemonDetector.Contracts
{
    
        public interface IToastProvider
        {
            void LongAlert(string message);
            void ShortAlert(string message);
        }

}
