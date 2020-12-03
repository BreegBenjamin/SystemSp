using FluentValidation;
using SystemSp.DTOS.EntitisFormsApp;

namespace SystemSp.DTOS.Validators
{
    public class FormLoginValidator : AbstractValidator<FormLogin>
    {
        public FormLoginValidator()
        {
            RuleFor(login => login.PasswordLogin)
                .NotNull()
                .Length(6,16)
                .WithMessage("La contraseña incresada esta errada");
            RuleFor(email => email.EmailLogin)
                .NotNull()
                .Length(1, 100)
                .WithMessage("El Email ingresado no es valido");
        }
    }
}
