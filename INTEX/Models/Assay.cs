﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Assay ID")]
        public int assayID { get; set; }

        [DisplayName("Client ID")]
        public int clientID { get; set; }
        public virtual Client Client { get; set; }

        [DisplayName("LT Number")]
        public int? LTNumber { get; set; }
        public virtual Compound Compound { get; set; }

        [DisplayName("Test ID")]
        public int? testID { get; set; }
        public virtual Test Test { get; set; }

        [DisplayName("Discount ID")]
        public int? discountID { get; set; }
        public virtual Discount Discount { get; set; }

        [DisplayName("Comments")]
        [StringLength(255)]
        public String comments { get; set; }

        [DisplayName("Status ID")]
        public int? statusID { get; set; }
        public virtual Status Status { get; set; }

        [DisplayName("Extra Test")]
        public bool allowExtraTest { get; set; }
    }
}