using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands;


public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    // public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    // public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    // public OneOf<AuthenticationResult,DuplicateEmailError> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            // throw new Exception("User with given email already exists");
            // return Result.Fail<AuthenticationResult>( new []{  new DuplicateEmailError() });
            return Errors.User.DuplicateEmail;
        }
        
        
        
        // 2. Create user (generate unique ID) & Persist  to DB 
        var user = new User{ FirstName = firstName, LastName = lastName,Email = email,Password = password};
        
        _userRepository.Add(user);
        
        // 3. Create JWT token
        // Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);
        
        return new AuthenticationResult(user , token);
    }

   
}