using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;


namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand,ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            // throw new Exception("User with given email already exists");
            // return Result.Fail<AuthenticationResult>( new []{  new DuplicateEmailError() });
            return Errors.User.DuplicateEmail;
        }
        
        
        
        // 2. Create user (generate unique ID) & Persist  to DB 
        var user = new User{ FirstName = command.FirstName, LastName = command.LastName,Email = command.Email,Password = command.Password};
        
        _userRepository.Add(user);
        
        // 3. Create JWT token
        // Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(user.Id,user.FirstName,user.LastName);
        
        return new AuthenticationResult(user , token);
    }
}