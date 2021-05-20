using BudgetTracker.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastructure.Data
{
    public class BudgetTrackerDBContext: DbContext
    {
        public BudgetTrackerDBContext(DbContextOptions<BudgetTrackerDBContext> options): base(options)
        {

        }
        
        public DbSet<Users> Users { get; set; }

        public DbSet<Incomes> Income { get; set; }

        public DbSet<Expenditures> Expenditure { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(ConfigureUser);
            modelBuilder.Entity<Incomes>(ConfigureIncome);
            modelBuilder.Entity<Expenditures>(ConfigureExpenditure);

        }


        private void ConfigureUser(EntityTypeBuilder<Users> builder)
        {
            // write down all the Fluent API rules.
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(10).IsRequired();
            builder.Property(u => u.Fullname).HasMaxLength(50);
            


        }
        private void ConfigureIncome(EntityTypeBuilder<Incomes> builder)
        {
            builder.ToTable("Incomes");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Amount).HasColumnType("decimal(6, 2)").HasDefaultValue(9.9m).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(100);
            builder.Property(t => t.Remarks).HasMaxLength(500);
        }

        private void ConfigureExpenditure(EntityTypeBuilder<Expenditures> builder)
        {
            builder.ToTable("Expenditures");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Amount).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(100);
            builder.Property(t => t.Remarks).HasMaxLength(500);
        }

    }
}
