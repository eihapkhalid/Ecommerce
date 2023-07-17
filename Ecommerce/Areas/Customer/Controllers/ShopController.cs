using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Ecommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShopController : Controller
    {
        #region Dependancy Injections
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        public ShopController(IUnitOfWork unitOfWork, IMemoryCache cache, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            var viewModel = GetCachedIndexShopViewModel();
            return View("Index", viewModel);
        }
        #endregion

        #region GetCachedIndexViewModel
        private IndexShopViewModel GetCachedIndexShopViewModel()
        {
            const string cacheKey = "IndexShopViewModel";

            if (!_cache.TryGetValue(cacheKey, out IndexShopViewModel viewModel))
            {
                viewModel = new IndexShopViewModel
                {
                    lstTbCategorys = _unitOfWork.TbCategory.GetAll().ToList(),
                    lstTbTools = _unitOfWork.TbTool.GetAll(null, "_TbImageTool").ToList(),
                    lstTbDepartments = _unitOfWork.TbDepartment.GetAll().ToList()
                };

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, viewModel, cacheOptions);

                _logger.LogInformation("IndexViewModel loaded from the database.");
            }
            else
            {
                _logger.LogInformation("IndexViewModel loaded from the cache.");
            }

            return viewModel;
        }
        #endregion
    }
}
