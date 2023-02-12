using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using FluentResults;
using OneOf;

namespace BuberDinner.Application.Services.Authentication;


public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    // public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    // public OneOf<AuthenticationResult,DuplicateEmailError> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            // throw new Exception("User with given email already exists");
            return Result.Fail<AuthenticationResult>( new []{  new DuplicateEmailError() });
        }
        
        
        // 2. Create user (generate unique ID) & Persist  to DB 
        var user = new User{ FirstName = firstName, LastName = lastName,Email = email,Password = password};
        
        _userRepository.Add(user);
        
        // 3. Create JWT token
        // Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);
        
        return new AuthenticationResult(user.Id,firstName,lastName,email , token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user) throw new Exception("User with this email does not  exists");
        
        // 2. Validate the password is correct
        if (user.Password != password) throw new Exception("Invalid password");
        
        // 3. Create new JWT
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        
        return new AuthenticationResult(user.Id,user.FirstName, user.LastName,email, token);
    }
}