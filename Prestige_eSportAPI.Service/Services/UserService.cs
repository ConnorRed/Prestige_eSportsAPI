using Prestige_eSports.Core.Models;
using Prestige_eSports.Repo.UnitOfWork;
using Prestige_eSports.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prestige_eSports.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> DeleteUser(User user) => await _unitOfWork.GenericRepository<User>().DeleteAysnc(user);

        public IEnumerable<User> Get() => _unitOfWork.GenericRepository<User>().Get();

        public async Task<User> InsertNewUser(User user)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                     return await _unitOfWork.GenericRepository<User>().InsertAysnc(user);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<User> UpdateUser(User user) => await _unitOfWork.GenericRepository<User>().UpdateAysnc(user);

        public async Task<User> GetById(int UserId) => await _unitOfWork.GenericRepository<User>().GetById(UserId);

        public User ValidateUser(string username, string password) => _unitOfWork.GenericRepository<User>().GetFirstOrDefault(x => x.Email == username && x.Password == password);
    }
}
