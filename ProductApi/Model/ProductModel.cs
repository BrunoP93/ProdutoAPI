using ProductApi.Model.Enum;

namespace ProductApi.Model
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }
    }
}
