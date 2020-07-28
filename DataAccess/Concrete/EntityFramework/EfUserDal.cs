using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User, NorthwindContext>,IUserDal
    {
        //gönderlien userin claimleri joinle çekilir.
        public List<OperationClaim> GetClaims(User user)//kullanıcının yetkileri listelenecek
        {
            using (var context=new NorthwindContext())
            {
                //iki tabloyu join edicez.
                //result Iqueryable döner
                var result = from operationClaim in context.OperationClaims//contextteki operaion claimlerle
                    join UserOperationClaim in context.UserOperationClaims
                    //User operation claimleri birlşetir.
                        on operationClaim.Id equals UserOperationClaim.OperationClaimId
                        //operaitonclaimdeki Id  useroperaitonclaimdeki Idye eşit olduğğunda
                    where UserOperationClaim.UserId == user.Id//Useroperation
                    select new OperationClaim//operation claim listesi
                    {
                        Id = operationClaim.Id,
                        Name = operationClaim.Name,
                        
                        
                    };
                return result.ToList();
                //gönderdiğimiz userların claimlerini joinle çekmiş olduk. 
            }
        }

       
    }
}
