using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.ViewModels
{
    public class IndexTellViewModel
    {
        public LayoutViewModel Layout { get; set; }
        public List<TbCompanyInformation> lstTbCompanyInformations { get; set; }
        public TbTellUs InpTbTellUs { get; set; }
    }
}
