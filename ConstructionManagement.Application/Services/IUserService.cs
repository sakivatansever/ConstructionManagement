using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Application.Services
{
    public interface IUserService
    {

        Task<IdentityResult> RegisterAsync(string username, string password);


        Task<string> LoginAsync(string username, string password);


        Task<string> LogoutAsync();
    }
}
