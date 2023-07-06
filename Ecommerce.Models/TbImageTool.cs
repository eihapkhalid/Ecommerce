﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class TbImageTool
    {
        public TbImageTool()
        {
            TbTool _TbTool = new TbTool();
        }

        [Key]
        public int ImageTool { get; set; }

        [StringLength(100, ErrorMessage = "imge must be less than 100")]
        public string? ToolProductImgPrimary { get; set; }

        [StringLength(100, ErrorMessage = "imge must be less than 100")]
        public string? ToolProductImgSecondry { get; set; }

        [Required]
        public int ImageCurrentState { get; set; }

        /*********************************/
        public int ToolId { get; set; }
        public virtual TbTool _TbTool { get; set; }
        /*********************************/
    }
}
