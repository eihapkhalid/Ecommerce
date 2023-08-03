using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models.ViewModels;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ToolController : Controller
    {
        #region Dependency Injection
        private readonly IUnitOfWork _unitOfWork;

        public ToolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Index
        public IActionResult Index(ToolViewModel viewModel)
        {
            viewModel.LisTbTool = _unitOfWork.TbTool.GetAll(includeProperties: "_TbCategory").ToList();
            return View(viewModel);
        }
        #endregion

        #region Get Create
        public IActionResult Create()
        {
            ToolViewModel viewModel = new ToolViewModel();
            viewModel.LisTbCategory = _unitOfWork.TbCategory.GetAll().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.CategoryId.ToString()
            });
            viewModel.inpTbTool = new TbTool(); // تهيئة الكائن inpTbTool
            return View(viewModel);
        }
        #endregion

        #region Post Create
        [HttpPost]
        public IActionResult Create(ToolViewModel viewModel)
        {
            viewModel.inpTbTool.ToolCurrentState = 1;
            var fieldValidationState = ModelState.GetFieldValidationState("inpTbTool");
            //يوجد خطأ هنا في اختبار النموزج
            if (!(fieldValidationState != ModelValidationState.Valid))
            {
                viewModel.LisTbCategory = _unitOfWork.TbCategory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                });
                return View(viewModel);
            }

            _unitOfWork.TbTool.Add(viewModel.inpTbTool);
            _unitOfWork.Save();
            TempData["success"] = "TbTool created successfully";
            return RedirectToAction("Index");
        }
        #endregion

        #region Get Edit
        public IActionResult Edit(int? tool_id)
        {
            ToolViewModel viewModel = new()
            {
                LisTbCategory = _unitOfWork.TbCategory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                }),
                inpTbTool = new TbTool()
            };
            if (tool_id == null || tool_id == 0)
            {
                //create
                return View(viewModel);
            }
            else
            {
                //update
                viewModel.inpTbTool = _unitOfWork.TbTool.Get(u => u.ToolId == tool_id, includeProperties: "_TbImageTool");
                //viewModel.inpTbTool.CategoryId = viewModel.inpTbTool._TbCategory.CategoryId;
                return View(viewModel);
            }
        }
        #endregion

        #region Post Edit
        [HttpPost]
        public IActionResult Edit(ToolViewModel viewModel)
        {
            var fieldValidationState = ModelState.GetFieldValidationState("inpTbTool");
            if (fieldValidationState != ModelValidationState.Valid)
            {
                if (viewModel.inpTbTool.ToolId == 0)
                {
                    _unitOfWork.TbTool.Add(viewModel.inpTbTool);
                }
                else
                {
                    _unitOfWork.TbTool.Update(viewModel.inpTbTool);
                }
                
                _unitOfWork.Save();
                TempData["success"] = "Product created/updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.LisTbCategory = _unitOfWork.TbCategory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                });
                return View(viewModel);
            }
        }
        #endregion

        #region Get Delete
        public IActionResult Delete(int? tool_id)
        {
            if (tool_id == null || tool_id == 0)
            {
                return NotFound();
            }
            ToolViewModel viewModel = new ToolViewModel();
            //TbTool? categoryFromDb = _unitOfWork.TbTool.Get(u => u.tool_id == tool_id);
            viewModel.inpTbTool = _unitOfWork.TbTool.Get(u => u.ToolId == tool_id);

            if (viewModel.inpTbTool == null)
            {
                return NotFound();
            }


            viewModel.LisTbTool = new List<TbTool> { viewModel.inpTbTool };

            return View(viewModel);
        }
        #endregion

        #region post Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? tool_id)
        {
            TbTool? obj = _unitOfWork.TbTool.Get(u => u.ToolId == tool_id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.TbTool.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "TbTool deleted successfully";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
