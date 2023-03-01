using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Services.Authentication.Common;
using MediatR;
using ErrorOr;
using FluentValidation;

namespace BuberDinner.Application.Common.Behaviors;


public class ValidateBehavior<TRequest,TResponse> : 
    IPipelineBehavior<TRequest,TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{

    private readonly IValidator<TRequest>? _validator;

    public ValidateBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        ////before the request is handled
        //var result = await next();

        ////after the request is handled
        //return result;

        if (_validator == null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors.ConvertAll(validateFailure =>
            Error.Validation(validateFailure.PropertyName, validateFailure.ErrorMessage));

        return (dynamic)errors;
    }
}
