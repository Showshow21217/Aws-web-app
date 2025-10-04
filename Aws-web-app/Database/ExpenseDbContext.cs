using Aws_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace Aws_web_app.Database
{
    public class ExpenseDbContext : DbContext
    {
        
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) 
            : base(options)
        {
            
        }
        public DbSet<Expense> Expenses { get; set; }
    }
}
