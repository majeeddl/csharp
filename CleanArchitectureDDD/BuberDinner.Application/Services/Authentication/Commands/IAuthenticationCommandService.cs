using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands;


public interface IAuthenticationCommandService{
    // OneOf<AuthenticationResult,DuplicateEmailError> Register(string firstName, string lastName, string email, string password);
    // Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    // AuthenticationResult Register(string firstName, string lastName, string email, string password);
    
}