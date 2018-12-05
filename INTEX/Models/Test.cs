﻿using System;
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
        public int testID { get; set; }

        [DisplayName("Test Name")]
        [Required(ErrorMessage = "Please enter the test name")]
        public String testName { get; set; }

        [DisplayName("Base Cost")]
        [Required(ErrorMessage = "Please enter base cost")]
        public double baseCost { get; set; }

        [DisplayName("Hourly Wage")]
        [Required(ErrorMessage = "Please enter the hourly wage")]
        public double hourlyWage { get; set; }

        [DisplayName("Number of Days")]
        [Required(ErrorMessage = "Please enter the number of days to complete the project")]
        public int numDays { get; set; }
    }
}