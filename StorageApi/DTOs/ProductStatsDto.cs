using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class ProductStatsDto
    {
        [Required]
        [Range(0,int.MaxValue)]
        public int NrOfProducts { get; set; }
        [Required]
        [Range(double.MinValue,double.MaxValue)]
        public decimal InventoryValue { get; set; }
        public string AveragePrice => (InventoryValue / NrOfProducts).ToString("F2");
    }
}
