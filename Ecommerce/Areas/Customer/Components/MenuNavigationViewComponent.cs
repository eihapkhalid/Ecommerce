using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Customer.ViewComponents
{
    public class MenuNavigationViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuNavigationViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new LayoutViewModel
            {
                lstTbCategorys = _unitOfWork.TbCategory.GetAll().ToList(),
                lstTbTools = _unitOfWork.TbTool.GetAll().ToList(),
                lstTbCompanyInformations = _unitOfWork.TbCompanyInformation.GetAll().ToList(),
                lstTbLanguages = _unitOfWork.TbLanguage.GetAll().ToList(),
                lstTbCurrencys = _unitOfWork.TbCurrency.GetAll().ToList(),
                lstTbDepartments = _unitOfWork.TbDepartment.GetAll().ToList()
            };

            return View(viewModel);
        }
    }
}
