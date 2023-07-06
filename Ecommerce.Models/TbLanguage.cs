using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class TbLanguage
    {
        public TbLanguage()
        {
            TbCompanyInformation _TbCompanyInformation = new TbCompanyInformation();
        }
        [Key]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Language is Required")]
        [StringLength(12, ErrorMessage = "Length must be less than 12")]
        public string LanguageName { get; set; }

        [Required]
        public int LanguageCurrentState { get; set; }

        //Each CompanyInformation belongs to only one Language  :
        public int CompanyInformationID { get; set; }
        public virtual TbCompanyInformation _TbCompanyInformation { get; set; }
    }
}
