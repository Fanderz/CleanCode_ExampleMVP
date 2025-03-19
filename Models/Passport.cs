using System;
using System.Data;
using CleanCode_ExampleMVP.Services;

namespace CleanCode_ExampleMVP.Models
{
    class Passport
    {
        private SqlQueryExecutor _sqlExecutor;
        private string _passport;

        public Passport(string passport)
        {
            if (string.IsNullOrEmpty(passport))
                throw new ArgumentNullException();

            if (passport.Length < 10)
                throw new ArgumentOutOfRangeException();

            _sqlExecutor = new SqlQueryExecutor();
            _passport = passport;
        }

        public bool? GetPassport()
        {
            DataTable result = _sqlExecutor.ExecuteQuery($"select * from passports where num = '{HashCalculator.CalculateHash(_passport)}' limit 1;");

            if (result.Rows.Count > 0)
                return Convert.ToBoolean(result.Rows[0].ItemArray[1]);
            else
                return null;
        }
    }
}
