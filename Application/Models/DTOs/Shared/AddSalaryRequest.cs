using Domain.Shared.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs.Shared
{
    public class AddSalaryRequest
    {
        [Required]
        public int Amount { get; set; }
        public AddCurrencyRequest Currency { get; set; }
    }
}
