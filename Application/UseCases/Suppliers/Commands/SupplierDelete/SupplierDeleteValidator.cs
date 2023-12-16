using MongoDB.Bson;

namespace Application.UseCases.Suppliers.Commands.SupplierDelete;

public class SupplierDeleteValidator : AbstractValidator<SupplierDeleteCommand>
{
    public SupplierDeleteValidator()
    {
        RuleFor(_ => _.SupplierId)
            .NotNull().WithMessage("El Id no puede ser nulo")
            .NotEmpty().WithMessage("El Id es obligatorio")
            .Must(BeValidObjectId)
            .WithMessage("El valor proporcionado para el Id no es un ObjectId válido");
    }

    private bool BeValidObjectId(string id)
    {
        return ObjectId.TryParse(id, out _);
    }
}