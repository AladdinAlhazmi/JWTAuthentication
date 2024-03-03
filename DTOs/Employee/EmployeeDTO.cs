using System.ComponentModel.DataAnnotations;
namespace JWTAuthentication.DTOs.Employee
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        public string? Department { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }

    }
}
