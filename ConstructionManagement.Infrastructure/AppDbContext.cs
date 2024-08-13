using ConstructionManagement.Core.Entities;
using ConstructionManagement.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Infrastructure
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Worker> Workers { get; set; }      
        public DbSet<Activity> Activities { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .HasMany(w => w.Activities)         
                .WithOne(a => a.Worker)             
                .HasForeignKey(a => a.WorkerId);

            modelBuilder.Entity<Worker>()
                   .Property(w => w.Role)
                   .HasConversion<int>();

            base.OnModelCreating(modelBuilder); 
        }
    }
}
