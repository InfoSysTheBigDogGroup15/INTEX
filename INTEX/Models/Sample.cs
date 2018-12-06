using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Sample")]
    public class Sample
    {
        [Key]
        [DisplayName("Sample ID")]
        public int sampleID { get; set; }

        [DisplayName("LT Number")]
        [Required(ErrorMessage = "Please enter the LT number")]
        public int LTNumber { get; set; }
        public virtual Compound Compound { get; set; }

        [DisplayName("Sequence Number")]
        [Required(ErrorMessage = "Please enter the sequence number")]
        [RegularExpression("^[0-9]+$")]
        public int sequenceNumber { get; set; }

        [DisplayName("Test ID")]
        [Required(ErrorMessage = "Please enter test ID")]
        public int? testID { get; set; }
        public virtual Test Test { get; set; }

        [DisplayName("Status ID")]
        public int statusID { get; set; }
        public virtual Status Status { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime testStatusDate { get; set; }

        [DisplayName("Assay ID")]
        public int assayID { get; set; }
        public virtual Assay Assay { get; set; }
    }
}