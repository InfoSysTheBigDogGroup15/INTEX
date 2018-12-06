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
        [DisplayName("Employee ID")]
        public int employeeID { get; set; }

        [DisplayName("Employee First Name")]
        [StringLength(30)]
        public String employeeFirstName { get; set; }

        [DisplayName("Employee Last Name")]
        [StringLength(30)]
        public String employeeLastName { get; set; }

        [DisplayName("Employee Title")]
        [StringLength(30)]
        public String title { get; set; }

        [DisplayName("Authorization ID")]
        public int? authorizationID { get; set; }
        public virtual UserAuth UserAuth { get; set; }
    }
}