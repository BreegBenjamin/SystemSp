using System.ComponentModel.DataAnnotations;

namespace SystemSp.DTOS.EntitisFormsApp
{
    public class FormRegister
    {
        [Required]
        [StringLength(100, ErrorMessage= "El campo email solo puede tener más de 100 caracteres")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "La campo email contiene caracteres no permitidos")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo confirmar email solo puede tener más de 100 caracteres")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "La campo confirmar email contiene caracteres no permitidos")]
        public string EmailConfirm { get; set; }

        [Required]
        [StringLength(25, ErrorMessage= "El campo número de identificación solo puede contener maximo 25 caracteres")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo número de identificación contiene caracteres no permitido")]
        public string IdentificationNumber { get; set; }

        [Required]
        [StringLength(1)]
        public string IdentificacionType { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "El campo contraseña solo puede tener 16 caracteres")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "El campo contraseña contiene caracteres no permitido")]
        public string Password { get; set; }

        [Required]
        [StringLength(16, ErrorMessage= "El campo contraseña solo puede tener 16 caracteres")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "El campo contraseña contiene caracteres no permitido")]
        public string PasswordConfirm { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "El campo nombre no puede contener más de 30 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo nombre contiene caracteres no permitido")]
        public string NameUser { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "El campo apellido no puede contener más de 30 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo apellido contiene caracteres no permitido")]
        public string LastNameUser { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El campo teléfono solo puede contener maximo 10 caracteres")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo teléfono contiene caracteres no permitido")]
        public string Telephone { get; set; }

        [Required]
        public int UserType { get; set; }

        [StringLength(50, ErrorMessage = "El campo empresa ciudad no puede contener más de 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo empresa ciudad contiene caracteres no permitido")]
        public string CompanyName { get; set; }

        [StringLength(100, ErrorMessage = "El campo dirección empresa no puede contener más de 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo dirección empresa contiene caracteres no permitido")]
        public string CompanyAddress { get; set; }

        [StringLength(50, ErrorMessage = "El campo nombre ciudad no puede contener más de 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo nombre ciudad contiene caracteres no permitido")]
        public string City { get; set; }
    }
}
