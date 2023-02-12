using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

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

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {

        var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        
        var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email,authResult.Token);
        
        return Ok(response);
        
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
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);
        
        var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email,authResult.Token);
        
        return Ok(response);
    }
}