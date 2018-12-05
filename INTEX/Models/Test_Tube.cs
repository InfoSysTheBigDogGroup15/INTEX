using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Test_Tube")]
    public class Test_Tube
    {
        [Key]
        public int testTubeID { get; set; }

        [DisplayName("Concentration")]
        [Required(ErrorMessage = "Please enter the concentration")]
        public String concentration { get; set; }

        public int? testID { get; set; }
        public virtual Test Test { get; set; }
    }
}