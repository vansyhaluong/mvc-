using System.ComponentModel.DataAnnotations;

namespace mvc2.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [StringLength(20,MinimumLength =5, ErrorMessage = "Name must be between 5 and 20 characters.")]

        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
    }
}
