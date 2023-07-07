using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.ViewModels
{
    public class IndexAboutViewModel
    {
        public List<TbAbout> lstTbAbouts { get; set; }
        public LayoutViewModel Layout { get; set; }
    }
}
