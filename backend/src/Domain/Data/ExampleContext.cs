using Domain.Data.Seed;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public partial class ExampleContext : DbContext
    {
        public virtual DbSet<Weather> WheatherHistory { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(CountrySeed.GetData());
            modelBuilder.Entity<City>().HasData(CitySeed.GetData());
        }
    }
}
