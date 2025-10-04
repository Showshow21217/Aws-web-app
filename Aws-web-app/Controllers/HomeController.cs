using System.Diagnostics;
using Aws_web_app.Database;
using Aws_web_app.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Aws_web_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExpenseDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ExpenseDbContext _context)
        {
            _logger = logger;
            _dbContext = _context;
        }

        public IActionResult Index()
        {
            var model = new Expense();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Expense()
        {
            var items = _dbContext.Expenses.ToList();
            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
