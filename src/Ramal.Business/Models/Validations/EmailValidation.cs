using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Models.Validations
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation() 
        {
            RuleFor(e => e.Conta)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(e => e.Senha)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(e => e.SetorId)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

           


        }
    }
}
