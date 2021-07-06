
namespace SportsStoreOnWeb.ApplicationCore.Entities
{
    public class CategoryType : BaseEntity<int>
    {
        public CategoryType(string type)
        {
            Type = type;
        }

        public string Type { get; private set; }
    }
}