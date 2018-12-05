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
        public int sampleID { get; set; }

        public int? LTnumber { get; set; }
        public virtual Compound Compound { get; set; }

        [DisplayName("Sequence Number")]
        [Required(ErrorMessage = "Please enter the sequence number")]
        public String sequenceNumber { get; set; }

        public int? testID { get; set; }
        public virtual Test Test { get; set; }
    }
}