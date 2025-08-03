using Microsoft.EntityFrameworkCore;

namespace SpecificationPattern.Repositories;

public class Repository<T> where T : class
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> ListAsync(Specification<T> spec)
    {
        var query = _context.Set<T>().AsQueryable();
        if (spec.Criteria is not null)
            query = spec.Criteria(query);

        return await query.ToListAsync();
    }
}