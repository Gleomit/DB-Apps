namespace HomeworkProcessingJSON
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using HomeworkProcessingJSON.Migrations;
    using HomeworkProcessingJSON.Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductShopContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("UserFriends");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");     
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.BoughtProducts)
                .WithOptional(p => p.Buyer)
                .HasForeignKey(p => p.BuyerId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SoldProducts)
                .WithOptional(p => p.Seller)
                .HasForeignKey(p => p.SellerId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .Map(m =>
                {
                    m.MapLeftKey("ProductId");
                    m.MapRightKey("CategoryId");
                });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }
    }
}