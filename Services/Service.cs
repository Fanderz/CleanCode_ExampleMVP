using CleanCode_ExampleMVP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_ExampleMVP.Services
{
    class Service
    { 
        public string GetPassports(Passport passport)
        {
            return HashCalculator.CalculateHash(passport);
        }
    }
}
