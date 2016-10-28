using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;

namespace ChatterBugs.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<ApplicationUser> Followers { get; set; }
        public ICollection<ApplicationUser> Following { get; set; }

        public enum EFollowerType
        {
            Follower = 1,
            Following
        }

        public Post UserPost { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasMany(m => m.Followers).WithMany(p => p.Following).Map(w => w.ToTable("ApplicationUser_Follow").MapLeftKey("ApplicationUserID").MapRightKey("FollowerID"));
            base.OnModelCreating(modelBuilder);
        }
    }

    
}