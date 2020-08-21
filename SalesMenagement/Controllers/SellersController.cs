using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesMenagement.Models;
using SalesMenagement.Models.Context;
using SalesMenagement.Services;

namespace SalesMenagement.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerServices;

        public SellersController(SellerService sellerService)
        {
            _sellerServices = sellerService;
        }

        public IActionResult Index()
        {
            var list  = _sellerServices.Sellers();

            return View(list);
        }

    }
}
