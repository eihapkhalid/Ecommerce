using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class TbNumberOfPayment
    {
        public TbNumberOfPayment()
        {
            ICollection<TbTool> _TbTool = new HashSet<TbTool>();
        }
        [Key]
        public int NumberOfPaymentId { get; set; }

        [Required]
        public int ToolCurrentState { get; set; }

        [Required]
        public int NumberOfPayment { get; set; }

        /*****************************/
        public virtual ICollection<TbTool> _TbTool { get; set; }
    }
}
