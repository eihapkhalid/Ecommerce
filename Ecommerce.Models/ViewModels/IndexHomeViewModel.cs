using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.ViewModels
{
    public class IndexHomeViewModel
    {
        public List<TbDepartment> lstTbDepartments { get; set; }
        public List<TbImageTool> lstTbImageTools { get; set; }
        public List<TbCategory> lstTbCategorys { get; set; }
        public List<TbTool> lstTbTools { get; set; }
        public List<TbNewArrivalProduct> lstTbNewArrivalProducts { get; set; }
        public List<TbDealOfTheDay> lstTbDealOfTheDays { get; set; }
        public List<TbNumberOfPayment> lstTbNumberOfPayments { get; set; }
    }
}
