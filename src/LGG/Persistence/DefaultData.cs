//using LGG.Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace LGG.Persistence
{
    public class DefaultData
    {
        //public async Task InitializeCompanyDataAsync(IServiceProvider serviceProvider, bool createUsers = true)
        //{
        //    using (var serviceScope = serviceProvider.CreateScope())
        //    {
        //        var scopeServiceProvider = serviceScope.ServiceProvider;
        //        var db = scopeServiceProvider.GetService<ApplicationDbContext>();

        //        if (await db.Database.EnsureCreatedAsync())
        //        {
        //            await InsertCompanyData(scopeServiceProvider);
        //        }
        //    }
        //}

        //private async Task InsertCompanyData(IServiceProvider serviceProvider)
        //{
        //    Company[] companies = new Company[]
        //    {
        //        new Company
        //        {
        //            Id =1,
        //            Name ="Le Gia Grass",
        //            Hotline ="+84 123 456 789"
        //        }
        //    };
        //    await AddOrUpdateAsync(serviceProvider, a => a.Id, companies);
        //}

        //// TODO [EF] This may be replaced by a first class mechanism in EF
        //private async Task AddOrUpdateAsync<TEntity>(
        //    IServiceProvider serviceProvider,
        //    Func<TEntity, object> propertyToMatch, IEnumerable<TEntity> entities)
        //    where TEntity : class
        //{
        //    // Query in a separate context so that we can attach existing entities as modified
        //    List<TEntity> existingData;
        //    using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        //    {
        //        var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        //        existingData = db.Set<TEntity>().ToList();
        //    }

        //    using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        //    {
        //        var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        //        foreach (var item in entities)
        //        {
        //            db.Entry(item).State = existingData.Any(g => propertyToMatch(g).Equals(propertyToMatch(item)))
        //                ? EntityState.Modified
        //                : EntityState.Added;
        //        }

        //        await db.SaveChangesAsync();
        //    }
        //}

    }
}
