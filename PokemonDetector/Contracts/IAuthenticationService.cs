using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDetector.Contracts
{
    public interface IAuthenticationService
    {
        bool IsSignIn();
        Task<bool> CreateUser(string username, string email, string password);
        void SignOut();
        Task<string> SignIn(string email, string password);
        Task ResetPassword(string email);
    }
}
