using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GoLiveServiceLogic_v2.Application.DTO.Validations
{
    public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe um nome!");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotNull()
                .WithMessage("Informe um email válido");
        }
    }
}
