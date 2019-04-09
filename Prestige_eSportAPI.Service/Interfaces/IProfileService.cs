using Prestige_eSports.Core.Models;
using Prestige_eSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestige_eSports.Service.Interfaces
{
    public interface IProfileService
    {
        IEnumerable<Profile> Get(User user);
        int InsertNewProfile(Profile profile);
    }
}
