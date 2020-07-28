using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)//kayıttan sonra access token üreticez
            //kullanıcmızın login veya kayıt olduktan sonra kullanıcıya token vercez kullanıcı o tokenla iş yapcak
        {
            var claims = _userService.GetClaims(user);
            var accesToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accesToken,Messages.TokenCreated);

        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            //kullanıcnın gönderdiği şifreyi biz bu şifreyi saltla hashleyip veritabanındaki hashle aynımı diye kontrol edicez.
            //Kullanıcın verdiği şifreyi hashlicek bir helper lazım//Şifreyi kontrol eden bir operasyon lazım.
            //Kodu alıp saltla beraber burda hashleyebilirim ama daha sonra biyerde kullanabilirim diye bunu helper yapcam 
            //Ve static metod olcak
            if (!HashingHelper.VerifyPassword(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.WrongPassword);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.LoginSuccess);
            //passwordler eşleşmiyorsa 


        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)//işlem bitince passhash ve pass salt oluşcak bitince
        {
            
            byte[] passHash, passSalt;//şuan içleri boş 
            HashingHelper.CreatePasswordHash(password, out passHash, out passSalt);//burda deişince yukardada değişcekler.
            User user = new User()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passHash,
                PasswordSalt = passSalt,
                Status = true,//ilk kez mi kayıt //false veririz emailde doğrulma isteriz veya yönetici filan true yapmalı
              };
            if (UserExists(userForRegisterDto.Email)!=null )//Burası keyfi biryer
            {
                return new ErrorDataResult<User>(Messages.UserFound);
            }
            //kontrol
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.RegisterCompleted);

        }

        public IResult UserExists(string email)//kullanıcı sistemde varmı yokmu 
        {
            var userToCheck = _userService.GetByMail(email);//sistemde böyle biri yoksa register olcak
            if (userToCheck != null)
            {
                return new ErrorResult(Messages.UserFound);
            }
            return new SuccessResult(Messages.UserNotFound);

        }
    }
}
