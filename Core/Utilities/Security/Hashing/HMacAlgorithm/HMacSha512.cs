using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing.HMacAlgorithm
{
    public  class HMacSha512
    {
        public static HMAC CreateHmac( )
        {
            var hmac = new System.Security.Cryptography.HMACSHA512();
            return hmac;
            
        }
        public static byte[] Hashing(string password)
        {
            var hmac = CreateHmac();
            var result=hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return result;
        }
    }
}
