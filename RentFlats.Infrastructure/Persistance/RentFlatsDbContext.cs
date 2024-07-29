using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentFlats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentFlats.Infrastructure.Persistance
{
    public class RentFlatsDbContext : IdentityDbContext
    {
        public RentFlatsDbContext(DbContextOptions<RentFlatsDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Flat> Flats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FlatAddress>()
                .HasOne(u => u.Flat)
                .WithOne(u => u.Address)
                .HasForeignKey<Flat>(u => u.AddressId);

            modelBuilder.Entity<FlatContactDetails>()
                .HasOne(u => u.Flat)
                .WithOne(u => u.ContactDetails)
                .HasForeignKey<Flat>(u => u.ContactDetailsId);
        }
    }
}
