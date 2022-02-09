using WebApiJwt.Entities;
using WebApiJwt.Utils;

namespace WebApiJwt.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        IEnumerable<User> GetAll();

        User GetById(int id);

    }
}
