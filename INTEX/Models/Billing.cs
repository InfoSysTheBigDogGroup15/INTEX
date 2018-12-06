using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Billing")]
    public class Billing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Invoice Number")]
        public int billingID { get; set; }

        [Required]
        [Display(Name = "Client ID")]
        public int clientID { get; set; }

        [Display(Name = "Employee ID")]
        public int employeeID { get; set; }

        [Display(Name = "Discount ID")]
        public int? discountID { get; set; }

        [Display(Name = "Quote")]
        public double? priceQuote { get; set; }

        [Display(Name = "Price Before Discount")]
        public double? priceBeforeDiscount { get; set; }

        [Display(Name = "Final Price")]
        public double? finalPrice { get; set; }
    }
}