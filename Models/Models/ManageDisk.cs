using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Models
{
    public partial class ManageDisk : DbContext
    {
        public ManageDisk()
            : base("name=ManageDisk")
        {
        }

        public virtual DbSet<C_Disk> C_Disk { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LateCharge> LateCharges { get; set; }
        public virtual DbSet<MessageOnHold> MessageOnHolds { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C_Disk>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.C_Disk)
                .HasForeignKey(e => e.DiskID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Disk>()
                .HasMany(e => e.Titles)
                .WithMany(e => e.C_Disk)
                .Map(m => m.ToTable("Disk_Title").MapLeftKey("DiskID").MapRightKey("TitleID"));

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.Bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.MessageOnHolds)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.MessageOnHolds)
                .WithRequired(e => e.Title)
                .WillCascadeOnDelete(false);
        }
    }
}
