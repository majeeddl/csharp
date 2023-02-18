

using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;


public class LoginQueryHandler : IRequestHandler<LoginQuery,ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user) throw new Exception("User with this email does not  exists");
        
        // 2. Validate the password is correct
        if (user.Password != query.Password) throw new Exception("Invalid password");
        
        // 3. Create new JWT
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        
        return new AuthenticationResult(user.Id,user.FirstName, user.LastName,user.Email, token);
    }


}