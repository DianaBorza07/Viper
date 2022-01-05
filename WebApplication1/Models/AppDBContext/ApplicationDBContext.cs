using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace CarRental.Models.AppDBContext
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        private readonly DbContextOptions _options;

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<Car> Cars { set; get; }
        public DbSet<Rental> Rentals { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
