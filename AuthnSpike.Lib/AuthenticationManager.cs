using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace AuthnSpike.Lib
{
    public interface IAuthenticationManager
    {
        AuthenticationToken Authenticate(AuthenticationCredentials authenticationCredentials);
    }

    public class AuthenticationManager : IAuthenticationManager
    {
        public AuthenticationToken Authenticate(AuthenticationCredentials authenticationCredentials)
        {
            //bogus authentication implementation
            if (authenticationCredentials.Username == "username" && authenticationCredentials.Password == "password")
            {
                return new AuthenticationToken
                {
                    Username = "username",
                    IssuedAt = DateTime.Now,
                    ValidFor = new TimeSpan(1, 0, 0)
                };
            }
            else
            {
                throw new AuthenticationException("Invalid credentials supplied");
            }
        }
    }
}
