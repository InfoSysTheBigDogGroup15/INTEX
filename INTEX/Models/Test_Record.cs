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
        public int testRecordID { get; set; }

        public int? workOrderID { get; set; }
        public virtual Work_Order Work_Order { get; set; }

        public int? sampleID { get; set; }
        public virtual Sample Sample { get; set; }

        public int? testTubeID { get; set; }
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