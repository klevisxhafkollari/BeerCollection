using BeerCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerCollection
{
    public partial class BeerDBContext : DbContext
    {
        public BeerDBContext() 
        { }

        public BeerDBContext(DbContextOptions<BeerDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerObj>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Type).HasMaxLength(50);
            });
        }

        public virtual DbSet<BeerObj> Beers { get; set; }
    }
}