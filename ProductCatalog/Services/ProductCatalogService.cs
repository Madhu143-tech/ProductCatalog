using ProductCatalog.Models;
namespace ProductCatalog.Services;
public class ProductCatalogService
{
 readonly object gate = new();
 readonly List<Product> products = new()
 {
  new(){Id=1,Name="Wireless Headphones",Category="Electronics",Description="Comfortable wireless headphones with clear sound and a long-lasting battery for everyday listening.",Price=3499,Stock=18,IsFeatured=true},
  new(){Id=2,Name="Laptop Backpack",Category="Accessories",Description="A durable everyday backpack with a padded laptop sleeve and useful storage pockets.",Price=2499,Stock=12,IsFeatured=true},
  new(){Id=3,Name="Ceramic Dinner Set",Category="Home Appliances",Description="A six-piece ceramic dinner set that is suitable for everyday meals and easy cleaning.",Price=1899,Stock=26,IsFeatured=true},
  new(){Id=4,Name="Smart Watch",Category="Electronics",Description="A lightweight smart watch with activity tracking, notifications, and a bright display.",Price=4999,Stock=7},
  new(){Id=5,Name="Tool Kit",Category="Hardware",Description="A compact home tool kit containing pliers, screwdrivers, a hammer, measuring tape, and more.",Price=1599,Stock=9,IsFeatured=true},
  new(){Id=6,Name="Mixer Grinder",Category="Home Appliances",Description="A three-jar mixer grinder for preparing chutneys, spices, juices, and batters.",Price=3299,Stock=15},
  new(){Id=7,Name="Bluetooth Speaker",Category="Electronics",Description="A portable Bluetooth speaker with clear sound, simple controls, and rechargeable battery.",Price=1499,Stock=31},
  new(){Id=8,Name="Electric Kettle",Category="Home Appliances",Description="A fast-boiling electric kettle with auto shut-off and a one-litre stainless steel body.",Price=1299,Stock=22},
  new(){Id=9,Name="Cordless Drill Machine",Category="Hardware",Description="A rechargeable drill machine suitable for common home repair and installation work.",Price=4299,Stock=11,IsFeatured=true},
  new(){Id=10,Name="LED Study Lamp",Category="Electronics",Description="An energy-efficient LED desk lamp with adjustable brightness for study and office use.",Price=899,Stock=24},
  new(){Id=11,Name="Steam Iron",Category="Home Appliances",Description="A compact steam iron with a non-stick soleplate for quick and neat clothes pressing.",Price=1799,Stock=16},
  new(){Id=12,Name="Adjustable Spanner",Category="Hardware",Description="A strong adjustable spanner for household plumbing, assembly, and repair tasks.",Price=449,Stock=35}
 };
 public int Count { get { lock(gate) return products.Count; } }
 public (IReadOnlyList<Product> Items,IReadOnlyList<string> Categories) Browse(string? search,string? category,string sort)
 { lock(gate){var cats=products.Select(p=>p.Category).Distinct().Order().ToList();IEnumerable<Product> q=products;
   if(!string.IsNullOrWhiteSpace(search))q=q.Where(p=>p.Name.Contains(search,StringComparison.OrdinalIgnoreCase)||p.Description.Contains(search,StringComparison.OrdinalIgnoreCase));
   if(!string.IsNullOrWhiteSpace(category))q=q.Where(p=>p.Category.Equals(category,StringComparison.OrdinalIgnoreCase));
   q=sort switch{"price-low"=>q.OrderBy(p=>p.Price),"price-high"=>q.OrderByDescending(p=>p.Price),"name"=>q.OrderBy(p=>p.Name),_=>q.OrderByDescending(p=>p.IsFeatured).ThenBy(p=>p.Name)};
   return(q.Select(Copy).ToList(),cats);} }
 public Product? Find(int id){lock(gate)return products.FirstOrDefault(p=>p.Id==id) is {} p?Copy(p):null;}
 public void Add(Product p){lock(gate){p.Id=products.Count==0?1:products.Max(x=>x.Id)+1;products.Add(Copy(p));}}
 public bool Update(Product p){lock(gate){int i=products.FindIndex(x=>x.Id==p.Id);if(i<0)return false;products[i]=Copy(p);return true;}}
 public bool Delete(int id){lock(gate){var p=products.FirstOrDefault(x=>x.Id==id);return p is not null&&products.Remove(p);}}
 static Product Copy(Product p)=>new(){Id=p.Id,Name=p.Name,Category=p.Category,Description=p.Description,Price=p.Price,Stock=p.Stock,ImageUrl=p.ImageUrl,IsFeatured=p.IsFeatured};
}
