using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using test01_SERVICES.Utils;

#nullable disable

namespace test01_SERVICES.Models
{
    public partial class test01Context : DbContext
    {
        public test01Context()
        {
        }

        public test01Context(DbContextOptions<test01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ConnectionString.Init());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACTS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birthDate");

                entity.Property(e => e.CivilStatus)
                    .HasMaxLength(10)
                    .HasColumnName("civilStatus");

                entity.Property(e => e.Disabled).HasColumnName("disabled");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("lastName");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(13)
                    .HasColumnName("telephoneNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
