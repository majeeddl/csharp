using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly static List<User> Users = new();
    
    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        Users.Add(user);
    }
}
