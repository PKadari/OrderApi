using System.ComponentModel.DataAnnotations;

namespace OrderApi.Model
{
    public class Orders
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string? ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public int? Price { get; set; }

        [Required]
        public string? Category { get; set; }
    }
}
