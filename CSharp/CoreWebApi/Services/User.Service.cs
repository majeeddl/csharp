using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CoreWebApi.Entities;
using CoreWebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CoreWebApi.Services
{
    public interface IUserService{
        User Authenticate(string username,string password);
        IEnumerable<User> GetAll();
    }


    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "majeed", Password = "1234" },
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings){
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
             var user = _users.SingleOrDefault(x=> x.Username == username && x.Password == password);

             if(user == null){
                 return null;
             }

             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
             var tokenDescriptor = new SecurityTokenDescriptor{
                 Subject = new ClaimsIdentity(
                     new Claim[]{
                         new Claim(ClaimTypes.Name,user.Username.ToString())
                     }
                 ),
                 Expires = DateTime.UtcNow.AddDays(7),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
             };

             var token = tokenHandler.CreateToken(tokenDescriptor);
             user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;

        }

        public IEnumerable<User> GetAll()
        {
            return _users.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }

        public bool IsUserExist(User user)
        {
            bool isExist;

            var userName = user.Username.ToLower();
            isExist = _users.Any(n => n.Username == userName);

            return isExist;
        }

        public IEnumerable<User> Insert(User user)
        {
            _users.Add(user);
            return _users;
        }
    }
}