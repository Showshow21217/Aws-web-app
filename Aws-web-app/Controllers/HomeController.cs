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

        private readonly Businesslogic _businessLogic;

        public HomeController(ILogger<HomeController> logger, ExpenseDbContext _context, Businesslogic businesslogic)
        {
            _logger = logger;
            _dbContext = _context;
            _businessLogic = businesslogic;
        }

        public IActionResult Index()
        {
            var model = new Expense();
            return View(model);
        }

        public ActionResult Expense()
        {
            var total = _businessLogic.getTotal();
            var items = _dbContext.Expenses.ToList();

            ViewBag.total = total;
            return View(items);
        }

        public ActionResult Login(Login model)
        {
            if(model.userName.Equals("Cutie") && model.password.Equals("Iloveu"))
            {
                return RedirectToAction("yay");
            }
            return View("Suprise");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Suprise() 
        { 
            return View();
        }

        public IActionResult yay()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
