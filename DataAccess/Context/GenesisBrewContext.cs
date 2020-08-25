using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class GenesisBrewContext : DbContext
    {
        public GenesisBrewContext(DbContextOptions<GenesisBrewContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GenesisBrew;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public virtual DbSet<BeerEntity> Beer { get; set; }
        public virtual DbSet<BreweryEntity> Brewery { get; set; }
        public virtual DbSet<WholesalerEntity> Wholesaler { get; set; }
        public virtual DbSet<BeerStockItemEntity> StockItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
