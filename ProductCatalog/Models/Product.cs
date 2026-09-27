using System.ComponentModel.DataAnnotations;
namespace ProductCatalog.Models;
public class Product
{
 public int Id { get; set; }
 [Required, StringLength(100, MinimumLength=2)] public string Name { get; set; } = "";
 [Required, StringLength(70)] public string Category { get; set; } = "";
 [Required, StringLength(800, MinimumLength=10)] public string Description { get; set; } = "";
 [Display(Name="Price (₹)"), Range(0.01,1000000)] public decimal Price { get; set; }
 [Range(0,100000), Display(Name="Stock quantity")] public int Stock { get; set; }
 [Display(Name="Image URL"), Url] public string? ImageUrl { get; set; }
 [Display(Name="Featured product")] public bool IsFeatured { get; set; }
}
