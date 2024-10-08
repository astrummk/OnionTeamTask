﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionTeamTask.DomainLayer.DomainModels;

namespace OnionTeamTask.RepositoryLayer
{
    public partial class TeamTaskManDbContext : DbContext
    {
        public TeamTaskManDbContext()
        {
        }

        public TeamTaskManDbContext(DbContextOptions<TeamTaskManDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<TaskHistory> TaskHistories { get; set; }

        public virtual DbSet<Taskd> Taskds { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=LEGION\\SQLEXPRESS;Database=TeamTaskManDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;");

        //(LocalDb)\MSSQLLocalDB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taskd>(entity =>
            {
                entity.Property(e => e.TaskId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.TaskIntId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).IsClustered(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
