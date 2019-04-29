using Prestige_eSports.Core.Models;
using Prestige_eSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestige_eSports.Service.Interfaces
{
    public interface IProfileService
    {
        Task<Profile> GetById(int ProfileId);
        Task<Profile> DeleteProfile(Profile profile);
        Task<Profile> UpdateProfile(Profile profile);
        Task<Profile> InsertNewProfile(Profile profile);
        Profile GetFirstOrDefault(int id);
    }
}
