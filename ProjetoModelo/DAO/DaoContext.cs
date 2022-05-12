using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Sql;

namespace DAO
{
    public class DaoContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<WishList> WishList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=GABRIEL-BIZIO\SQLEXPRESS;Database=teste;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=CTPC3628\SQLEXPRESS;Database=teste;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.street).IsRequired();
                entity.Property(e => e.city).IsRequired();
                entity.Property(e => e.state).IsRequired();
                entity.Property(e => e.country).IsRequired();
                entity.Property(e => e.postal_code).IsRequired();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.name).IsRequired();
                entity.HasOne(d => d.address);
                //entity.Property(e => e.document).IsRequired();
                entity.Property(e => e.email).IsRequired();
                entity.Property(e => e.phone).IsRequired();
                entity.Property(e => e.login).IsRequired();
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.name).IsRequired();
                entity.HasOne(d => d.address);
                //entity.Property(e => e.document).IsRequired();
                entity.Property(e => e.email).IsRequired();
                entity.Property(e => e.phone).IsRequired();
                entity.Property(e => e.login).IsRequired();
                entity.Property(e => e.passwd).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.bar_code).IsRequired();
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.purchase_date).IsRequired();
                entity.Property(e => e.PurchaseStatus).IsRequired();
                entity.Property(e => e.Payment).IsRequired();
                entity.HasOne(d => d.client).WithMany();
                entity.HasOne(m => m.product);
                entity.HasOne(d => d.store);
            });


            modelBuilder.Entity<Stocks>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.quantity).IsRequired();
                entity.HasOne(d => d.store);
                entity.HasOne(d => d.product);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.cnpj).IsRequired();
                entity.HasOne(d => d.owner);           
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasOne(d => d.client);
                entity.HasOne(d => d.product);
            });

        }
    }


}

