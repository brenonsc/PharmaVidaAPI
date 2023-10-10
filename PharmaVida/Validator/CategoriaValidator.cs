using FluentValidation;
using PharmaVida.Model;

namespace PharmaVida.Validator;

public class CategoriaValidator : AbstractValidator<Categoria>
{
    public CategoriaValidator()
    {
        RuleFor(c => c.Tipo)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);
    }
}