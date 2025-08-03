using SpecificationPattern.DTO;
using SpecificationPattern.Entities;
using SpecificationPattern.Repositories;

namespace SpecificationPattern.Services;

public class ProductService
{
    private readonly Repository<Product> _repository;

    public ProductService(Repository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetFilteredProductsAsync(ProductFilterDto filter)
    {
        var spec = new ProductSpecification(filter);
        return await _repository.ListAsync(spec);
    }
}