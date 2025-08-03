namespace SpecificationPattern;

public abstract class Specification<T>
{
    public Func<IQueryable<T>, IQueryable<T>>? Criteria { get; protected set; }
}