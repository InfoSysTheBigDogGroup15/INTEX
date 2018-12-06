using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Test ID")]
        public int testID { get; set; }

        [DisplayName("Test Name")]
        [Required(ErrorMessage = "Please enter the test name")]
        [StringLength(30)]
        public String testName { get; set; }

        [DisplayName("Base Cost")]
        [Required(ErrorMessage = "Please enter base cost")]
        public decimal baseCost { get; set; }

        [DisplayName("Hourly Wage")]
        [Required(ErrorMessage = "Please enter the hourly wage")]
        public decimal hourlyWage { get; set; }

        [DisplayName("Number of Days")]
        [Required(ErrorMessage = "Please enter the number of days to complete the project")]
        [RegularExpression("^[0-9]+$")]
        public int numDays { get; set; }
    }
}