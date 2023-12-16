

namespace Domain.Entities.Base;

public interface IEntityBase<T>
{
    T Id { get; set; }
}

