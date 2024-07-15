namespace UbEcommerce.API.Domain.Entities
{
    public class Buy : BaseEntity
    {
        public Guid UserId { get; set; }
        public List<BuyItem> Items { get; set; }
        public DateTime Date { get; set; }

    }
}
