namespace Application.UseCases.Suppliers.Commands.SupplierCreate;

public class SupplierCreateValidator : AbstractValidator<SupplierCreateCommand>
{
    public SupplierCreateValidator()
    {
        RuleFor(_ => _.Nit).NotNull().WithMessage("El NIT no puede ser nulo")
            .NotEmpty().WithMessage("El NIT es obligatorio")
            .Length(8, 12).WithMessage("El NIT debe tener entre 8 y 12 caracteres");

        RuleFor(_ => _.BusinessName).NotNull().WithMessage("El nombre de la empresa no puede ser nulo")
            .NotEmpty().WithMessage("El nombre de la empresa es obligatorio")
            .MaximumLength(50).WithMessage("El nombre de la empresa no puede exceder los 50 caracteres");

        RuleFor(_ => _.Address).NotNull().WithMessage("La direccion no puede ser nulo")
            .NotEmpty().WithMessage("La dirección es obligatoria")
            .MaximumLength(50).WithMessage("La dirección no puede exceder los 50 caracteres");

        RuleFor(_ => _.City).NotNull().WithMessage("La ciudad no puede ser nulo")
            .NotEmpty().WithMessage("La ciudad es obligatoria")
            .MaximumLength(30).WithMessage("La ciudad no puede exceder los 30 caracteres");

        RuleFor(_ => _.Department).NotNull().WithMessage("El departamento no puede ser nulo")
            .NotEmpty().WithMessage("El departamento es obligatorio")
            .MaximumLength(30).WithMessage("El departamento no puede exceder los 30 caracteres");

        RuleFor(_ => _.Email).NotNull().WithMessage("El correo no puede ser nulo")
            .NotEmpty().WithMessage("El correo electrónico es obligatorio")
            .EmailAddress().WithMessage("Ingrese un correo electrónico válido");

        RuleFor(_ => _.ContactName).NotNull().WithMessage("El nombre del contacto no puede ser nulo")
            .NotEmpty().WithMessage("El nombre de contacto es obligatorio")
            .MaximumLength(50).WithMessage("El nombre de contacto no puede exceder los 50 caracteres");

        RuleFor(_ => _.ContactEmail).NotNull().WithMessage("El correo electronico de contacto no puede ser nulo")
            .NotEmpty().WithMessage("El correo electrónico de contacto es obligatorio")
            .EmailAddress().WithMessage("Ingrese un correo electrónico de contacto válido");
    }
}