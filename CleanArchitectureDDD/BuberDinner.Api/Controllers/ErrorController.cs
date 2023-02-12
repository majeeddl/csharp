using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("/error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            // var (statusCode, message) = exception switch
            // {
            //     DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists."),
            //     _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
            // };
            //
            var (statusCode, message) = exception switch
            {
                 IServiceException  serviceException => ((int)serviceException.StatusCode,serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
            };


            
            // return Problem(title:exception?.Message);
            return Problem(statusCode: statusCode,title: message);
        }
    }
}
