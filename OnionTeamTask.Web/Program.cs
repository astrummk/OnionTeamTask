using Microsoft.EntityFrameworkCore;
using OnionTeamTask.RepositoryLayer;
using OnionTeamTask.RepositoryLayer.Implementation;
using OnionTeamTask.RepositoryLayer.Interface;
using OnionTeamTask.ServiceLayer.Implementation;
using OnionTeamTask.ServiceLayer.Interface;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<TeamTaskManDbContext>();
/*builder.Services.AddDbContext<TeamTaskManDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));*/

// Register generic repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Register services
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IStatusService, StatusService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configuring Entity Framework
//builder.Services.AddDbContext<dbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
