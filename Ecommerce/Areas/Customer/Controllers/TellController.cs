using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataAccess.ViewModels;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Caching.Memory;

namespace Ecommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TellController : Controller
    {
        #region Dependancy Injections
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        public TellController(IUnitOfWork unitOfWork, IMemoryCache cache, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            var viewModel = GetCachedIndexTellViewModel();

            return View("Index", viewModel);
        }

        #endregion

        #region Save by TellUs object
        [HttpPost]
        public IActionResult Save(IndexTellViewModel viewModel)
        {
            viewModel.InpTbTellUs.TellCurrentState = 1;
            var fieldValidationState = ModelState.GetFieldValidationState("InpTbTellUs");
            if (fieldValidationState != ModelValidationState.Valid)
            {
                return View("Index", viewModel);
            }
            // التأكد ان البيانات تمر بطريقة صحيحة:
            Console.WriteLine("TellName: " + viewModel.InpTbTellUs.TellName);
            Console.WriteLine("TellEmail: " + viewModel.InpTbTellUs.TellEmail);
            Console.WriteLine("TellSubject: " + viewModel.InpTbTellUs.TellSubject);
            Console.WriteLine("TellMessage: " + viewModel.InpTbTellUs.TellMessage);
            //استدعاء الدالة update من اجل اخذ بيانات الكائن او تحديثها
            _unitOfWork.TbTellUs.Update(viewModel.InpTbTellUs);
            //حفظ بيانات الكائن في قاعدة البيانات
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        #endregion

        #region GetCachedIndexViewModel
        private IndexTellViewModel GetCachedIndexTellViewModel()
        {
            const string cacheKey = "IndexTellViewModel";

            if (!_cache.TryGetValue(cacheKey, out IndexTellViewModel viewModel))
            {

                viewModel = new IndexTellViewModel
                {
                    lstTbCompanyInformations = _unitOfWork.TbCompanyInformation.GetAll().ToList(),
                    InpTbTellUs = new TbTellUs()
                };
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, viewModel, cacheOptions);

                _logger.LogInformation("IndexTellViewModel loaded from the database.");
            }
            else
            {
                _logger.LogInformation("IndexTellViewModel loaded from the cache.");
            }

            return viewModel;
        }
        #endregion
    }
}
