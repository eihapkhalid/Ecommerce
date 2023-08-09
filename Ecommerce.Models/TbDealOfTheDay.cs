using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ecommerce.Models
{
    public class TbDealOfTheDay
    {
        public TbDealOfTheDay()
        {
            ICollection<TbTool> _TbTool = new HashSet<TbTool>();
        }

        [Key]
        public int DealOfTheDayId { get; set; }

        [Range(0.00, 999999.99, ErrorMessage = "New Price must be between 0.00 and 999999.99")]
        [RegularExpression(@"^\d{1,6}(\.\d{1,2})?$", ErrorMessage = "New Price must have 6 digits before the decimal point and 2 decimal places")]
        public decimal DealOfTheDayToolProductNewPrice { get; set; }

        [Range(0.00, 999999.99, ErrorMessage = "rate must be between 0.00 and 99.99")]
        [RegularExpression(@"^\d{1,2}(\.\d{1,2})?$", ErrorMessage = "rate must have 2 digits before the decimal point and 2 decimal places")]
        public decimal DealOfTheDayToolrate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DealOfTheDayToolDate { get; set; }

        /*************************************/
        public virtual ICollection<TbTool> _TbTool { get; set; }
    }
}
