using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStoreOnWeb.Web.Services;
using SportsStoreOnWeb.Web.ViewModels;
using System.Threading.Tasks;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductViewModelService _productViewModelService;

        public IndexModel(IProductViewModelService productViewModelService)
        {
            _productViewModelService = productViewModelService;
        }

        public ProductIndexViewModel ProductModel { get; set; } = new ProductIndexViewModel();

        public async Task OnGet()
        {
            ProductModel = await _productViewModelService.GetProducts();
        }
    }
}
