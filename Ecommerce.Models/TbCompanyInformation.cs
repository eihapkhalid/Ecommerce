using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class TbCompanyInformation
    {
        [Key]
        public int CompanyInformationID { get; set; }

        [Required(ErrorMessage = "Company Name  is Required")]
        [StringLength(50, ErrorMessage = "Length must be less than 50")]
        public string CompanyInformationName { get; set; }

        [Required(ErrorMessage = "Company Description is Required")]
        [StringLength(200, ErrorMessage = "Length must be less than 200")]
        public string CompanyInformationDescription { get; set; }

        [Required(ErrorMessage = "Company Address is Required")]
        [StringLength(50, ErrorMessage = "Length must be less than 50")]
        public string CompanyInformationAddress { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression("^[0-9]{10}$")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "Phone must be between 12 and 14 Numbers.")]
        public string CompanyInformationPhone { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        [StringLength(50, ErrorMessage = "Length must be less than 50")]
        public string CompanyInformationEmail { get; set; }

        [Required]
        public int CompanyInformationCurrentState { get; set; }
    }
}
