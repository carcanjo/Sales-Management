using Microsoft.EntityFrameworkCore;
using SalesMenagement.Models;
using SalesMenagement.Models.Context;
using SalesMenagement.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Departments).FirstOrDefault(obj => obj.Id == id);
        }

        public void Renove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("id not found");
            }
            try
            {
                _context.Update(obj);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
            _context.SaveChanges();
        }
    }
}
