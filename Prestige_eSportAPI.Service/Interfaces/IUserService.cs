using Prestige_eSports.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestige_eSports.Service.Interfaces
{
    public interface IUserService
    {
        string ValidateUser(string username, string password);
        IEnumerable<User> Get();
        Task<User> GetById(int UserId);
        Task<User> InsertNewUser(User user);
        Task<User> DeleteUser(User user);
        Task<User> UpdateUser(User user);
    }
}
