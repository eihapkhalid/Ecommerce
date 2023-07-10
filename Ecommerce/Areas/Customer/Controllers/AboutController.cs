using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Ecommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AboutController : Controller
    {
        #region Dependancy Injections
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        public AboutController(IUnitOfWork unitOfWork, IMemoryCache cache, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            var viewModel = GetCachedIndexAboutViewModel();
            var layoutViewModel = GetCachedLayoutViewModel();

            layoutViewModel.IndexAboutViewModel = viewModel;

            return View("Index", layoutViewModel);
        }

        #endregion

        #region GetCachedIndexViewModel
        private IndexAboutViewModel GetCachedIndexAboutViewModel()
        {
            const string cacheKey = "IndexAboutViewModel";

            if (!_cache.TryGetValue(cacheKey, out IndexAboutViewModel viewModel))
            {
                var layoutViewModel = GetCachedLayoutViewModel();

                viewModel = new IndexAboutViewModel
                {
                    Layout = layoutViewModel,
                    lstTbAbouts = _unitOfWork.TbAbout.GetAll().ToList()
                };

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, viewModel, cacheOptions);

                _logger.LogInformation("IndexAboutViewModel loaded from the database.");
            }
            else
            {
                _logger.LogInformation("IndexAboutViewModel loaded from the cache.");
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
    }
}
