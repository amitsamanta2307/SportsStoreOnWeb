
namespace SportsStoreOnWeb.ApplicationCore.Entities
{
    public class Product : BaseEntity<long>
    {
        private Product()
        {
        }

        public Product(string name, string description, decimal price, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }

        public CategoryType Category { get; private set; }
    }
}