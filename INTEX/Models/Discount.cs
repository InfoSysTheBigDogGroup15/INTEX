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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Discount ID")]
        public int discountID { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Please enter the description")]
        [StringLength(30)]
        public String description { get; set; }

        [DisplayName("Discount Percentage")]
        [Required(ErrorMessage = "Please enter the discount percentage")]
        public decimal percentDiscount { get; set; }

    }
}