using System.ComponentModel.DataAnnotations;

namespace Dobany.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}