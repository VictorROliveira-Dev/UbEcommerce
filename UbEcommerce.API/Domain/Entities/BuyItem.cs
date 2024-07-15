namespace UbEcommerce.API.Domain.Entities
{
    public class BuyItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Guid BuyId { get; set; }
        public Buy Buy { get; set; }




    }
}
