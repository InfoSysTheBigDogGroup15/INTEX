using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Work_Order")]
    public class Work_Order
    {
        [Key]
        public int workOrderID { get; set; }

        public int? clientID { get; set; }
        public virtual Client Client { get; set; }

        public int? LTNumber { get; set; }
        public virtual Compound Compound { get; set; }

        public int? testtID { get; set; }
        public virtual Test Test { get; set; }

        public int? discountID { get; set; }
        public virtual Discount Discount { get; set; }

        [DisplayName("Comments")]
        [Required(ErrorMessage = "Please enter any comments")]
        public String comments { get; set; }

        public int? statusID { get; set; }
        public virtual Status Status { get; set; }
    }
}