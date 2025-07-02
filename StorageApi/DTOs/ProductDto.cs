using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class ProductDto
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =1)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Count { get; set; }
        public int InventoryValue => Price * Count; 

    }
}
