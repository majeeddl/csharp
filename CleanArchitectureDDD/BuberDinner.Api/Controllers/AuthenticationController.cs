using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace BuberDinner.Api.Controllers;


[ApiController]
[Route(("auth"))]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly  IMapper _mapper;
    // private readonly IAuthenticationCommandService _authenticationCommandService;
    // private readonly IAuthenticationQueryService _authenticationQuery;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        // _authenticationCommandService = authenticationCommandService;
        // _authenticationQuery = authenticationQuery;
        _mediator = mediator;
        _mapper = mapper;
    }
    
    // private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    // {
    //     var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName,
    //         authResult.Email, authResult.Token);
    //     return response;
    // }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
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

        // var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

        var command = _mapper.Map<RegisterCommand>(request);
        
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
        // ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        // return authResult.MatchFirst(
        //     authResult => Ok(MapAuthResult(authResult)),
        //     firstError => Problem(statusCode:StatusCodes.Status409Conflict, title: firstError.Description)
        // );
        
        return authResult.MatchFirst(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            firstError => Problem(statusCode:StatusCodes.Status409Conflict, title: firstError.Description)
        );
    }

    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        // var query = new LoginQuery(request.Email, request.Password); 
        var query = _mapper.Map<LoginQuery>(request);
        
        var authResult = await _mediator.Send(query);

        if (authResult.IsError)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }

        // return authResult.Match(
        //     authResult => Ok(MapAuthResult(authResult)),
        //     //TODO : fix errors instead of string error
        //     errors => Problem("errors ")
        //     );
        
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
            //TODO : fix errors instead of string error
            errors => Problem("errors ")
        );
    }
}