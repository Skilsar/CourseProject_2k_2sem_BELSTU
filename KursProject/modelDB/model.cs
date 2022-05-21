using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KursProject.modelDB
{
    public partial class model : DbContext
    {
        public model()
            : base("name=ModelDB")
        {
        }

        public virtual DbSet<AUTHORIZATION> AUTHORIZATIONs { get; set; }
        public virtual DbSet<DRIVER> DRIVERS { get; set; }
        public virtual DbSet<FLIGHT> FLIGHTS { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AUTHORIZATION>()
                .HasMany(e => e.DRIVERS)
                .WithOptional(e => e.AUTHORIZATION)
                .HasForeignKey(e => e.Auth_id);

            modelBuilder.Entity<AUTHORIZATION>()
                .HasMany(e => e.USERS)
                .WithOptional(e => e.AUTHORIZATION)
                .HasForeignKey(e => e.Auth_id);

            modelBuilder.Entity<DRIVER>()
                .Property(e => e.surname)
                .IsFixedLength();

            modelBuilder.Entity<DRIVER>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<DRIVER>()
                .Property(e => e.number_car)
                .IsFixedLength();

            modelBuilder.Entity<DRIVER>()
                .Property(e => e.brand_car)
                .IsFixedLength();

            modelBuilder.Entity<DRIVER>()
                .Property(e => e.color_car)
                .IsFixedLength();

            modelBuilder.Entity<DRIVER>()
                .Property(e => e.phone_number)
                .IsFixedLength();

            modelBuilder.Entity<DRIVER>()
                .Property(e => e.photo_car)
                .IsUnicode(false);

            modelBuilder.Entity<DRIVER>()
                .HasMany(e => e.FLIGHTS)
                .WithOptional(e => e.DRIVER)
                .HasForeignKey(e => e.Id_driver);

            modelBuilder.Entity<FLIGHT>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.FLIGHT1)
                .HasForeignKey(e => e.flight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.date)
                .IsFixedLength();

            modelBuilder.Entity<ORDER>()
                .Property(e => e.time)
                .IsFixedLength();

            modelBuilder.Entity<USER>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<USER>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
