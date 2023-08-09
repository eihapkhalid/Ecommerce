using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class TbNewArrivalProduct
    {
        public TbNewArrivalProduct()
        {
            ICollection<TbTool> _TbTool = new HashSet<TbTool>();
        }

        [Key]
        public int NewArrivalProductId { get; set; }

        [Required]
        public int NewArrivalProductCurrentState { get; set; }

        /*************************************/
        public virtual ICollection<TbTool> _TbTool { get; set; }
    }
}
