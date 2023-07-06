using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class TbTeam
    {
        public TbTeam()
        {
            TbAbout _TbAbout = new TbAbout();
        }

        [Key]
        public int TeamId { get; set; }

        [StringLength(100, ErrorMessage = "Team Name must be less than 100")]
        public string TeamName { get; set; }

        [StringLength(100, ErrorMessage = "Team Title must be less than 100")]
        public string TeamTitle { get; set; }

        [StringLength(100, ErrorMessage = "Team Description must be less than 100")]
        public string TeamDescription { get; set; }

        [StringLength(100, ErrorMessage = "imge must be less than 100")]
        public string TeamImg { get; set; }

        /*****************************************/
        public int AboutId { get; set; }
        public virtual TbAbout _TbAbout { get; set; }
    }
}
