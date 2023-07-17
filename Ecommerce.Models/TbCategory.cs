using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class TbCategory
    {
        public TbCategory()
        {
            TbDepartment _TbDepartment = new TbDepartment();
            ICollection<TbTool> _TbTool = new HashSet<TbTool>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        [StringLength(50, ErrorMessage = "Length must be less than 50")]
        public string CategoryName { get; set; }

        [Required]
        public int CategoryCurrentState { get; set; }


        public int DepartmentId { get; set; }
        public virtual TbDepartment _TbDepartment { get; set; }

        public virtual ICollection<TbTool> _TbTool { get; set; }
    }
}
