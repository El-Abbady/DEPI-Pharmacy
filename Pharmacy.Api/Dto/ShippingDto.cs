namespace Pharmacy.Api.Dto
{
    public class ShippingDto
    {
        public string? Description { get; set; }
        public decimal? BaseCost { get; set; }
        public decimal? CostPerUnit { get; set; }
        public int? EstimatedDeliveryTime { get; set; }
    }
}
