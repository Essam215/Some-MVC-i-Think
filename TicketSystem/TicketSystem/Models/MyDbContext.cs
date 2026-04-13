using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace TicketSystem.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Ticket)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TicketId);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Event ev)
                {
                    if (ev.EventDate < DateTime.Now)
                        throw new Exception("Event date cannot be in the past");

                    if (ev.Capacity <= 0)
                        throw new Exception("Capacity must be greater than 0");
                }

                if (entry.Entity is Booking booking)
                {
                    if (booking.BookingDate > DateTime.Now)
                        throw new Exception("Booking date cannot be in the future");

                    if (booking.Quantity <= 0)
                        throw new Exception("Quantity must be greater than 0");
                }

                if (entry.Entity is Ticket ticket)
                {
                    if (ticket.Price <= 0)
                        throw new Exception("Price must be greater than 0");
                }
            }

            return base.SaveChanges();
        }
    }
}
