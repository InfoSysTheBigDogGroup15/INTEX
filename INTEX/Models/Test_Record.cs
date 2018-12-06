using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Test_Record")]
    public class Test_Record
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Test Record Number")]
        public int testRecordID { get; set; }

        [DisplayName("Assay ID")]
        public int assayID { get; set; }
        public virtual Assay Assay { get; set; }

        [DisplayName("Sample ID")]
        public int sampleID { get; set; }
        public virtual Sample Sample { get; set; }

        [DisplayName("Tube ID")]
        public int testTubeID { get; set; }
        public virtual Test_Tube Test_Tube { get; set; }

        [DisplayName("Numeric Result")]
        [Required(ErrorMessage = "Please enter the numeric result")]
        public String numericResult { get; set; }

        [DisplayName("Judgement Information")]
        [Required(ErrorMessage = "Please enter the judgement information")]
        public String judgementInfo { get; set; }

        [DisplayName("Comments")]
        [Required(ErrorMessage = "Please enter any comments")]
        public String comments { get; set; }
    }
}