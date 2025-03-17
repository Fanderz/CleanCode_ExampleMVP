using System;

namespace CleanCode_ExampleMVP.Models
{
    class VotingModel
    {
        public string Passport { get; private set; }
        public bool HaveAccess { get; private set; }

        public void SetAccess(bool value)
        {
            HaveAccess = value;
        }

        public void SetPassport(string passport)
        {
            if (string.IsNullOrEmpty(passport))
                throw new ArgumentNullException();

            Passport = passport;
        }
    }
}
