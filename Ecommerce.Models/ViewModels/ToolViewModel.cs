using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Models.ViewModels
{
    public class ToolViewModel
    {
        public IEnumerable<SelectListItem> LisTbCategory { get; set; }
        public List<TbTool> LisTbTool { get; set; }

        public TbTool inpTbTool { get; set; }
    }
}
