using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Katya.Extensions
{
    public static class ConversionExtensions
    {
        public static short ToInt16(this object obj)
        {
            return Convert.ToInt16(obj);
        }

        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static long ToInt64(this object obj)
        {
            return Convert.ToInt64(obj);
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ToMD5(this string str)
        {
            return ComputeHash(MD5.Create(), str);
        }

        public static string ToSHA1(this string str)
        {
            return ComputeHash(SHA1.Create(), str);
        }

        public static string ToSHA256(this string str)
        {
            return ComputeHash(SHA256.Create(), str);
        }

        public static string ToSHA512(this string str)
        {
            return ComputeHash(SHA512.Create(), str);
        }

        private static string ComputeHash(HashAlgorithm hashAlgorithm, string str)
        {
            byte[] rawBytes = Encoding.ASCII.GetBytes(str);
            byte[] hashBytes = hashAlgorithm.ComputeHash(rawBytes);
            return string.Join("", hashBytes.Select(x => x.ToString("x2")));
        }
    }
}
