using ClubManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ClubManagmentSystem.ViewModels;

namespace ClubManagmentSystem.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Activityy> Activityys { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activityy>().HasData(
                    new Activityy { ActivityId = 5, Name = "BaseBall", Type = "Compatable", Duration = 23 }
                );

            modelBuilder.Entity<Member>().HasData(
                    new Member { MemberId = 1, Name = "Essam", Phone = "12345678911"},
                    new Member { MemberId = 2, Name = "Omar", Phone = "12245678911"}
                );
        }

    }
}
