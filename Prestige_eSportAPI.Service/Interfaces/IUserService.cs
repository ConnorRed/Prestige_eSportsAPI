using Prestige_eSports.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestige_eSports.Service.Interfaces
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
        IEnumerable<User> Get();
        Task<User> GetById(int UserId);
        Task InsertNewUser(User user);
        Task DeleteUser(User user);
        Task UpdateUser(User user);
    }
}
