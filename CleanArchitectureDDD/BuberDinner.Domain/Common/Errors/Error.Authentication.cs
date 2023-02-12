using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials =>
            Error.Validation(code: "Auth.InvalidCredentials", description: "Invalid  Credentials");
        
        public static Error InvalidPassword =>
            Error.Validation(code: "Auth.InvalidPassword", description: "Invalid  Password");
    }
    
}