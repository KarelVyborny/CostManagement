using CostManagementSystem.Application.Services;
using CostManagementSystem.Application.Services.Cost_Approval_Workflow;
using CostManagementSystem.Application.Services.CostCode;
using CostManagementSystem.Application.Services.CostRequests;
using CostManagementSystem.Application.Services.Projects;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((ctx, config) =>
    config.WriteTo
    .Console()
    .ReadFrom.Configuration(ctx.Configuration));
// Add services to the container.



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options
.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<ICostCodesService, CostCodesService>();
builder.Services.AddScoped<ICostApprovalService, CostApprovalService>();
builder.Services.AddScoped<ICostRequestService, CostRequestService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
