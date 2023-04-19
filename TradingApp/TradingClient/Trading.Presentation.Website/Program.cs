using Trading.Business.Logic.Implementations;
using Trading.Business.Logic.Interfaces;
using Trading.Presentation.Website.Automapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStockBl, StockBl>();
builder.Services.AddScoped<IPortfolioBl, PortfolioBl>();
// HttpClient
builder.Services.AddHttpClient();
// Automapper
builder.Services.AddAutoMapper(typeof(AutoMapping));
//Remove Headers
builder.WebHost.UseKestrel(options => options.AddServerHeader = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
