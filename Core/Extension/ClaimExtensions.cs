using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extension
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims,string email)//metod neyi extend edicek,parametre
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));//bunu email kısmına kaydet,parametre ver
        }
        public static void AddName(this ICollection<Claim> claims, string name)//metod neyi extend edicek,parametre
        {
            claims.Add(new Claim(ClaimTypes.Name, name));//bunu email kısmına kaydet,parametre ver
        }
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)//metod neyi extend edicek,parametre
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));//bunu email kısmına kaydet,parametre ver
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)//rolleride eklemek lazım
            //metod neyi extend edicek,parametre
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role,role)));//
            //HER BİR ROLü git sisteme ekle claimlere ekle demek.O anki rolü ekle
            //bunu email kısmına kaydet,parametre ver
        }
    }
}
