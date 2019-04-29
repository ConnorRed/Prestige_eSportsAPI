using Prestige_eSports.Core.Models;
using Prestige_eSports.Data.Models;
using Prestige_eSports.Repo.UnitOfWork;
using Prestige_eSports.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestige_eSports.Service.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Profile> DeleteProfile(Profile profile) => await _unitOfWork.GenericRepository<Profile>().DeleteAysnc(profile);

        public Task<Profile> GetById(int ProfileId) => _unitOfWork.GenericRepository<Profile>().GetById(ProfileId);

        public Profile GetFirstOrDefault(int id) => _unitOfWork.GenericRepository<Profile>().GetFirstOrDefault(x => x.ProfileId == id);

        public async Task<Profile> UpdateProfile(Profile profile) => await _unitOfWork.GenericRepository<Profile>().UpdateAysnc(profile);

        public async Task<Profile> InsertNewProfile(Profile profile) => await _unitOfWork.GenericRepository<Profile>().InsertAysnc(profile);
    }
}
