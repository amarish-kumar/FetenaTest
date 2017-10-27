using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fetena.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        private void ApplyDateTimeStamp()
        {
            // Add time stamp for created and modified models
            foreach (var entry in this.ChangeTracker.Entries()
                .Where( e => e.Entity is IDateTimeStamp && (e.State == EntityState.Added) ||
                         (e.State == EntityState.Modified)))
            {
                var e = (IDateTimeStamp) entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    e.DateAdded = DateTime.Now;
                }

                e.DateModified = DateTime.Now;
            }
        }

        public override int SaveChanges()
        {
            this.ApplyDateTimeStamp();

            return base.SaveChanges();
        }

    }
}