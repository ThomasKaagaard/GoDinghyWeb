using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoDinghy.app.Models.Helpers
{
    public class ContactformModel
    {
        [Required(ErrorMessage = "Skal udfyldes")]
        [DisplayName("Navn")]
        public string Name { get; set; }

        [DisplayName("Firma")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        [EmailAddress(ErrorMessage = "Emailformat er ikke gyldigt")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        [DisplayName("Besked")]
        public string Message { get; set; }

        public int NodeId { get; set; }
    }
}