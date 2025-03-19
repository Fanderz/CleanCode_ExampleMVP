using CleanCode_ExampleMVP.Models;
using System;
using System.Data;

namespace CleanCode_ExampleMVP.Services
{
    class Repository
    {
        public Citizen Citizen { get; private set; }

        public Repository(DataTable queryresult)
        {
            Citizen = new Citizen(IsAccess(queryresult));
        }

        private bool? IsAccess(DataTable queryResult)
        {
            if (queryResult.Rows.Count > 0)
                return Convert.ToBoolean(queryResult.Rows[0].ItemArray[1]);
            else
                return null;
        }
    }
}
