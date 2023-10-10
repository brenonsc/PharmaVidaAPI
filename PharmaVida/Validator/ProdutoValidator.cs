using FluentValidation;
using PharmaVida.Model;

namespace PharmaVida.Validator;

public class ProdutoValidator : AbstractValidator<Produto>
{
    public ProdutoValidator()
    {
        RuleFor(p => p.Titulo)
            .NotEmpty()
            .WithMessage("O título do produto não pode ser vazio.")
            .MaximumLength(100)
            .WithMessage("O título do produto não pode ter mais de 100 caracteres.");
        
        RuleFor(p => p.Fabricante)
            .NotEmpty()
            .WithMessage("O fabricante do produto não pode ser vazio.")
            .MaximumLength(100)
            .WithMessage("O fabricante do produto não pode ter mais de 100 caracteres.");
        
        RuleFor(p => p.PrecisaReceita)
            .NotNull()
            .WithMessage("A informação se o produto precisa de receita não pode ser vazia.");
        
        
        RuleFor(p => p.DataVencimento)
            .NotEmpty()
            .WithMessage("A data de vencimento do produto não pode ser vazia.")
            .GreaterThan(DateTime.Now)
            .WithMessage("A data de vencimento do produto deve ser maior que a data atual.");
        
        RuleFor(p => p.Preco)
            .NotEmpty()
            .WithMessage("O preço do produto não pode ser vazio.")
            .GreaterThan(0)
            .WithMessage("O preço do produto deve ser maior que 0.");
    }
}