using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppointmentTracker.Models;

namespace AppointmentTracker.Data
{
    public class SpaAppContext : DbContext //TODO: add an IReadOnlySpaAppContext
    {
        public SpaAppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentModel>().HasKey(x => x.Id).ForSqlServerIsClustered();
            modelBuilder.Entity<AppointmentModel>().Property(x => x.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<CustomerModel>().HasKey(x => x.Id).ForSqlServerIsClustered();
            modelBuilder.Entity<CustomerModel>().Property(x => x.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<ServiceProviderModel>().HasKey(x => x.Id).ForSqlServerIsClustered();
            modelBuilder.Entity<ServiceProviderModel>().Property(x => x.Id).UseSqlServerIdentityColumn();

            //TODO: COME BACK TO THIS
            //modelBuilder.Entity<ToDo>().HasOne(x => x.Status).WithMany(x => x.ToDos).HasForeignKey(x => x.StatusId);
            //modelBuilder.Entity<ToDo>().HasIndex(x => x.StatusId).HasName($"IX_{nameof(ToDo)}_{nameof(ToDo.Status)}");
            //modelBuilder.Entity<ToDo>().HasOne(x => x.Tag).WithMany(x => x.ToDos).HasForeignKey(x => x.TagId);
            //modelBuilder.Entity<ToDo>().HasIndex(x => x.TagId).HasName($"IX_{nameof(ToDo)}_{nameof(ToDo.Tag)}");

            //modelBuilder.Entity<Status>().HasMany(x => x.ToDos).WithOne(x => x.Status);

            //modelBuilder.Entity<Tag>().HasMany(x => x.ToDos).WithOne(x => x.Tag);
        }

        public DbSet<AppointmentModel> Appointments { get; set; }

        public DbSet<CustomerModel> Customers { get; set; }

        public DbSet<ServiceProviderModel> Providers { get; set; }

        //TODO: Come back to this
        //IQueryable<ToDo> IReadOnlyToDoContext.ToDos { get => ToDos.AsNoTracking(); }

        //IQueryable<Status> IReadOnlyToDoContext.Statuses { get => Statuses.AsNoTracking(); }

    }
}
