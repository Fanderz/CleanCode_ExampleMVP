using System;
using System.Data;
using CleanCode_ExampleMVP.Services;

namespace CleanCode_ExampleMVP.Models
{
    public class Passport
    {
        public Passport(string passport)
        {
            if (string.IsNullOrEmpty(passport))
                throw new ArgumentNullException();

            if (passport.Length < 10)
                throw new ArgumentOutOfRangeException();

            Number = passport.Trim().Replace(" ", string.Empty);
        }

        public string Number { get; private set; }
    }
}
