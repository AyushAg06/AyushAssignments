using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFinASP.net.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Plz enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Plz enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Plz enter your email")]
        [EmailAddress(ErrorMessage ="Enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter your Age")]
        [Range(0,100,ErrorMessage ="enter valid age")]
        public int Age { get; set; }



    }
}
