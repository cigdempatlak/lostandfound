using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using LostAndFound.Data.Entities;
using System;

namespace LostAndFound.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
   
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<LostItemReport> LostItemReports { get; set; }
        public DbSet<TypeOfItem> TypeOfItems { get; set; }

        public AppDbContext()
            : base("LostAndFoundDB")
        {
          
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}