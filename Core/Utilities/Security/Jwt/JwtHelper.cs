using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Security.Encyption;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Jwt
{
   public class JwtHelper:ITokenHelper
    {
        public IConfiguration Configuration { get;}
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration=DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateCredentials(securityKey);
        }

        public JwtSecurityToken CreatJwtSecurityToken(TokenOptions tokenOptions,User user,
            SigningCredentials signingCredentials,List<OperationClaim> claims)
        {
            var jwt = new JwtSecurityToken(
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,
                claims:operationClaims,
                signingCredentials:signingCredentials
                
                );
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims=new List<Claim>();
            claims.Add(new Claim("email",user.Email));
        }

    }//Signing
     //Credentials
     //Helper
}

/*İmzalama
Kimlik bilgileri
Yardımcı*/