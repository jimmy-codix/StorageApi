namespace StorageApi.DTOs
{
    public class ProductStatsDto
    {
        public int NrOfProducts { get; set; }
        public decimal InventoryValue { get; set; }
        public string AveragePrice => (InventoryValue / NrOfProducts).ToString("F2");
    }
}
