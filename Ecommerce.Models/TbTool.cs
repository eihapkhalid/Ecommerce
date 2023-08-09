using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class TbTool
    {
        public TbTool()
        {
            TbCategory _TbCategory = new TbCategory();

            TbDealOfTheDay _TbDealOfTheDay  = new TbDealOfTheDay();

            TbNewArrivalProduct _TbNewArrivalProduct = new TbNewArrivalProduct();

            TbNumberOfPayment _TbNumberOfPayment = new TbNumberOfPayment();

            ICollection<TbImageTool> _TbImageTool = new HashSet<TbImageTool>();
        }

        [Key]
        public int ToolId { get; set; }

        [Required(ErrorMessage = "Tool Name is Required")]
        [StringLength(50, ErrorMessage = "Length must be less than 50")]
        public string ToolName { get; set; }

        [Required]
        public int ToolCurrentState { get; set; }

        [Required(ErrorMessage = "Sticker Name is Required")]
        [StringLength(10, ErrorMessage = "Length must be less than 10")]
        public string ToolSticker { get; set; }

        [Required(ErrorMessage = "Description Name is Required")]
        [StringLength(100, ErrorMessage = "Length must be less than 100")]
        public string ToolDescription { get; set; }

        [Range(0.00, 999999.99, ErrorMessage = "Price must be between 0.00 and 999999.99")]
        [RegularExpression(@"^\d{1,6}(\.\d{1,2})?$", ErrorMessage = "Price must have 6 digits before the decimal point and 2 decimal places")]
        public decimal ToolProductPrice { get; set; }

        

        /********************************************/
        public int CategoryId { get; set; }
        public virtual TbCategory _TbCategory { get; set; }

        public int? DealOfTheDayId { get; set; }
        public virtual TbDealOfTheDay _TbDealOfTheDay { get; set; }

        public int? NewArrivalProductId { get; set; }
        public virtual TbNewArrivalProduct _TbNewArrivalProduct { get; set; }

        public int? NumberOfPaymentId { get; set; }
        public virtual TbNumberOfPayment _TbNumberOfPayment { get; set; }


        public virtual ICollection<TbImageTool> _TbImageTool { get; set; }
        /********************************************/
    }
}
