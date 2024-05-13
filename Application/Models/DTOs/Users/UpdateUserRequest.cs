using Application.Models.DTOs.Shared;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs.Users
{
    public class UpdateUserRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }
        [Required]
        public float CoefficientsSalary { get; set; }
        public int? DepartmentId { get; set; }

        public AddSalaryRequest? Salary { get; set; }
    }
}
