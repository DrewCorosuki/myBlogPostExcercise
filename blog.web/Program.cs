using blog.core.Interface.IRepository;
using blog.core.Interface.IService.IBlogPostService;
using blog.core.Interface.IService.IRoleService;
using blog.core.Interface.IService.IUserService;
using blog.core.Service.BlogPostService;
using blog.core.Service.RoleService;
using blog.core.Service.UserService;
using blog.infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//REPOSITORIES
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();

//SERVICES
builder.Services.AddScoped<IRoleManagementService, RoleManagementService>();
builder.Services.AddScoped<IRoleRetrievalService, RoleRetrievalService>();

builder.Services.AddScoped<IUserManagementService, UserManagementService>();
builder.Services.AddScoped<IUserRetrievalService, UserRetrievalService>();

builder.Services.AddScoped<IBlogPostManagementService, BlogPostManagementService>();
builder.Services.AddScoped<IBlogPostRetrievalService, BlogPostRetrievalService>();


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