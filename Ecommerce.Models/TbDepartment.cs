using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class TbDepartment
    {
        public TbDepartment()
        {
            ICollection<TbCategory> _TbCategory = new HashSet<TbCategory>();
        }
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        [StringLength(50, ErrorMessage = "Length must be less than 50")]
        public string DepartmentName { get; set; }

        [Required]
        public int DepartmentCurrentState { get; set; }

        public virtual ICollection<TbCategory> _TbCategory { get; set; }

    }
}
