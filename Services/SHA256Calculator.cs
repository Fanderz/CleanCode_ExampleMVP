using System;
using System.Text;
using System.Security.Cryptography;
using CleanCode_ExampleMVP.Interfaces;

namespace CleanCode_ExampleMVP.Services
{
    public class SHA256Calculator : IHashCalculator
    {
        public string CalculateHash(string value) =>
            Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value)));
    }
}
