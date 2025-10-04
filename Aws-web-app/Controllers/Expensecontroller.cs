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

        public IActionResult Index(Expense model)
        {
            return View(model);
        }

        public IActionResult Update(Expense model)
        {
            return View(model);
        }

        public ActionResult EditExpense(int? id)
        {
            if(id != null)
            {
                var record = _dbContext.Expenses.SingleOrDefault(x => x.Id == id);
                return RedirectToAction("Update", record);
            }
            return RedirectToAction("Expense", "Home");
        }

        public IActionResult Updatedb(Expense model)
        {
            if (model != null) 
            {
                _dbContext.Expenses.Update(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Expense", "Home");
            }
            return View("Expense", model);
        }

        public IActionResult DeleteExpense(int? id)
        {
            var record = _dbContext.Expenses.Find(id);
            if (record != null)
            {
                _dbContext.Expenses.Remove(record);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Expense", "Home");
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
