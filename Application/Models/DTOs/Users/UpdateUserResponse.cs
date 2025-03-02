﻿using Domain.Shared.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs.Users
{
    public class UpdateUserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public float CoefficientsSalary { get; set; }
        public int? DepartmentId { get; set; }
        public Salary? Salary { get; set; }
    }
}
