using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Aws_web_app.Database;
using Microsoft.IdentityModel.Tokens;

namespace Aws_web_app.Models
{
    public class Expense
    {
        Random r = new Random();
        public Expense()
        {
            Id = r.Next(1, 999);
            Description = "Enter a description";
            Date = DateOnly.FromDateTime(DateTime.Now).ToString();
        }
        public int Id { get; set; }

        public string Description { get; set; }

        [Display(Name = "Price"), Required(ErrorMessage = "Please Enter Amount")]
        public Int64 Amount { get; set; } 

        public string Date { get; set; }  

    }
}
