using SalesMenagement.Models;
using SalesMenagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMenagement.Services
{
    public class SellerService
    {
        private readonly Context _context;
        public SellerService(Context context)
        {
            _context = context;
        }


        public IList<Seller> Sellers()
        {
            return _context.Seller.ToList();
        }

    }
}
