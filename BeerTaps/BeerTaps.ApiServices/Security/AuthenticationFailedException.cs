using System;

namespace BeerTaps.ApiServices.Security
{
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException(string message)
            : base(message)
        {
        }

        public AuthenticationFailedException()
            : base("Authentication failed")
        {
        }
    }
}