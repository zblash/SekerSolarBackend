using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Concrete.Identity
{
    public class AppIdentityContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        {
            
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SekerSolar;Trusted_Connection=true");
        }
    }
    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<AppIdentityContext>
    {
        AppIdentityContext IDesignTimeDbContextFactory<AppIdentityContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityContext>();
            optionsBuilder.UseSqlServer<AppIdentityContext>(@"Server=(localdb)\MSSQLLocalDB;Database=SekerSolar;Trusted_Connection=true");

            return new AppIdentityContext(optionsBuilder.Options);
        }
    }
}
