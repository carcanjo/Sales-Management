using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMenagement.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} required")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="{0} size shoud be between {2} and {1}")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="{0} required")]
        public string Email { get; set; }

        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="{0} required")]
        public DateTime BirthDate { get; set; }

        [Display(Name ="Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Required(ErrorMessage ="{0} required")]
        public double BaseSalary { get; set; }

        public Departments Departments { get; set; }
        public int DepartmentsId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departments departments)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departments = departments;
        }

        public void AddSeller(SalesRecord sr)
        {
            SalesRecords.Add(sr);
        }

        public void RemoveSeller(SalesRecord sr)
        {
            SalesRecords.Remove(sr);
        }

        public double TotalSales(DateTime initial , DateTime final)
        {
            return SalesRecords.Where(x => x.Date >= initial  && x.Date <= final).Sum(x => x.Amount);
        }

    }
}
