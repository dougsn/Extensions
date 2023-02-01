using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Models.Validations
{
    public class SetorValidation : AbstractValidator<Setor>
    {
        public SetorValidation() 
        {
            RuleFor(s => s.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
