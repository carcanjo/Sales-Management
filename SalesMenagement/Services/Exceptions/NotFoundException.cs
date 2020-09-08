using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMenagement.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string mensage) : base(mensage) { }
    }
}
