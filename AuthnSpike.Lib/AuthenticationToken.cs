using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthnSpike.Lib
{
    public class AuthenticationToken
    {
        public string Username { get; internal set; }

        public DateTime IssuedAt { get; internal set; }

        public TimeSpan ValidFor { get; internal set; }
    }
}
