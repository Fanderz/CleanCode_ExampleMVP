using System;
using CleanCode_ExampleMVP.Interfaces;

namespace CleanCode_ExampleMVP.Services
{
    class PassportQueryCreator : IQueryCreator
    {
        private const string DefaultQueryString = "select * from passports where num = 'value' limit 1;";
        private const string TextToReplace = "value";

        public string GenerateQuery(string valueToFind)
        {
            if (string.IsNullOrEmpty(valueToFind))
                throw new ArgumentNullException();

            return DefaultQueryString.Replace(TextToReplace, valueToFind);
        }
    }
}
