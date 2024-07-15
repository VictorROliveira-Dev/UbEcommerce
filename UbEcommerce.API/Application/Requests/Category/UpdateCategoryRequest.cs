using System.Text.Json.Serialization;

namespace UbEcommerce.API.Application.Requests.Category
{
    public class UpdateCategoryRequest
    {
        [JsonIgnore]
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
