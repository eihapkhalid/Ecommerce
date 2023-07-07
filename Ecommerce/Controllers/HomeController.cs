using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataAccess.ViewModels;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        #region Dependancy Injections
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        public HomeController(IUnitOfWork unitOfWork, IMemoryCache cache, ILogger<HomeController> logger)
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
            var layoutViewModel = GetCachedLayoutViewModel();

            ViewBag.IndexShopViewModel = viewModel;
            ViewBag.LayoutViewModel = layoutViewModel;

            return View("Index");
        }
        #endregion

        #region GetCachedIndexViewModel
        private IndexShopViewModel GetCachedIndexShopViewModel()
        {
            const string cacheKey = "IndexShopViewModel";

            if (!_cache.TryGetValue(cacheKey, out IndexShopViewModel viewModel))
            {
                var layoutViewModel = GetCachedLayoutViewModel();

                viewModel = new IndexShopViewModel
                {
                    Layout = layoutViewModel,
                    lstTbCategorys = _unitOfWork.TbCategory.GetAll().ToList(),
                    lstTbTools = _unitOfWork.TbTool.GetAll().ToList(),
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

        #region GetCachedLayoutViewModel
        private LayoutViewModel GetCachedLayoutViewModel()
        {
            const string cacheKey = "LayoutViewModel";

            if (!_cache.TryGetValue(cacheKey, out LayoutViewModel viewModel))
            {
                viewModel = new LayoutViewModel
                {
                    lstTbCategorys = _unitOfWork.TbCategory.GetAll().ToList(),
                    lstTbTools = _unitOfWork.TbTool.GetAll().ToList(),
                    lstTbCompanyInformations = _unitOfWork.TbCompanyInformation.GetAll().ToList(),
                    lstTbLanguages = _unitOfWork.TbLanguage.GetAll().ToList(),
                    lstTbCurrencys = _unitOfWork.TbCurrency.GetAll().ToList(),
                    lstTbDepartments = _unitOfWork.TbDepartment.GetAll().ToList()
                };

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, viewModel, cacheOptions);

                _logger.LogInformation("LayoutViewModel loaded from the database.");
            }
            else
            {
                _logger.LogInformation("LayoutViewModel loaded from the cache.");
            }

            return viewModel;
        }
        #endregion

        #region Privacy
        public IActionResult Privacy()
        {
            return View();
        }
        #endregion

        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
