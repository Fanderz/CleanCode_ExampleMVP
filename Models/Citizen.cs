using System;
using System.Data;

namespace CleanCode_ExampleMVP.Models
{
    class Citizen
    {
        public Citizen(bool? isAccess)
        {
            IsAccess = isAccess;
        }

        public bool? IsAccess { get; private set; }
    }
}
