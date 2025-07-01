using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public abstract class ProductBaseDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Category { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Shelf { get; set; } = string.Empty;
        [Required]
        [Range(0, int.MaxValue)]
        public int Count { get; set; }
        [StringLength(1000, MinimumLength = 1)]
        public string Description { get; set; } = string.Empty;
    }
}