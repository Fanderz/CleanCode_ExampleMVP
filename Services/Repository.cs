using System;
using System.Data;

namespace CleanCode_ExampleMVP.Services
{
    class Repository
    {
        public bool? IsAccess(DataTable queryResult)
        {
            if (queryResult.Rows.Count > 0)
                return Convert.ToBoolean(queryResult.Rows[0].ItemArray[1]);
            else
                return null;
        }
    }
}
