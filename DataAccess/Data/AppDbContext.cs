using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Office>().HasKey(o => o.Id);
            modelBuilder.Entity<AttendanceRecord>().HasKey(a => a.Id);

            modelBuilder.Entity<Office>()
                .HasMany(o => o.Employees)
                .WithOne(e => e.Office)
                .HasForeignKey(e => e.OfficeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
