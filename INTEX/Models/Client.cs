using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Client ID")]
        public int clientID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(30)]
        public String clientFirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(30)]
        public String clientLastName { get; set; }

        [DisplayName("Street Address")]
        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(50)]
        public String clientStreetAddress { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Please enter the city in which you live")]
        [StringLength(30)]
        public String clientCity { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "Please enter the state in which you live")]
        [StringLength(15)]
        public String clientState { get; set; }

        [DisplayName("Zip Code")]
        [Required(ErrorMessage = "Please enter your zip code")]
        [RegularExpression(@"^\d{5}([\-]\d{4})?$", ErrorMessage = "Please input the zipcode properly")]
        public String clientZip { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"^\+?\(?\d+\)?(\s|\-|\.)?\d{1,3}(\s|\-|\.)?\d{4}[\s]*[\d]*$", ErrorMessage = "Please input the phone number properly")]
        public String clientPhoneNumber { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please input the email properly")]
        public String clientEmail { get; set; }

        [DisplayName("Credit Card Number")]
        //[Required(ErrorMessage = "Please enter your card")]
        //[StringLength(16, MinimumLength = 16)]
        //[RegularExpression(@"^[0-9]{0,15}$")]
        public String clientCardNumber { get; set; }

        [DisplayName("CVC Number")]
        //[Required(ErrorMessage = "Please enter your security code")]
        //[StringLength(3, MinimumLength = 3)]
        //[RegularExpression(@"^[0-9]{0,15}$")]
        public String clientCardCvc { get; set; }

        [DisplayName("Authorization ID")]
        public int? authorizationID { get; set; }
        public virtual UserAuth Authorization { get; set; }
    }
}