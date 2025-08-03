namespace SpecificationPattern.DTO;

public class ProductFilterDto
{
    public string? Search { get; set; }
    public int? CategoryId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? OrderBy { get; set; } // "name" o "price"
    public bool Descending { get; set; } = false;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}