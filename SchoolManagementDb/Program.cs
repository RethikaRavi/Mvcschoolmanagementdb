using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementDb.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ClassesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClassesDbContext") ?? throw new InvalidOperationException("Connection string 'ClassesDbContext' not found.")));
builder.Services.AddDbContext<SubjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SubjectDbContext") ?? throw new InvalidOperationException("Connection string 'SubjectDbContext' not found.")));
builder.Services.AddDbContext<SubjectsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SubjectsDbContext") ?? throw new InvalidOperationException("Connection string 'SubjectsDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
