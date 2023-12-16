using MongoDB.Bson;

namespace Application.UseCases.Suppliers.Commands.SupplierUpdate;

public class SupplierUpdateValidator : AbstractValidator<SupplierUpdateCommand>
{
    public SupplierUpdateValidator()
    {
        RuleFor(_ => _.SupplierId).NotNull().WithMessage("El Id no puede ser nulo")
            .NotEmpty().WithMessage("El Id es obligatorio")
            .Must(BeValidObjectId)
            .WithMessage("El valor proporcionado para el Id no es un ObjectId válido");

        RuleFor(_ => _.BusinessName)
            .NotEmpty().WithMessage("El nombre de la empresa es obligatorio")
            .MaximumLength(50).WithMessage("El nombre de la empresa no puede exceder los 50 caracteres")
            .When(_ => _.BusinessName != null);

        RuleFor(_ => _.Address).NotNull().WithMessage("La direccion no puede ser nulo")
            .NotEmpty().WithMessage("La dirección es obligatoria")
            .MaximumLength(50).WithMessage("La dirección no puede exceder los 50 caracteres")
            .When(_ => _.Address != null);

        RuleFor(_ => _.City).NotNull().WithMessage("La ciudad no puede ser nulo")
            .NotEmpty().WithMessage("La ciudad es obligatoria")
            .MaximumLength(30).WithMessage("La ciudad no puede exceder los 30 caracteres")
            .When(_ => _.City != null);

        RuleFor(_ => _.Department).NotNull().WithMessage("El departamento no puede ser nulo")
            .NotEmpty().WithMessage("El departamento es obligatorio")
            .MaximumLength(30).WithMessage("El departamento no puede exceder los 30 caracteres")
            .When(_ => _.Department != null);

        RuleFor(_ => _.Email).NotNull().WithMessage("El correo no puede ser nulo")
            .NotEmpty().WithMessage("El correo electrónico es obligatorio")
            .EmailAddress().WithMessage("Ingrese un correo electrónico válido")
            .When(_ => _.Email != null);

        RuleFor(_ => _.Active)
            .NotNull().WithMessage("El estado activo es obligatorio")
            .Must(BeBoolean).WithMessage("El campo Active debe ser un booleano")
            .When(_ => _.Active != null);

        RuleFor(_ => _.ContactName).NotNull().WithMessage("El nombre del contacto no puede ser nulo")
            .NotEmpty().WithMessage("El nombre de contacto es obligatorio")
            .MaximumLength(50).WithMessage("El nombre de contacto no puede exceder los 50 caracteres")
            .When(_ => _.ContactName != null);

        RuleFor(_ => _.ContactEmail).NotNull().WithMessage("El correo electronico de contacto no puede ser nulo")
            .NotEmpty().WithMessage("El correo electrónico de contacto es obligatorio")
            .EmailAddress().WithMessage("Ingrese un correo electrónico de contacto válido")
            .When(_ => _.ContactEmail != null);
    }

    private bool BeValidObjectId(string id)
    {
        return ObjectId.TryParse(id, out _);
    }

    private bool BeBoolean(bool? value)
    {
        return true;
    }
}