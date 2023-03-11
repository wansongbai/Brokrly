using System.ComponentModel.DataAnnotations;

namespace Dobany.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
