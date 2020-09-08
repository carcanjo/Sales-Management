using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMenagement.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string mensage) : base(mensage) { }
    }
}
