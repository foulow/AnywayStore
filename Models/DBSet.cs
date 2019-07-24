namespace AnywayStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBSet : DbContext
    {
        public DBSet()
            : base("name=DBSet")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Categories)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<Products>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.measurement)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.style)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Sales)
                .WithOptional(e => e.Products)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<Roles>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Roles)
                .HasForeignKey(e => e.role_id);

            modelBuilder.Entity<Users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Sales)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.user_id);
        }
    }
}
