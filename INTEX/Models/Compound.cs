using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Compound")]
    public class Compound
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("LT Number")]
        public int LTNumber { get; set; }

        [DisplayName("Compound Name")]
        [Required]
        [StringLength(30)]
        public String compoundName { get; set; }

        [DisplayName("Compound Quantity")]
        [Required]
        public int compoundQuantity { get; set; }

        [DisplayName("Date Arrived")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateArrived { get; set; }

        [DisplayName("Employee ID")]
        [Required]
        public int? employeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [DisplayName("Due Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateDue { get; set; }

        [DisplayName("Appearance")]
        [Required]
        [StringLength(255)]
        public String appearance { get; set; }

        [DisplayName("Weight from Customer")]
        [Required]
        public double weight { get; set; }

        [DisplayName("Actual Weight")]
        public double? actualWeight { get; set; }

        [DisplayName("Maximum Tolerated Dose")]
        public double? maximumToleratedDose { get; set; }

        [DisplayName("Confirmation Sent Out Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? confirmationSentOutDate { get; set; }
    }
}