using System;

namespace CleanCode_ExampleMVP.Models
{
    public class Passport
    {
        public Passport(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException();

            if (number.Length < 10)
                throw new ArgumentOutOfRangeException();

            Number = number.Trim().Replace(" ", string.Empty);
        }

        public string Number { get; private set; }
    }
}
