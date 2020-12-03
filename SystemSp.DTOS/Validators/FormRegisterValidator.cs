using FluentValidation;
using SystemSp.DTOS.EntitisFormsApp;

namespace SystemSp.DTOS.Validators
{
    public class FormRegisterValidator : AbstractValidator<FormRegister>
    {
        public FormRegisterValidator() 
        {
            RuleFor(option => option.NameUser)
                .Length(1, 30)
                .NotEmpty()
                .NotNull()
                .WithMessage("El campo nombre contiene caracteres no permitido");
        }

    }
}
