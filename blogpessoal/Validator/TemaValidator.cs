using blogpessoal.Model;
using FluentValidation;

namespace blogpessoal.Validator 
{
    public class TemaValidator : AbstractValidator<Tema>
    {
        public TemaValidator()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}