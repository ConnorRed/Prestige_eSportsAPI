using Prestige_eSports.Core.Models;
using Prestige_eSports.Repo.UnitOfWork;
using Prestige_eSports.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestige_eSports.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> Get() => _unitOfWork.GenericRepository<User>().Get();

        public int InsertNewUser(User user)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    _unitOfWork.GenericRepository<User>().InsertAysnc(user);
                    _unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            return user.UserId;
        }

        public User ValidateUser(string username, string password) => _unitOfWork.GenericRepository<User>().GetFirstOrDefault(x => x.Email == username && x.Password == password);
    }
}
