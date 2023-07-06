using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class TbCurrency
    {
        public TbCurrency()
        {
            TbCompanyInformation _TbCompanyInformation = new TbCompanyInformation();
        }

        [Key]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Currency is Required")]
        [StringLength(5, ErrorMessage = "Length must be less than 5")]
        public string CurrencyName { get; set; }

        [Required]
        public int CurrencyCurrentState { get; set; }

        //Each CompanyInformation belongs to only one Currency :
        public int CompanyInformationID { get; set; }
        public virtual TbCompanyInformation _TbCompanyInformation { get; set; }
    }
}
