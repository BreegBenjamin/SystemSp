using System.ComponentModel.DataAnnotations;

namespace SystemSp.DTOS.EntitisFormsApp
{
    public class FormLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailLogin { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string PasswordLogin { get; set; }
    }
}
