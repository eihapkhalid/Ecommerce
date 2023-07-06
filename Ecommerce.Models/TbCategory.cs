using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class TbCategory
    {
        public TbCategory()
        {
            TbDepartment _TbDepartment = new TbDepartment();
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
    }
}
