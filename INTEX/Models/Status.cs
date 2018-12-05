using System;
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
        public int statusID { get; set; }

        [DisplayName("Status Description")]
        [Required(ErrorMessage = "Please enter the Status Description")]
        public String statusDescription { get; set; }
    }
}