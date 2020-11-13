using System.ComponentModel.DataAnnotations;

namespace SystemSp.DTOS.EntitisFormsApp
{
    public class FormLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(30, ErrorMessage = "Correo Invalido")]
        public string EmailLogin { get; set; }

        [Required]
        [StringLength(12, ErrorMessage= "Contraseña Invalido")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        public string PasswordLogin { get; set; }
    }
}
