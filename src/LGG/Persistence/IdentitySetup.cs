using LGG.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LGG.Persistence
{
    public class IdentitySetup
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public IdentitySetup(RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Setup()
        {
            // Create roles and role claims 
            var user = await _userManager.FindByNameAsync("dev@dev.com");

            // Add user to claim and role
            if (user != null) return;

            // Create roles and role claims 
            var adminRole = await _roleManager.FindByNameAsync("admin");
            if (adminRole == null)
            {
                adminRole = new IdentityRole("admin");
                adminRole.Claims.Add(new IdentityRoleClaim<string> { ClaimType = "isAdmin", ClaimValue = "true" });
                await _roleManager.CreateAsync(adminRole);
            }

            user = new User
            {
                UserName = "dev@dev.com"
            };

            var userResult = await _userManager.CreateAsync(user, "Dev#123");
            var roleResult = await _userManager.AddToRoleAsync(user, "admin");
            var claimResult = await _userManager.AddClaimAsync(user, new Claim("isSuperUser", "true"));

            if (!userResult.Succeeded || !roleResult.Succeeded || !claimResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to build user and roles");
            }
        }
    }
}
