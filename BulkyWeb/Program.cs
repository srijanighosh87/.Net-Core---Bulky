using Bulky.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//register services for Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//Register Entity framework services to container :  register implementation class for DbContext
// options container which database we want to connect to
builder.Services
    .AddDbContext<ApplicationDbContext>
    (options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); //PostgreSQL

var app = builder.Build();


// Pipeline: when a request comes to the proces, how do we want to handle that
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); 
app.UseStaticFiles(); // all static files in wwwroot will be accessible

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");  
//if no controller is available, go to homecontroller and Index action 

app.Run();
