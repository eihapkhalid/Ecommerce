using Ecommerce.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ecommerce.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class DepartmentController : Controller
    {
        #region Dependency injection
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            List<TbDepartment> objDepartmentList = _unitOfWork.TbDepartment.GetAll().ToList();
            return View(objDepartmentList);
        }
        #endregion

        #region Git Create
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region Post Create
        [HttpPost]
        public IActionResult Create(TbDepartment obj)
        {
            /*if (obj.DepartmentName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }*/

            var fieldValidationState = ModelState.GetFieldValidationState("obj");
            if (fieldValidationState != ModelValidationState.Valid)
            {
                _unitOfWork.TbDepartment.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "TbDepartment created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        #endregion

        #region Git Edit
        public IActionResult Edit(int? department_id)
        {
            if (department_id == null || department_id == 0)
            {
                return NotFound();
            }
            TbDepartment? DepartmentFromDb = _unitOfWork.TbDepartment.Get(u => u.DepartmentId == department_id);
            //TbDepartment? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.department_id==department_id);
            //TbDepartment? categoryFromDb2 = _db.Categories.Where(u=>u.department_id==department_id).FirstOrDefault();

            if (DepartmentFromDb == null)
            {
                return NotFound();
            }
            return View(DepartmentFromDb);
        }
        #endregion

        #region Post Edit
        [HttpPost]
        public IActionResult Edit(TbDepartment obj)
        {
            var fieldValidationState = ModelState.GetFieldValidationState("obj");
            if (fieldValidationState != ModelValidationState.Valid)
            {
                _unitOfWork.TbDepartment.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "TbDepartment updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Git Delete
        public IActionResult Delete(int? department_id)
        {
            if (department_id == null || department_id == 0)
            {
                return NotFound();
            }
            TbDepartment? DepartmentFromDb = _unitOfWork.TbDepartment.Get(u => u.DepartmentId == department_id);

            if (DepartmentFromDb == null)
            {
                return NotFound();
            }
            return View(DepartmentFromDb);
        }
        #endregion

        #region DeletePOST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? department_id)
        {
            TbDepartment? obj = _unitOfWork.TbDepartment.Get(u => u.DepartmentId == department_id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.TbDepartment.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "TbDepartment deleted successfully";
            return RedirectToAction("Index");
        } 
        #endregion
    }
}