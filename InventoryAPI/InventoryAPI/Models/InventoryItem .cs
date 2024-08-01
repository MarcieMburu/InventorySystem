using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class InventoryItem
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
