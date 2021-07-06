using Microsoft.Extensions.Logging;
using SportsStoreOnWeb.ApplicationCore.Entities;
using SportsStoreOnWeb.ApplicationCore.Interfaces;
using SportsStoreOnWeb.Web.Services;
using SportsStoreOnWeb.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreOnWeb.Web.Services
{
    /// <summary>
    /// This is a UI-specific service so belongs in UI project. It does not contain any business logic and works
    /// with UI-specific types (view models and SelectListItem types).
    /// </summary>
    public class ProductViewModelService : IProductViewModelService
    {
        private readonly ILogger<ProductViewModelService> _logger;
        private readonly IAsyncRepository<Product> _productRepository;

        public ProductViewModelService(
            ILoggerFactory loggerFactory,
            IAsyncRepository<Product> productRepository)
        {
            _logger = loggerFactory.CreateLogger<ProductViewModelService>();
            _productRepository = productRepository;
        }

        public async Task<ProductIndexViewModel> GetProducts()
        {
            _logger.LogInformation("GetCatalogItems called.");

            var products = await _productRepository.ListAllAsync();

            var vm = new ProductIndexViewModel()
            {
                ProductItems = products.Select(p => new ProductItemViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                }).ToList()
            };

            return vm;
        }
    }
}