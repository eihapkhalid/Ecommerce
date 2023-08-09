using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models.ViewModels;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace Ecommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
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
            var viewModel = GetCachedIndexHomeViewModel();
            return View("Index", viewModel);
        }
        #endregion

        #region GetCachedIndexViewModel
        private IndexHomeViewModel GetCachedIndexHomeViewModel()
        {
            const string cacheKey = "IndexHomeViewModel";

            if (!_cache.TryGetValue(cacheKey, out IndexHomeViewModel viewModel))
            {
                _logger.LogInformation("Cache miss: Loading IndexViewModel from the database.");

                viewModel = new IndexHomeViewModel
                {
                    lstTbCategorys = _unitOfWork.TbCategory.GetAll().ToList(),
                    lstTbTools = _unitOfWork.TbTool.GetAll(null, "_TbImageTool").ToList(),
                    lstTbDepartments = _unitOfWork.TbDepartment.GetAll().ToList(),
                    lstTbNewArrivalProducts = _unitOfWork.TbNewArrivalProduct.GetAll().ToList(),
                    lstTbDealOfTheDays = _unitOfWork.TbDealOfTheDay.GetAll().ToList(),
                    lstTbNumberOfPayments = _unitOfWork.TbNumberOfPayment.GetAll().ToList()
                };

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, viewModel, cacheOptions);
            }
            else
            {
                _logger.LogInformation("Cache hit: IndexViewModel loaded from the cache.");
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
