using Microsoft.EntityFrameworkCore;
using Top_Rooftop_project;
using Top_Rooftop_project.Database;
using Top_Rooftop_project.RepositoryServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

builder.Services.AddAutoMapper(x =>
{
	x.AddMaps(typeof(ICore).Assembly);
});

builder.Services.AddTransient<IFarmerRepositoryServices, FarmerRepositoryServices>();
builder.Services.AddTransient<IAdminRepositoryServices, AdminRepositoryServices>();
builder.Services.AddTransient<IHouseOwnerRepositoroyServices,HouseOwnerRepositoryServices>();
builder.Services.AddTransient<IPaymentReposiotryServices,PaymentRepositoryServices>();
builder.Services.AddTransient<IUserRepositoryServices,UserRepositoryservices>();



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
