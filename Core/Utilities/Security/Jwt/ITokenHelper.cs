using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper//Token üretimi gerçekleştirecek helper 
    //niye interface yaptı yarın öbür gün teknoloji değişince kullanılır olsun diye
    {

        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);//Claims roller
    }                          //Kullanıcı bilgisi,Rolleri
}
