using Microsoft.EntityFrameworkCore;
using BakeryProject.Domain.Entities;

namespace BakeryProject.Infrastructure
{
    public class BakeryDbContext : DbContext
    {
        public BakeryDbContext(DbContextOptions<BakeryDbContext> options)
            : base(options)
        {
        }

        public DbSet<BakeryOffice> BakeryOffices { get; set; }
        public DbSet<PastryChef> PastryChefs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Bread> Breads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BakeryOffice>().HasKey(b => b.Id);
            modelBuilder.Entity<PastryChef>().HasKey(p => p.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<OrderItem>().HasKey(oi => oi.Id);

            modelBuilder.Entity<Order>()
                .HasOne<BakeryOffice>()
                .WithMany(b => b.Orders)
                .HasForeignKey(o => o.BakeryOfficeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bread>()
                .HasDiscriminator<string>("BreadType")
                .HasValue<Baguette>("Baguette")
                .HasValue<WhiteBread>("WhiteBread")
                .HasValue<MilkBread>("MilkBread")
                .HasValue<HamburgerBun>("HamburgerBun");

            modelBuilder.Entity<Bread>().OwnsMany(b => b.BaseIngredients, a =>
            {
                a.WithOwner().HasForeignKey("BreadId");
                a.Property<int>("Id").ValueGeneratedOnAdd();
                a.HasKey("Id");
            });
        }
    }
}
