using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using ProductCatalog.Services;
namespace ProductCatalog.Controllers;
public class ProductsController(ProductCatalogService catalog) : Controller
{
 public IActionResult Index(string? search,string? category,string sort="featured"){var r=catalog.Browse(search,category,sort);return View(new CatalogViewModel{Products=r.Items,Categories=r.Categories,Search=search,Category=category,Sort=sort,TotalProducts=catalog.Count});}
 public IActionResult Details(int id)=>catalog.Find(id) is {} p?View(p):NotFound();
 public IActionResult Create()=>View(new Product());
 [HttpPost,ValidateAntiForgeryToken] public IActionResult Create(Product p){if(!ModelState.IsValid)return View(p);catalog.Add(p);TempData["Notice"]=$"{p.Name} was added to your catalog.";return RedirectToAction(nameof(Index));}
 public IActionResult Edit(int id)=>catalog.Find(id) is {} p?View(p):NotFound();
 [HttpPost,ValidateAntiForgeryToken] public IActionResult Edit(int id,Product p){if(id!=p.Id)return BadRequest();if(!ModelState.IsValid)return View(p);if(!catalog.Update(p))return NotFound();TempData["Notice"]=$"{p.Name} was updated.";return RedirectToAction(nameof(Index));}
 public IActionResult Delete(int id)=>catalog.Find(id) is {} p?View(p):NotFound();
 [HttpPost,ActionName("Delete"),ValidateAntiForgeryToken] public IActionResult DeleteConfirmed(int id){if(!catalog.Delete(id))return NotFound();TempData["Notice"]="Product removed from your catalog.";return RedirectToAction(nameof(Index));}
}
