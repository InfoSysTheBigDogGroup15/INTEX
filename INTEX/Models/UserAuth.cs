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
        [StringLength(30)]
        public String username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(30)]
        public String password { get; set; }

        [Required]
        [Display(Name = "Role")]
        [StringLength(30)]
        public String role { get; set; }
    }
}