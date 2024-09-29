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
    public class ListadoCuentasController : Controller
    {
        private readonly ILogger<ListadoCuentasController> _logger;
        private readonly ApplicationDbContext _context;

        public ListadoCuentasController(ILogger<ListadoCuentasController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var cuentas = _context.DataCuenta.ToList();

            var viewModel = new CuentaViewModel
            {
                ListCuenta = cuentas
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}