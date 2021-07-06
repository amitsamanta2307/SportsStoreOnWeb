using SportsStoreOnWeb.Web.ViewModels;
using System.Threading.Tasks;

namespace SportsStoreOnWeb.Web.Services
{
    public interface IProductViewModelService
    {
        Task<ProductIndexViewModel> GetProducts();
    }
}