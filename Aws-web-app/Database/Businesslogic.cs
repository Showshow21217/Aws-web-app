using Aws_web_app.Models;
using System.Numerics;

namespace Aws_web_app.Database
{
    public class Businesslogic
    {
        private readonly ExpenseDbContext _context;

        public Businesslogic(ExpenseDbContext context)
        {
            _context = context;
        }

        public long getTotal()
        {
            List<Expense> model = _context.Expenses.ToList();
            long sum = 0;

            foreach(var t in model)
            {
                sum = sum + t.Amount;
            }

            return sum;
        }
    }
}
