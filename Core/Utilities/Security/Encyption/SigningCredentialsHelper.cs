using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);//şifrelenen data hangi algoritmayla şifrelencek
        }
    }
}
