
using FluentValidation;
namespace Desafio.Domain
{
	public class UserValidator : AbstractValidator<User>
    {
		public UserValidator()
		{
            RuleFor(c => c.Email)
               .NotNull().WithMessage("Email should not be null!")
               .NotEmpty().WithMessage("Email should not be empty!")
               .Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")
                .WithMessage("O campo de e-mail não está no formato esperado.");

            RuleFor(c => c.Password)
                .NotNull().WithMessage("Password should not be null!")
                .NotEmpty().WithMessage("Password should not be empty!");
        }
	}
}

