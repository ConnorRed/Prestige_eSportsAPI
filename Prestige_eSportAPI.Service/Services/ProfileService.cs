using Prestige_eSports.Core.Models;
using Prestige_eSports.Data.Models;
using Prestige_eSports.Repo.UnitOfWork;
using Prestige_eSports.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestige_eSports.Service.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Profile> Get(User user) => _unitOfWork.GenericRepository<Profile>().Get(x => x.User.UserId == user.UserId);

        public int InsertNewProfile(Profile profile)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {

                    _unitOfWork.GenericRepository<Profile>().InsertAysnc(profile);
                    _unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }

                return profile.ProfileId;
            }

        }
    }
}
