using Microsoft.AspNetCore.Mvc.Rendering;
namespace Ecommerce.Models.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<SelectListItem> LisTbDepartment { get; set; }
        public List<TbCategory> LisTbCategory { get; set; }
        

        public TbCategory inpTbCategory { get; set; }
    }
}