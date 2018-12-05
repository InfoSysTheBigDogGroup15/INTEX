using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int employeeID { get; set; }

        [DisplayName("Employee First Name")]
        public String employeeFirstName { get; set; }

        [DisplayName("Employee Last Name")]
        public String employeeLastName { get; set; }

        [DisplayName("Employee Title")]
        public String title { get; set; }
    }
}