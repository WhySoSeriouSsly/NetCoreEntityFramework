using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }//tokenin kullanıcı kitlesi
        public string Issuer { get; set; }//imzalayan
        public int AccessTokenExpiration { get; set; }//tokenin geçerliliği dakika olarak
        public string SecurityKey { get; set; }//güvenlik anahtarı
    }
}
