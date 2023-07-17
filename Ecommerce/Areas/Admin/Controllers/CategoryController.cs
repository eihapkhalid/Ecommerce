using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        #region Dependency Injection
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Index
        public IActionResult Index(CategoryViewModel viewModel)
        {
            viewModel.LisTbCategory = _unitOfWork.TbCategory.GetAll(includeProperties: "_TbDepartment").ToList();
            return View(viewModel);
        }
        #endregion

        #region Get Create
        public IActionResult Create()
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            viewModel.LisTbDepartment = _unitOfWork.TbDepartment.GetAll().Select(u => new SelectListItem
            {
                Text = u.DepartmentName,
                Value = u.DepartmentId.ToString()
            });
            viewModel.inpTbCategory = new TbCategory(); // تهيئة الكائن inpTbCategory
            return View(viewModel);
        } 
        #endregion

        #region Post Create
        [HttpPost]
        public IActionResult Create(CategoryViewModel viewModel)
        {
            viewModel.inpTbCategory.CategoryCurrentState = 1;
            var fieldValidationState = ModelState.GetFieldValidationState("inpTbCategory");
            //يوجد خطأ هنا في اختبار النموزج
            if (!(fieldValidationState != ModelValidationState.Valid))
              {
                viewModel.LisTbDepartment = _unitOfWork.TbDepartment.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DepartmentName,
                    Value = u.DepartmentId.ToString()
                });
                return View(viewModel);
            }

            _unitOfWork.TbCategory.Add(viewModel.inpTbCategory);
            _unitOfWork.Save();
              TempData["success"] = "TbCategory created successfully";
            return RedirectToAction("Index");
        }
        #endregion

        #region Get Edit
        public IActionResult Edit(int? categoryid)
        {
            CategoryViewModel ViewModel = new()
            {
                LisTbDepartment = _unitOfWork.TbDepartment.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DepartmentName,
                    Value = u.DepartmentId.ToString()
                }),
                inpTbCategory = new TbCategory()
            };
            if (categoryid == null || categoryid == 0)
            {
                //create
                return View(ViewModel);
            }
            else
            {
                //update
                ViewModel.inpTbCategory = _unitOfWork.TbCategory.Get(u => u.CategoryId == categoryid, includeProperties: "_TbTool");
                return View(ViewModel);
            }


        }
        #endregion

        #region Post Edit
        [HttpPost]
        public IActionResult Edit(CategoryViewModel viewModel)
        {
            var fieldValidationState = ModelState.GetFieldValidationState("inpTbCategory");
            if (fieldValidationState != ModelValidationState.Valid)
            { 
                if (viewModel.inpTbCategory.CategoryId == 0)
                {
                    _unitOfWork.TbCategory.Add(viewModel.inpTbCategory);
                }
                else
                {
                    _unitOfWork.TbCategory.Update(viewModel.inpTbCategory);
                }

                _unitOfWork.Save();
                TempData["success"] = "Product created/updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.LisTbDepartment = _unitOfWork.TbDepartment.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DepartmentName,
                    Value = u.DepartmentId.ToString()
                });
                return View(viewModel);
            }
        }
        #endregion

        #region Get Delete
        public IActionResult Delete(int? categoryid)
        {
            if (categoryid == null || categoryid == 0)
            {
                return NotFound();
            }
            CategoryViewModel viewModel = new CategoryViewModel();
            //TbCategory? categoryFromDb = _unitOfWork.TbCategory.Get(u => u.CategoryId == categoryid);
            viewModel.inpTbCategory = _unitOfWork.TbCategory.Get(u => u.CategoryId == categoryid);

            if (viewModel.inpTbCategory == null)
            {
                return NotFound();
            }

            
            viewModel.LisTbCategory = new List<TbCategory> { viewModel.inpTbCategory };

            return View(viewModel);
        }
        #endregion

        #region post Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? categoryid)
        {
            TbCategory? obj = _unitOfWork.TbCategory.Get(u => u.CategoryId == categoryid);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.TbCategory.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "TbCategory deleted successfully";
            return RedirectToAction("Index");
        } 
        #endregion
    }
}
