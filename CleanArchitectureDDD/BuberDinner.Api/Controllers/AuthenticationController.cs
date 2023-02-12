using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace BuberDinner.Api.Controllers;


[ApiController]
[Route(("auth"))]
public class AuthenticationController : ControllerBase
{

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName,
            authResult.Email, authResult.Token);
        return response;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {

        // var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        //
        //
        // return Ok(response);
        //
        // OneOf<AuthenticationResult,DuplicateEmailError> registerResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        //
        // if (registerResult.IsT0)
        // {
        //     var authResult = registerResult.AsT0;
        //
        //     var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName,
        //         authResult.Email, authResult.Token);
        //
        //     return Ok(response);
        // }
        // else
        // {
        //     return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists");
        // }
        
        // Result<AuthenticationResult> registerResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        //
        // if (registerResult.IsSuccess)
        // {
        //     return Ok(MapAuthResult(registerResult.Value));
        // }
        //
        //
        // var firstError = registerResult.Errors[0];
        //
        // return firstError is DuplicateEmailError ? Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists") : Problem();
        
        ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return authResult.MatchFirst(
            authResult => Ok(MapAuthResult(authResult)),
            firstError => Problem(statusCode:StatusCodes.Status409Conflict, title: firstError.Description)
        );
    }

    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);
        
        var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email,authResult.Token);
        
        return Ok(response);
    }
}