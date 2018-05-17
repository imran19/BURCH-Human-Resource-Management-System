using Diplomski.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Diplomski.Scripts
{
    public class DiplomskiContext : DbContext
    {
        public DiplomskiContext() : base("DiplomskiD")
        {


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<LeaveRequestForm> LeaveRequestForms { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ElectoralPeriod> ElectoralPeriods { get; set; }
        public DbSet<Stay> Stays { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Notification>()
                .HasRequired(n => n.LeaveRequestForm)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Notification>()
                .HasRequired(n => n.RequestingUser)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Notification>()
                .HasRequired(n => n.ApprovingUser)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
