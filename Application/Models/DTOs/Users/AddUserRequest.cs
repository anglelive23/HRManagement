using Application.Models.DTOs.Shared;
using Domain.Shared.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs.Users
{
    public class AddUserRequest
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(125)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? DepartmentId { get; set; }

        [Required]
        public AddSalaryRequest Salary { get; set; }
    }
}
