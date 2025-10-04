using Aws_web_app.Database;
using Aws_web_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aws_web_app.Controllers
{
    public class CreateExpensecontroller : Controller
    {
        public readonly ExpenseDbContext _dbContext;

        public CreateExpensecontroller(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = new Expense();
            return View(model);
        }

        public ActionResult CreateExpenseList(Expense model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Expense", "Home");
            }
            return View("Index", model);
        }
    }
}
