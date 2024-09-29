using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PC2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PC2.Models;
using PC2.ViewModel;

namespace PC2.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly ApplicationDbContext _context;

        public CuentaController(ILogger<CuentaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var cuentas = from o in _context.DataCuenta select o;

            var viewModel = new CuentaViewModel
            {
                FormCuenta = new Cuenta(),
                ListCuenta = cuentas.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Enviar(CuentaViewModel viewModel)
        {
            if (viewModel.FormCuenta.Id == 0)
            {
                _context.Add(viewModel.FormCuenta);
                TempData["Message"] = "Se registró la cuenta";
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}