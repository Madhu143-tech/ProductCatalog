namespace ProductCatalog.Models;
public class CatalogViewModel
{
 public IReadOnlyList<Product> Products { get; init; } = [];
 public IReadOnlyList<string> Categories { get; init; } = [];
 public string? Search { get; init; }
 public string? Category { get; init; }
 public string Sort { get; init; } = "featured";
 public int TotalProducts { get; init; }
}
