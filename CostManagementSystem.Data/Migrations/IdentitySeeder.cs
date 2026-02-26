using CostManagementSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace CostManagementSystem.Data.Migrations;

public static class IdentitySeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // Roles
        string[] roles = ["Admin", "User","Reviewer"];
        foreach (var r in roles)
            if (!await roleManager.RoleExistsAsync(r))
                await roleManager.CreateAsync(new IdentityRole(r));

        // Admin user (změň si email/heslo)
        var adminEmail = "admin@local.test";
        var adminPassword = "Admin123!";

        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Account",
                DateOfBirth = new DateOnly(2000, 1, 1) // pokud to taky máš NOT NULL
            };
            var create = await userManager.CreateAsync(admin, adminPassword);
            if (!create.Succeeded)
                throw new Exception(string.Join("; ", create.Errors.Select(e => e.Description)));
        }

        // Ensure roles on admin
        if (!await userManager.IsInRoleAsync(admin, "Admin"))
            await userManager.AddToRoleAsync(admin, "Admin");
    }
}