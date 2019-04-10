using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Prestige_eSports.Core.Models;
using Prestige_eSports.Repo.UnitOfWork;
using Prestige_eSports.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Prestige_eSportsAPI.Helpers;

namespace Prestige_eSports.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly AppSetting _appSettings;

        public UserService(IUnitOfWork unitOfWork, IOptions<AppSetting> settings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = settings.Value;
        }

        public async Task<User> DeleteUser(User user) => await _unitOfWork.GenericRepository<User>().DeleteAysnc(user);

        public IEnumerable<User> Get() => _unitOfWork.GenericRepository<User>().Get();

        public async Task<User> InsertNewUser(User user) =>
             await _unitOfWork.GenericRepository<User>().InsertAysnc(user);

        public async Task<User> UpdateUser(User user) => await _unitOfWork.GenericRepository<User>().UpdateAysnc(user);

        public async Task<User> GetById(int UserId) => await _unitOfWork.GenericRepository<User>().GetById(UserId);

        public string ValidateUser(string username, string password) {
            var user = _unitOfWork.GenericRepository<User>().GetFirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SuperSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
