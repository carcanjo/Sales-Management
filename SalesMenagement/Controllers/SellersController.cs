using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                return RedirectToAction(nameof(Error), new { messege = "id not provided"});
            }

            var obj = _sellerServices.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not found"});
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
                return  RedirectToAction(nameof(Error), new { messege = "id not provided"});
            }
            var obj = _sellerServices.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not found"});
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not provided"});
            }

            var obj = _sellerServices.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not found"});
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
                return RedirectToAction(nameof(Error), new { messege = "id mismatch"});
            }
            try
            {
                _sellerServices.Update(seller);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { messege = ex.Message});
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
