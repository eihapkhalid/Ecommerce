using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class TbAbout
    {
        public TbAbout()
        {
            ICollection<TbTeam> _TbTeam = new HashSet<TbTeam>();
        }
        [Key]
        public int AboutId { get; set; }

        [StringLength(100, ErrorMessage = "imge must be less than 100")]
        public string AboutUsImg { get; set; }

        [StringLength(100, ErrorMessage = "imge must be less than 100")]
        public string AboutDescriptionImg { get; set; }

        [Required(ErrorMessage = "Titel Description is Required")]
        [StringLength(100, ErrorMessage = "Titel Description be less than 100")]
        public string AboutTitelDescription { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [StringLength(300, ErrorMessage = "Description must be less than 300")]
        public string AboutDescription { get; set; }

        [Required(ErrorMessage = "Happy Customer Number is Required")]
        public int AboutHappyCustomer { get; set; }


        [Required(ErrorMessage = "Hours WorkedNumber is Required")]
        public int AboutHoursWorked { get; set; }


        [Required(ErrorMessage = "Awards Winned Number is Required")]
        public int AboutAwardsWinned { get; set; }


        [Required(ErrorMessage = "Project Done Number is Required")]
        public int AboutProjectDone { get; set; }

        [Required]
        public int AboutCurrentState { get; set; }
        /*******************************************/
        public virtual ICollection<TbTeam> _TbTeam { get; set; }
    }
}
