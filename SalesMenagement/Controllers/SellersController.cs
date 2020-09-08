using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesMenagement.Models;
using SalesMenagement.Models.Context;
using SalesMenagement.Models.ViewModel;
using SalesMenagement.Services;
using SalesMenagement.Services.Exceptions;

namespace SalesMenagement.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerServices;
        private readonly DepartmentServices _departmentsServices;

        public SellersController(SellerService sellerService, DepartmentServices departmentServices)
        {
            _sellerServices = sellerService;
            _departmentsServices = departmentServices;
        }

        public IActionResult Index()
        {
            var list = _sellerServices.Sellers();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentsServices.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // evitar ataques maliciosos
        public IActionResult Create(Seller seller)
        {
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerServices.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerServices.Renove(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerServices.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerServices.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Departments> departments = _departmentsServices.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellerServices.Update(seller);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
