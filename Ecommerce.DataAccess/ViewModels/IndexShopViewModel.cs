using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.ViewModels
{
    public class IndexShopViewModel
    {
        public List<TbDepartment> lstTbDepartments { get; set; }
        public List<TbImageTool> lstTbImageTools { get; set; }
        public List<TbCategory> lstTbCategorys { get; set; }
        public List<TbTool> lstTbTools { get; set; }
    }
}
