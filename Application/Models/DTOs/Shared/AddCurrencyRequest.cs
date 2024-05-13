using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs.Shared
{
    public class AddCurrencyRequest
    {
        [Required]
        [MaxLength(100)]
        public string Value { get; set; }
    }
}
