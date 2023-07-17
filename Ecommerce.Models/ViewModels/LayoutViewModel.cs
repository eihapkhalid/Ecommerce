
namespace Ecommerce.Models.ViewModels
{
    public class LayoutViewModel
    {
        public IndexTellViewModel IndexTellViewModel { get; set; }
        public IndexAboutViewModel IndexAboutViewModel { get; set; }
        public IndexShopViewModel IndexShopViewModel { get; set; }
        public List<TbCompanyInformation> lstTbCompanyInformations { get; set; }
        public List<TbLanguage> lstTbLanguages { get; set; }
        public List<TbCurrency> lstTbCurrencys { get; set; }
        public List<TbDepartment> lstTbDepartments { get; set; }
        public List<TbCategory> lstTbCategorys { get; set; }
        public List<TbTool> lstTbTools { get; set; }
    }
}
