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
        public String clientFirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter your last name")]
        public String clientLastName { get; set; }

        [DisplayName("Street Address")]
        [Required(ErrorMessage = "Please enter your address")]
        public String clientStreetAddress { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Please enter the city in which you live")]
        public String clientCity { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "Please enter the state in which you live")]
        public String clientState { get; set; }

        [DisplayName("Zip Code")]
        [Required(ErrorMessage = "Please enter your zip code")]
        public String clientZip { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Please enter your phone number")]
        public String clientPhoneNumber { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public String clientEmail { get; set; }

        [DisplayName("Credit Card Number")]
        [Required(ErrorMessage = "Please enter your card")]
        public String clientCardNumber { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Please enter your security code")]
        public String clientCardCvc { get; set; }

        [DisplayName("Authorization ID")]
        public int? authorizationID { get; set; }
        public virtual Authorization Authorization { get; set; }
    }
}