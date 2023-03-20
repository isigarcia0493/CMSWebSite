using CMSWebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CMSWebsite.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }
        public DbSet<FormMessage> FormMessages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Carousel> Carousel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EventRegistration>()
                .HasOne(r => r.Registration)
                .WithMany(er => er.EventRegistrations)
                .HasForeignKey(ri => ri.RegistrationId);

            builder.Entity<EventRegistration>()
                .HasOne(e => e.Event)
                .WithMany(er => er.EventRegistrations)
                .HasForeignKey(e => e.EventId);


            builder.Entity<Image>().HasOne(a => a.Album).WithMany(i => i.Images).IsRequired();
            builder.Entity<Album>().HasOne(c => c.Category).WithMany(a => a.Albums).IsRequired();
            builder.Entity<Registration>().HasOne(au => au.User).WithMany(r => r.Registrations).IsRequired();
            builder.Entity<FormMessage>().HasOne(au => au.User).WithMany(fm => fm.FormMessages).IsRequired();
        }
    }
}
