using OnSalePrep.Common.Responses;

namespace OnSalePrep.Common.Responses
{
    public class OrderDetailResponse
    {
        public int Id { get; set; }

        public ProductResponse Product { get; set; }

        public float Quantity { get; set; }

        public string Remarks { get; set; }

        public decimal? Value => (decimal)Quantity * Product?.Price;
    }
}
