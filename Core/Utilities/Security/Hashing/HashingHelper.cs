using Core.Utilities.Security.Hashing.HMacAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {//out keywordü siz parametreyi gönderdiğinizde değişen nesne aynı zamanda byte[] arrayine aktarılcak.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//kendisi bir salt vasıtasıyla Computehashi oluşturdu
                                                                                  //o oluşturduğu saltıda biz key olarak parametre olarak verdiğimiz salta atadık.//pASS hashede oluşan hashi verdik.
            }
        }

        public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)//password hashini doğrulama 
        {
            using (HMacSha512.CreateHmac())//var hmac = new System.Security.Cryptography.HMACSHA512();
            {
                var computedHash = HMacSha512.Hashing(password);//hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;
            }
        }
    }
}


