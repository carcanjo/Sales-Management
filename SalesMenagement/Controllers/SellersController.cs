using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesMenagement.Models;
using SalesMenagement.Models.ViewModel;
using SalesMenagement.Services;
using ServiceCorreios;

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

        public async Task<IActionResult> Index()
        {
            var list = await _sellerServices.FindAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentsServices.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // evitar ataques maliciosos
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentsServices.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                View(viewModel);
            }
            await _sellerServices.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not provided" });
            }

            var obj = await _sellerServices.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerServices.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not provided" });
            }
            var obj = await _sellerServices.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not found" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not provided" });
            }

            var obj = await _sellerServices.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { messege = "id not found" });
            }

            List<Departments> departments = await _departmentsServices.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {

            if (!ModelState.IsValid)
            {
                var departments = await _departmentsServices.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                View(viewModel);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { messege = "id mismatch" });
            }
            try
            {
                await _sellerServices.UpdateAsync(seller);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction(nameof(Error), new { messege = ex.Message });
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

        public async Task<JsonResult> ObterEnderecoCompleto(string cep)
        {
            try
            {
                AtendeClienteClient webService = new AtendeClienteClient();

                var result = await webService.consultaCEPAsync(cep);

                return Json(JsonConvert.SerializeObject(result));

            }
            catch (System.Exception)
            {
                return Json(null);
            }
        }
    }
}
