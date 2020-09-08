using SalesMenagement.Models;
using SalesMenagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMenagement.Services
{
    public class DepartmentServices
    {
        private readonly Context _context;
        public DepartmentServices(Context context)
        {
            _context = context;
        }

        public List<Departments> FindAll()
        {
            return _context.Departments.OrderBy(x => x.NameDepartaments).ToList();
        }

    }
}
