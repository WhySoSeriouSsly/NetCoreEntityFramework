using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService//sisteme login veya register olcam 
    {//Login olmak demek kullanıcın varlığının kontrolü demek
     //Register olmak demek kullanıcın sisteme kayıt olması yani ona bir result veriyoruz.

        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);//kullanıcı varmı diye bakıyor.//Daha önceden kayıt olmuşsa mesaj verir.
        IDataResult<AccessToken> CreateAccessToken(User user);//kullanıcı bilgisi lazım token oluşsun diye



    }
}
