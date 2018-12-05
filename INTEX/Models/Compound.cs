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
        public int LTNumber { get; set; }

        [DisplayName("Compound Name")]
        public String compoundName { get; set; }

        [DisplayName("Compound Quantity")]
        public int compoundQuantity { get; set; }

        [DisplayName("Date Arrived")]
        public DateTime dateArrived { get; set; }

        [DisplayName("Employee ID")]
        public int? employeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [DisplayName("Due Date")]
        public DateTime dateDue { get; set; }

        [DisplayName("Appearance")]
        public String appearance { get; set; }

        [DisplayName("Weight from Customer")]
        public double weight { get; set; }

        [DisplayName("Actual Weight")]
        public double actualWeight { get; set; }

        [DisplayName("Maximum Tolerated Dose")]
        public double maximumToleratedDose { get; set; }

        [DisplayName("Confirmation Sent Out Date")]
        public DateTime confirmationSentOutDate { get; set; }
    }
}