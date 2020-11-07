using System.ComponentModel.DataAnnotations;

namespace SystemSp.DTOS.EntitisFormsApp
{
    public class FormRegister
    {
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string EmailConfirm { get; set; }

        public string IdentificationNumber { get; set; }

        public string IdentificacionType { get; set; }

        [Required]
        [StringLength(16)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        public string Password { get; set; }

        [Required]
        [StringLength(16)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        public string PasswordConfirm { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string NameUser { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastNameUser { get; set; }

        public string Telephone { get; set; }

        public int UserType { get; set; }

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }

        public string City { get; set; }
    }
}
