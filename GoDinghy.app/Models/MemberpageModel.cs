using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace GoDinghy.app.Models
{
    public class MemberpageModel
    {
        public string Header { get; set; }
        public IHtmlString Bodytext { get; set; }
        public CreateMemberModel MemberModel { get; set; }
    }

    public class CreateMemberModel
    {
        [Required(ErrorMessage = "Skal udfyldes")]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> MemberGroups { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        public string SelectedGroup { get; set; }

        [Display(Name = "Brugernavn*")]
        [Required(ErrorMessage = "Skal udfyldes")]
        public string Username { get; set; }

        [Display(Name = "Navn*")]
        [Required(ErrorMessage = "Skal udfyldes")]
        public string Name { get; set; }

        [Display(Name = "Adgangskode*")]
        [Required(ErrorMessage = "Skal udfyldes")]
        public string Password { get; set; }
        public int NodeId { get; set; }
    }
}