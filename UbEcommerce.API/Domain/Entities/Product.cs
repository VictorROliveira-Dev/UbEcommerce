namespace UbEcommerce.API.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public Category Category { get; set; }

    }
}
