using ProductCatalog.Services;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ProductCatalogService>();
var app=builder.Build();
if(!app.Environment.IsDevelopment()){app.UseExceptionHandler("/Home/Error");app.UseHsts();}
app.UseHttpsRedirection();app.UseStaticFiles();app.UseRouting();app.UseAuthorization();
app.MapControllerRoute(name:"product-details",pattern:"products/{id:int}",defaults:new{controller="Products",action="Details"});
app.MapControllerRoute(name:"default",pattern:"{controller=Products}/{action=Index}/{id?}");
app.Run();
