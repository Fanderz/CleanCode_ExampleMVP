using System;
using System.Text;
using System.Security.Cryptography;
using CleanCode_ExampleMVP.Models;

namespace CleanCode_ExampleMVP.Services
{
    public static class HashCalculator
    {
        public static string CalculateHash(Passport passport) =>
            Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(passport.Number)));
    }
}
