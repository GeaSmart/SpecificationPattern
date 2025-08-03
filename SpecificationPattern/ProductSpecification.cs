using Microsoft.EntityFrameworkCore;
using SpecificationPattern.DTO;
using SpecificationPattern.Entities;

namespace SpecificationPattern;

public class ProductSpecification : Specification<Product>
{
    public ProductSpecification(ProductFilterDto filter)
    {
        Criteria = query =>
        {
            if (!string.IsNullOrWhiteSpace(filter.Search))
                query = query.Where(p => p.Name.Contains(filter.Search));

            if (filter.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == filter.CategoryId);

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);

            query = query.Where(p => p.IsActive); // Solo activos

            // Incluir relación
            query = query.Include(p => p.Category);

            // Ordenamiento
            if (!string.IsNullOrEmpty(filter.OrderBy))
            {
                query = filter.OrderBy.ToLower() switch
                {
                    "price" => filter.Descending ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
                    _ => filter.Descending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
                };
            }

            // Paginación
            int skip = (filter.Page - 1) * filter.PageSize;
            query = query.Skip(skip).Take(filter.PageSize);

            return query;
        };
    }
}