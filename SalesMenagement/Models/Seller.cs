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

        [Required(ErrorMessage ="{0} obrigatório")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="{0} size shoud be between {2} and {1}")]
        
        [Display(Name ="Nome completo")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="{0} obrigatório")]
        public string Email { get; set; }

        [Display(Name ="Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="{0} obrigatório")]
        public DateTime BirthDate { get; set; }

        [Display(Name ="Salário base")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Required(ErrorMessage ="{0} Obrigatório")]
        public double BaseSalary { get; set; }

        [Display(Name ="Departamento")]
        public Departments Departments { get; set; }
        public int DepartmentsId { get; set; }

        [DisplayFormat(DataFormatString ="0000-00", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage ="{0} obrigatório")]
        public string CEP { get; set; }
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
