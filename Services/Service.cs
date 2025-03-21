using System;
using CleanCode_ExampleMVP.Models;

namespace CleanCode_ExampleMVP.Services
{
    public class Service
    {
        public Citizen GetCitizen(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException();

            return new Citizen(new Repository().IsAccess(DatabaseContext.ExecuteQuery(new PassportQueryCreator().GenerateQuery(new SHA256Calculator().CalculateHash(number)))));
        }
    }
}
