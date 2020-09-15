using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMenagement.Models
{
    public class Departments
    {
        public int Id { get; set; }
        [Display(Name ="Name Departaments")]
        public string NameDepartaments { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departments()
        {

        }

        public Departments(int id, string nameDepartaments)
        {
            Id = id;
            NameDepartaments = nameDepartaments;
        }

        public void AddSaller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial,final));
        }
    }
}
