using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class TbTellUs
    {
        [Key]
        public int TellId { get; set; }

        [Required(ErrorMessage = "Your Name  is Required")]
        [StringLength(50, ErrorMessage = "Length must be less than 50")]
        public string TellName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        [StringLength(50, ErrorMessage = "Length must be less than 50")]
        public string TellEmail { get; set; }


        [Required(ErrorMessage = "Subject  is Required")]
        [StringLength(50, ErrorMessage = "Length must be less than 50")]
        public string TellSubject { get; set; }


        [Required(ErrorMessage = "Message  is Required")]
        [StringLength(250, ErrorMessage = "Length must be less than 250")]
        public string TellMessage { get; set; }

        [Required]
        public int TellCurrentState { get; set; }
    }
}
