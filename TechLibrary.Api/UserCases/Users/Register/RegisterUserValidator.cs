using FluentValidation;
using TechLibrary.Comunication.Requests;

namespace TechLibrary.Api.UserCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O nome não pode ser vazio.");

            RuleFor(request => request.Email).EmailAddress().WithMessage("O e-mail não é válido");
            RuleFor(request => request.Password).NotEmpty().WithMessage("A senha é obirgatória");

            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request=>request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("Senha deve ter mais que 6 caracteres");
            });


            
        }
    }
}
