using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class UpdateProductDto : ProductBaseDto
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
    }
}
