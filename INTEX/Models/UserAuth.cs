using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Authorization")]
    public class UserAuth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Authorization ID")]
        public int authorizationID { get; set; }

        [Required]
        [Display(Name = "Username")]
        public String username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String password { get; set; }

        [Required]
        [Display(Name = "Role")]
        public String role { get; set; }
    }
}