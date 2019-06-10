using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChesterDevsUnitTests.Commands;
using Microsoft.AspNetCore.Mvc;
using ChesterDevsUnitTests.Models;

namespace ChesterDevsUnitTests.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new TaxViewModel());
        }

        [HttpPost]
        public IActionResult Index(TaxViewModel model)
        {
            var command = new CalculateTaxCommand();

            model.Tax = command.CalculateTax(model.TaxCode, model.Income);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
