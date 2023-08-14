using Dev.Application.Shared.Customer;
using FluentValidation;

namespace Dev.Application.Shared.Validator.Customer
{
    public class CustomerValidator : AbstractValidator<CreateModel>
    {
        public CustomerValidator()
        {
            RuleFor(e => e.Nome)
               .NotNull().WithMessage("Nome obrigatório.")
               .NotEmpty().WithMessage("Nome obrigatório.");

            RuleFor(e => e.Telefone)
                .NotNull().WithMessage("Telefone obrigatório.")
                .NotEmpty().WithMessage("Telefone obrigatório.");
        }
    }
}
