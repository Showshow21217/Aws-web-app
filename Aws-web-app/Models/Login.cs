using System.ComponentModel.DataAnnotations;

namespace Aws_web_app.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Fucking enter the UserID")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Fucking enter the password")]
        public string password { get; set; }    
    }
}
