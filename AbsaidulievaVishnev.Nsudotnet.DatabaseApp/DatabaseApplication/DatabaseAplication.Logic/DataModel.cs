namespace DatabaseApplication.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<applications> applications { get; set; }
        public virtual DbSet<buyers> buyers { get; set; }
        public virtual DbSet<cash> cash { get; set; }
        public virtual DbSet<category_attribute> category_attribute { get; set; }
        public virtual DbSet<countries> countries { get; set; }
        public virtual DbSet<customs> customs { get; set; }
        public virtual DbSet<goods> goods { get; set; }
        public virtual DbSet<managers> managers { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<provider_goods> provider_goods { get; set; }
        public virtual DbSet<providers> providers { get; set; }
        public virtual DbSet<providers_attributes> providers_attributes { get; set; }
        public virtual DbSet<providers_category> providers_category { get; set; }
        public virtual DbSet<sales> sales { get; set; }
        public virtual DbSet<storage> storage { get; set; }
        public virtual DbSet<attribute_value> attribute_value { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<applications>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.applications)
                .HasForeignKey(e => e.aplications_id);

            modelBuilder.Entity<buyers>()
                .Property(e => e.buyers_name)
                .IsUnicode(false);

            modelBuilder.Entity<buyers>()
                .HasMany(e => e.applications)
                .WithRequired(e => e.buyers)
                .HasForeignKey(e => e.buyer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<buyers>()
                .HasMany(e => e.cash)
                .WithOptional(e => e.buyers)
                .HasForeignKey(e => e.buyer_id);

            modelBuilder.Entity<cash>()
                .Property(e => e.typ)
                .IsUnicode(false);

            modelBuilder.Entity<cash>()
                .Property(e => e.number_of_good)
                .HasPrecision(6, 3);

            modelBuilder.Entity<cash>()
                .Property(e => e.cost)
                .HasPrecision(6, 2);

            modelBuilder.Entity<cash>()
                .Property(e => e.act)
                .IsUnicode(false);

            modelBuilder.Entity<category_attribute>()
                .HasMany(e => e.attribute_value)
                .WithRequired(e => e.category_attribute)
                .HasForeignKey(e => new { e.category_id, e.attribute_id })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<countries>()
                .Property(e => e.country_name)
                .IsUnicode(false);

            modelBuilder.Entity<countries>()
                .HasMany(e => e.providers)
                .WithRequired(e => e.countries)
                .HasForeignKey(e => e.country_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customs>()
                .Property(e => e.duty)
                .HasPrecision(6, 2);

            modelBuilder.Entity<customs>()
                .HasMany(e => e.cash)
                .WithRequired(e => e.customs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<goods>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<goods>()
                .Property(e => e.measure)
                .IsUnicode(false);

            modelBuilder.Entity<goods>()
                .Property(e => e.price_per_unit)
                .HasPrecision(6, 2);

            modelBuilder.Entity<goods>()
                .HasMany(e => e.cash)
                .WithRequired(e => e.goods)
                .HasForeignKey(e => e.good_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<goods>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.goods)
                .HasForeignKey(e => e.good_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<goods>()
                .HasMany(e => e.provider_goods)
                .WithRequired(e => e.goods)
                .HasForeignKey(e => e.good_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<goods>()
                .HasOptional(e => e.sales)
                .WithRequired(e => e.goods);

            modelBuilder.Entity<managers>()
                .Property(e => e.manager_name)
                .IsUnicode(false);

            modelBuilder.Entity<managers>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.managers)
                .HasForeignKey(e => e.manager_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<orders>()
                .Property(e => e.quantyty)
                .HasPrecision(6, 3);

            modelBuilder.Entity<orders>()
                .HasOptional(e => e.customs)
                .WithRequired(e => e.orders);

            modelBuilder.Entity<provider_goods>()
                .Property(e => e.deliverly_cost)
                .HasPrecision(6, 2);

            modelBuilder.Entity<providers>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<providers>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.providers)
                .HasForeignKey(e => e.providers_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<providers>()
                .HasMany(e => e.provider_goods)
                .WithRequired(e => e.providers)
                .HasForeignKey(e => e.provider_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<providers>()
                .HasMany(e => e.attribute_value)
                .WithRequired(e => e.providers)
                .HasForeignKey(e => e.provider_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<providers_attributes>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<providers_attributes>()
                .HasMany(e => e.category_attribute)
                .WithRequired(e => e.providers_attributes)
                .HasForeignKey(e => e.attribute_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<providers_category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<providers_category>()
                .HasMany(e => e.category_attribute)
                .WithRequired(e => e.providers_category)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<providers_category>()
                .HasMany(e => e.providers)
                .WithRequired(e => e.providers_category)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sales>()
                .Property(e => e.cost)
                .HasPrecision(6, 2);

            modelBuilder.Entity<storage>()
                .Property(e => e.good_volume)
                .HasPrecision(6, 3);

            modelBuilder.Entity<storage>()
                .Property(e => e.cell_volume)
                .HasPrecision(6, 3);

            modelBuilder.Entity<attribute_value>()
                .Property(e => e.val)
                .IsUnicode(false);
        }
    }
}
