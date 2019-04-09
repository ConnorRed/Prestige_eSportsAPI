using Prestige_eSports.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestige_eSports.Service.Interfaces
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
        IEnumerable<User> Get();
        int InsertNewUser(User user);
    }
}
