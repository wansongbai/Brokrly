using System.ComponentModel.DataAnnotations;

namespace Dobany.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}