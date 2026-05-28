using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace mvc1.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="tên không được để trống")]
        public String? Name { get; set; }
        [Required(ErrorMessage = "giá không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "giá phải lớn hơn 0")]

        public decimal Price { get; set; }
    }
}
