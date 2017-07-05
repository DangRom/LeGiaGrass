using LGG.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace LGG.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Excerpt> Excerpts { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Gallery> Galleries { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            // Insure Identity Entities are accounted for.
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.Id).HasMaxLength(36);
            modelBuilder.Entity<User>().Property(u => u.NormalizedEmail).HasMaxLength(128);

            modelBuilder.Entity<IdentityRole>().Property(r => r.Id).HasMaxLength(36);

            modelBuilder.Entity<IdentityUserRole<string>>().Property(r => r.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserRole<string>>().Property(r => r.RoleId).HasMaxLength(36);

            modelBuilder.Entity<IdentityUserToken<string>>().Property(r => r.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserToken<string>>().Property(r => r.LoginProvider).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserToken<string>>().Property(r => r.Name).HasMaxLength(36);

            modelBuilder.Entity<IdentityUserLogin<string>>().Property(r => r.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserLogin<string>>().Property(r => r.LoginProvider).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserLogin<string>>().Property(r => r.ProviderKey).HasMaxLength(36);

            modelBuilder.Entity<IdentityRoleClaim<string>>().Property(r => r.RoleId).HasMaxLength(36);

            modelBuilder.Entity<IdentityUserClaim<string>>().Property(r => r.UserId).HasMaxLength(36);
        }

        public async void EnsureSeedData(UserManager<User> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            // Create roles and role claims 
            var user = await userMgr.FindByIdAsync("dev@dev.com");

            // Add user to claim and role
            if (user != null) return;

            // Create roles and role claims 
            var adminRole = await roleMgr.FindByNameAsync("admin");
            if (adminRole == null)
            {
                adminRole = new IdentityRole("admin");
                adminRole.Claims.Add(new IdentityRoleClaim<string> { ClaimType = "isAdmin", ClaimValue = "true" });
                await roleMgr.CreateAsync(adminRole);
            }

            user = new User
            {
                UserName = "dev@dev.com"
            };

            var userResult = await userMgr.CreateAsync(user, "dev");
            var roleResult = await userMgr.AddToRoleAsync(user, "admin");
            var claimResult = await userMgr.AddClaimAsync(user, new Claim("superUser", "true"));

            if (!userResult.Succeeded || !roleResult.Succeeded || !claimResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to build user and roles");
            }
        }
    }
}
