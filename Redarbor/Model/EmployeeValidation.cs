using BL.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redarbor.Model
{
    public class EmployeeValidation : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Username).NotNull()
                .NotEmpty()
                .WithMessage("El valor enviado para el Username no es valido");

            RuleFor(x => x.Username).NotNull()
                .NotEmpty()
                .WithMessage($"El valor enviado para el .Name no es valido");

            RuleFor(x => x.Password).NotNull()
                .NotEmpty()
                .WithMessage($"El valor enviado para el Password no es valido ");

            RuleFor(x => x.CompanyId).InclusiveBetween(1, int.MaxValue)
                .WithMessage("El valor enviado para el CompanyId no es valido");

            RuleFor(x => x.CreatedOn)
                .Must(IsValidDate)
                .WithMessage("Ingrese una fecha valida para el valor CreatedOn");

            RuleFor(x => x.DeletedOn)
                .NotEmpty()
                .Must(IsValidDate)
                .WithMessage("Ingrese una fecha valida para el valor DeletedOn");

            RuleFor(x => x.UpdatedOn).
                Must(IsValidDate)
                .WithMessage("Ingrese una fecha valida para el valor UpdatedOn");

            RuleFor(x => x.Lastlogin)
                .Must(IsValidDate)
                .WithMessage("Ingrese una fecha valida para el valor Lastlogin");

            RuleFor(x => x.PortalId)
               .InclusiveBetween(1, int.MaxValue)
                .WithMessage("El valor enviado para el PortalId no es valido");

            RuleFor(x => x.RoleId).InclusiveBetween(1, int.MaxValue)
                .WithMessage("El valor enviado para el RoleId no es valido");


        }

        private bool IsValidDate(string date) => DateTime.TryParse(date, out _);
        private bool IsValidId(int value) => value > 1;
    }
}
