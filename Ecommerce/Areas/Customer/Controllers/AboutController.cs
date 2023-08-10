using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models.ViewModels;
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
            return View("Index", viewModel);
        }

        #endregion

        #region GetCachedIndexViewModel
        private IndexAboutViewModel GetCachedIndexAboutViewModel()
        {
            const string cacheKey = "IndexAboutViewModel";

            if (!_cache.TryGetValue(cacheKey, out IndexAboutViewModel viewModel))
            {

                viewModel = new IndexAboutViewModel
                {
                    lstTbAbouts = _unitOfWork.TbAbout.GetAll().ToList(),
                    lesTbTeams = _unitOfWork.TbTeams.GetAll().ToList()
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
    }
}
