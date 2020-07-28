using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Dtos
{
    public class UserForRegisterDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }//kullanıcadann geleni hashe çeviricez saltlayıp göndercez
        //Password diye bir alan yok veritabanında onun için dtoyla o alanı oluşturuk
        //Olmayan alanlar için yapalır.
        //Sadece işimiz görecek nesneler üretmek için kullanılır.
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
