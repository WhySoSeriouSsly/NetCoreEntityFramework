using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {//Kullanıcı claim getirme sahip olduğu yetkileri getirme

        List<OperationClaim> GetClaims(Core.Entities.Concrete.User user);
        void Add(Core.Entities.Concrete.User user);
        User GetByMail(string email);//maille kullanıcı bulma


    }
}
