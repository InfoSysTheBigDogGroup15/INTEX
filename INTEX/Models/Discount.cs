using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        public int discountID { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Please enter the description")]
        public String description { get; set; }

        [DisplayName("Discount Percentage")]
        [Required(ErrorMessage = "Please enter the discount percentage")]
        public double percentDiscount { get; set; }

    }
}