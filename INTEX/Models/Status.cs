﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Status ID")]
        public int statusID { get; set; }

        [DisplayName("Status Description")]
        [Required(ErrorMessage = "Please enter the Status Description")]
        [StringLength(30)]
        public String statusDescription { get; set; }
    }
}