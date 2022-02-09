using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApiJwt.Entities;
using WebApiJwt.Helpers;
using WebApiJwt.Interfaces;
using WebApiJwt.Utils;

namespace WebApiJwt.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User() { Id = 1, Username = "admin", Password = "admin", FirstName = "admin", LastName = "admin" }
        };

        private readonly AppSettings _appSettings;


        public UserService(IOptions<AppSettings> appSetting)
        {
            _appSettings = appSetting.Value;
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _users.SingleOrDefault(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null) return null;

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

    }

}